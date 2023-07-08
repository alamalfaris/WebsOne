using Models.Responses;
using System.Text.Json;

namespace WebsOne.Api.Helpers
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var baseResponse = new ResponseBase<string> { Data = null, Message = ex.Message };

                switch (ex)
                {
                    case BadRequestException:
                        baseResponse.Status = StatusCodes.Status400BadRequest;
                        break;
                    case KeyNotFoundException:
                        baseResponse.Status = StatusCodes.Status404NotFound;
                        break;
                    default:
                        baseResponse.Status = StatusCodes.Status500InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(baseResponse);
                await response.WriteAsync(result);
            }
        }
    }
}