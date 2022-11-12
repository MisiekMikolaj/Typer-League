using Microsoft.EntityFrameworkCore;
using TyperLeague.DataAccess.Entities;

namespace TyperLeague.DataAccess.CQRS.Commands.CommandsExtensions
{
    public static class EditGamePointsCommandExtension
    {
        static int poiontsForCorrectResult = 3;
        static int poiontsForCorrectDraw = 2;
        static int poiontsForCorrectWinner = 1;
        static int incorrectResult = 0;

        static string[] userPrediction = new string[2];
        public static async void UpdateBetsRealResultByGameResult(TyperLeagueStorageContext context, int gameId, string gameResult)
        {
            context.Bets.Where(x => x.Game.Id == gameId).ToList().ForEach(b => b.RealResult = gameResult);
            context.SaveChanges();
        }

        public static async void UpdateUserPointsBetsPoints(TyperLeagueStorageContext context, int gameId)
        {
            var bets = context.Bets.Where(x => x.Game.Id == gameId).Select(x => new Bet
            {
                UserId = x.UserId,
                RealResult = x.RealResult,
                User = x.User,
                UserPrediction = x.UserPrediction,
                BetPoints = x.BetPoints
            }).ToList();

            foreach (var bet in bets)
            {
                bet.User.Points -= bet.BetPoints;

                if (bet.RealResult == bet.UserPrediction)
                {
                    bet.BetPoints = poiontsForCorrectResult;
                }
                else
                {
                    var realResult = bet.RealResult.Split(" : ");
                    if(!int.TryParse(realResult[0], out int realResultTeam1) | !int.TryParse(realResult[1], out int realResultTeam2))
                    {
                    }

                    if (bet.UserPrediction != "???")
                    {
                        userPrediction = bet.UserPrediction.Split(" : ");
                    }
                    
                    if(!int.TryParse(userPrediction[0], out int userPredictionTeam1) | !int.TryParse(userPrediction[1], out int userPredictionTeam2))
                    {
                        userPredictionTeam1 = -1;
                        userPredictionTeam2 = -1;
                    }

                    if (IsWinnerTypedCorrect(realResultTeam1, realResultTeam2, userPredictionTeam1, userPredictionTeam2))
                    {
                        bet.BetPoints = poiontsForCorrectWinner;
                    }
                    else if(IsDrawTypedCorrect(realResultTeam1, realResultTeam2, userPredictionTeam1, userPredictionTeam2))
                    {
                        bet.BetPoints = poiontsForCorrectDraw;
                    }
                    else
                    {
                        bet.BetPoints = incorrectResult;
                    }
                }
                context.Bets.Where(x => x.Game.Id == gameId && x.UserId == bet.UserId).FirstOrDefault().BetPoints = bet.BetPoints;
                bet.User.Points += bet.BetPoints;
            }
            context.SaveChanges();
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
            if ((realResultTeam1 == realResultTeam2 && userPredictionTeam1 == userPredictionTeam2) && userPredictionTeam1 != -1)
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
