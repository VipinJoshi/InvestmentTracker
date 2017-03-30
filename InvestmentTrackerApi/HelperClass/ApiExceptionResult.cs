/*
 * Exception result class call from Handler class 
 */
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace InvestmentTrackerApi.HelperClass
{
    internal class ApiExceptionResult : IHttpActionResult
    {
        private HttpRequestMessage request;
        private HttpResponseMessage result;

        public ApiExceptionResult(HttpRequestMessage request, HttpResponseMessage result)
        {
            this.request = request;
            this.result = result;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(result);
        }
    }
}