using SRP.Web.Contracts;

using System.Net.Http.Headers;

namespace SRP.Web.Services.Base
{
    public class BaseHttpService
    {
        private readonly IClient mClient;
        private readonly ILocalStorageService mLocalStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            mClient = client;
            mLocalStorage = localStorage;
        }

        protected Response<Guid> ConvertApiException<Guid>(ApiException exception)
        {
            if(exception.StatusCode == 400)
            {
                return new Response<Guid>
                {
                    Message = "Validation errors have occured!",
                    Success = false,
                    ValidationErrors = exception.Response
                };
            }
            else if(exception.StatusCode == 404)
            {
                return new Response<Guid>
                {
                    Message = "The requested item could not be found!",
                    Success = false
                };
            }
            else
            {
                return new Response<Guid>
                {
                    Message = "Something went wrong. Please try again!",
                    Success = false
                };
            }
        }

        protected void AddBearerToken()
        {
            if(mLocalStorage.Exists("token"))
                mClient.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", mLocalStorage.GetStorageValue<string>("token"));
        }
    }
}

