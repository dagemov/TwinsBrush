using Twins.Shared.Responses;

namespace Twins.Api.Services
{
    public interface IApiService
    {
        //Interface to consume externals Apis (generic Api)
        Task<Response> GetListAsync<T>(string servicePrefix, string controller);
        Task<Response> GetAsync<T>(string servicePrefix, string controller);
    }
}
