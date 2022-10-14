using Microsoft.EntityFrameworkCore;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Commands.CommandsExtensions
{
    public static class EditGamePointsCommandExtension
    {
        static int poiontsForCorrectResult = 3;
        static int poiontsForCorrectDraw = 2;
        static int poiontsForCorrectWinner = 1;

        public static async void UpdateBetsRealResultByGameResult(TyperLeagueStorageContext context, int gameId, string gameResult)
        {
            context.Bets.Where(x => x.Game.Id == gameId).ToList().ForEach(b => b.RealResult = gameResult);
            await context.SaveChangesAsync();
        }

        public static async void UpdateUserPoints(TyperLeagueStorageContext context, int gameId)
        {
            var bets = context.Bets.Where(x => x.Game.Id == gameId).Select(x => new Bet
            {
                UserId = x.UserId,
                RealResult = x.RealResult,
                User = x.User,
                UserPrediction = x.UserPrediction
            }).ToList();

            foreach (var bet in bets)
            {
                if (bet.RealResult == bet.UserPrediction)
                {
                    bet.User.Points += poiontsForCorrectResult;
                }
                else
                {
                    var realResult = bet.RealResult.Split(" : ");
                    var realResultTeam1 = int.Parse(realResult[0]);
                    var realResultTeam2 = int.Parse(realResult[1]);

                    var userPrediction = bet.UserPrediction.Split(" : ");
                    var userPredictionTeam1 = int.Parse(userPrediction[0]);
                    var userPredictionTeam2 = int.Parse(userPrediction[1]);

                    if (IsWinnerTypedCorrect(realResultTeam1, realResultTeam2, userPredictionTeam1, userPredictionTeam2))
                    {
                        bet.User.Points += poiontsForCorrectWinner;
                    }
                    else if(IsDrawTypedCorrect(realResultTeam1, realResultTeam2, userPredictionTeam1, userPredictionTeam2))
                    {
                        bet.User.Points += poiontsForCorrectDraw;
                    }
                }
                
            }

            await context.SaveChangesAsync();
        }

        static bool IsWinnerTypedCorrect(int realResultTeam1, int realResultTeam2, int userPredictionTeam1, int userPredictionTeam2)
        {
            if ((realResultTeam1 < realResultTeam2 && userPredictionTeam1 < userPredictionTeam2) ||(realResultTeam1 > realResultTeam2 && userPredictionTeam1 > userPredictionTeam2))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        static bool IsDrawTypedCorrect(int realResultTeam1, int realResultTeam2, int userPredictionTeam1, int userPredictionTeam2)
        {
            if ((realResultTeam1 == realResultTeam2 && userPredictionTeam1 == userPredictionTeam2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
