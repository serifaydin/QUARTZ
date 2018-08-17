using System.Net.Http;
using System.Threading.Tasks;

namespace CL_Modules
{
    public class ApiModule
    {
        protected string Url = "http://localhost:52529/api/items/";
        protected async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
    }
}