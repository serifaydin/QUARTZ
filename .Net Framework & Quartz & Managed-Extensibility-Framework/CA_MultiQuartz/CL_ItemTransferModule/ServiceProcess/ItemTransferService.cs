using CL_Modules;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CL_ItemTransferModule.ServiceProcess
{
    public class ItemTransferService : ApiModule
    {
        public async Task<ServiceResult> GetItemFullList()
        {
            HttpClient client = await GetClient();
            var result = await client.GetStringAsync(Url + "itemTransfer");
            var serviceResult = JsonConvert.DeserializeObject<ServiceResult>(result);

            return serviceResult;
        }
    }
}