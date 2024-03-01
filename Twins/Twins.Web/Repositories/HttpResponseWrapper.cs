using System.Net;

namespace Twins.Web.Repositories
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Error = error;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }

        public bool Error { get; set; }

        public T? Response { get; set; }

        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string?> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null;
            }

            var codigoEstatus = HttpResponseMessage.StatusCode;
            if (codigoEstatus == HttpStatusCode.NotFound)
            {
                return "404\nRecurse Not FOUND";
            }
            else if (codigoEstatus == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            else if (codigoEstatus == HttpStatusCode.Unauthorized)
            {
                return "Error 401\nYou must be Login to do this action";
            }
            else if (codigoEstatus == HttpStatusCode.Forbidden)
            {
                return "Error 403 \nYou aren't Atuorize TO DO THIS";
            }else if (codigoEstatus == HttpStatusCode.InternalServerError)
            {
                return "Error 500\n Interal error server";
            }

            return "Undefined ERROR";
        }

    }
}
