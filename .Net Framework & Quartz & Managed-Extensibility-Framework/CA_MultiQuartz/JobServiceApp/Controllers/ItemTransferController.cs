using CL_Modules;
using System.Collections.Generic;
using System.Web.Http;

namespace JobServiceApp.Controllers
{
    [RoutePrefix("api/items")]
    public class ItemTransferController : ApiController
    {
        [HttpGet]
        [Route("itemTransfer")]
        public ServiceResult ItemTransferWork()
        {
            ServiceResult result = new ServiceResult();

            result.Result = true;
            try
            {
                result.Data = new object();
                result.Message = "Success";
            }
            catch (System.Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}