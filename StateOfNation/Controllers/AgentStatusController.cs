using StateOfNation.Connection;
using StateOfNation.Requests;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StateOfNation.Controllers
{
    public class AgentStatusController : Controller
    {
        private readonly ConnectionSQL connection;
        public AgentStatusController(ConnectionSQL connection)
        {
            this.connection = connection;
        }
        public ActionResult View()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> getListAgentStatusAsync(FilterAgentStatusRequest request, PagingParameter pagingparametermodel, bool isRealTime)
        {
            if(isRealTime)
            {
                var getListAgentDe = await connection.getAgentStatusDepedencyUpdated(request, pagingparametermodel);
                var responseR = new
                {
                    data = getListAgentDe
                };
                return Json(responseR, JsonRequestBehavior.AllowGet);

            }
            var getListAgentStatus = connection.getListAgentStatus(request, pagingparametermodel);
            var response = new
            {
                data = getListAgentStatus,
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}