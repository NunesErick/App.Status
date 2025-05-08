using App.Monitor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Status.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitorController : ControllerBase
    {
        private readonly IMonitorService _serv;
        public MonitorController(IMonitorService serv)
        {
            _serv = serv;
        }
        [HttpGet("getapps")]
        public async Task<IActionResult> GetApps()
        {
            try
            {
                var result = await _serv.GetApps();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getlogappbyid/{id}")]
        public async Task<IActionResult> GetLogAppById(int id,[FromQuery] int rangeHour)
        {
            try
            {
                var result = await _serv.GetLogAppById(id, rangeHour);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
