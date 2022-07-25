using Microsoft.AspNetCore.Mvc;
using Mini_project_API.Filter;
using Mini_project_API.Interface.IService;
using Mini_project_API.ViewModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mini_project_API.Controllers
{
    [AuthorizeFilter(role: "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            this._adminService = adminService;
        }


        [HttpGet("GetAllAccount")]
        public async Task<IActionResult> GetAccount()
        {
            var listAccount = await _adminService.GetAccountsAsync();
           
            return Ok(listAccount);
        }

        [HttpGet("GetReportTest/{id}")]
        public async Task<IActionResult> GetReportTest(int id)
        {
            var reporttest = await _adminService.GetReportTestAsync(id);
           
            return reporttest != null ? Ok(reporttest) : NotFound();
        }

       
        [HttpPut("ActiveAccount/{id}")]
        public async Task<IActionResult> ActiveAccount(int id)
        {
            var status = await _adminService.ActiveAccountAsync(id);

            return status ? Ok() : NotFound();
        }

        [HttpPut("BlockAccount/{id}")]
        public async Task<IActionResult> BlockAccountAsync(int id)
        {
           var status = await _adminService.BlockAccountAsync(id);

            return status ? Ok() : NotFound();
        }

    }
}
