using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.ApplicationServices.API.ErrorHandling;

namespace TyperLeague.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator mediator;

        protected ApiControllerBase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : BaseRequest, IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(
                    this.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new { property = x.Key, errors = x.Value.Errors })
                    );
            }
            if(this.User.Claims.FirstOrDefault() != null)
            {
                var userName = this.User.FindFirstValue(ClaimTypes.Name);
                var userId = int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                //var userIsAdmin = this.User.FindFirstValue(claimType: "IsAdmin");
                request.userNameClaim = userName;
                request.userIdClaim = userId;
            }

            var response = await this.mediator.Send(request);
            if (response.Error != null)
            {
                return this.ErrorResponse(response.Error);
            }

            return this.Ok(response);
        }
        private IActionResult ErrorResponse(ErrorModel errorModel)
        {
            var httpCode = GetHttpStatusCode(errorModel.Error);
            return StatusCode((int)httpCode, errorModel);
        }

        private static HttpStatusCode GetHttpStatusCode(string errorType)
        {
            switch (errorType)
            {
                case ErrorType.NotFound:
                    return HttpStatusCode.NotFound;
                case ErrorType.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                case ErrorType.Unauthorized:
                    return HttpStatusCode.Unauthorized;
                case ErrorType.RequestTooLarge:
                    return HttpStatusCode.RequestEntityTooLarge;
                case ErrorType.UnsupportedMediaType:
                    return HttpStatusCode.UnsupportedMediaType;
                case ErrorType.UnsupportedMethod:
                    return HttpStatusCode.MethodNotAllowed;
                case ErrorType.TooManyRequests:
                    return (HttpStatusCode)429;
                default:
                    return HttpStatusCode.BadRequest;
            }
        }
    }
}
