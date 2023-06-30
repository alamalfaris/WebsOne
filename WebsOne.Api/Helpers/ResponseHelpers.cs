using Models.Responses;

namespace WebsOne.Api.Helpers
{
    public static class ResponseHelpers<T>
    {
        public static ResponseBase<T> CreateResponseSuccess(T responseObject, string messageSuccess)
        {
            var response = new ResponseBase<T>()
            {
                Message = messageSuccess,
                Status = StatusCodes.Status200OK,
                Data = responseObject
            };

            return response;
        }
    }
}
