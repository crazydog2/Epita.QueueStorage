using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Epita.QueueStorage.Logic.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Epita.QueueStorage.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class MetricsController : Controller
    {
        private readonly IMetricLogic metricLogic;

        public MetricsController(IMetricLogic metricLogic)
        {
            this.metricLogic = metricLogic;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IDictionary<string, int>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAsync([FromQuery] ISet<string> tags)
        {
            string userId = HttpContext.User.Identity.Name;

            IDictionary<string, int> metric = await metricLogic.GetAsync(userId, tags).ConfigureAwait(false);

            if (metric == null)
            {
                return NotFound();
            }

            return Ok(metric);
        }
    }
}