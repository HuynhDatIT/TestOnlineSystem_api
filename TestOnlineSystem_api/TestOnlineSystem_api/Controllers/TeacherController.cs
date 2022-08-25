using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_project_API.Filter;
using Mini_project_API.Interface.IService;
using Mini_project_API.ViewModel.Request;
using Mini_project_API.ViewModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mini_project_API.Controllers
{
   // [AuthorizeFilter(role: "teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService questionService)
        {
            this._teacherService = questionService;
        }

        [HttpGet("GetAllTestAccount")]
        public async Task<ActionResult> GetAllTestAccount()
        {
            var listtest = await _teacherService.GetTestAccountsAsync();

            return listtest != null ? Ok(listtest) : BadRequest();

        }

        [HttpGet("GetReportTest/{id}")]
        public async Task<IActionResult> GetReportTestById(int id)
        {
            var testreport = await _teacherService.GetReportTestAsync(id);

            return testreport != null ? Ok(testreport) : NotFound();
        }

        [HttpPost]
        [Route("CreateQuestion")]
        public async Task<IActionResult> PostCreateQuestion([FromBody] CreateQuestionAnswer postquestion)
        {
            try
            {
                await _teacherService.CreateQuestionAnswerAsync(postquestion);
                
                return Ok();
            }
            catch
            {

                return BadRequest();
            }
            
        }
        [HttpPost]
        [Route("CreateTest")]
        public async Task<IActionResult> PostCreateTest([FromBody] CreateTest createtest)
        {
            try
            {
                await _teacherService.CreateTestAsync(createtest);
                return Ok();
            }
            catch
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("CreateTestAccount")]
        public async Task<IActionResult> PostCreateTestAccount([FromBody] CreateTestAccount createtestaccount)
        {
            try
            {
                await _teacherService.CreateTestAccountAsync(createtestaccount);
                return Ok();
            }
            catch 
            {
                return BadRequest();
            }
        }

    }
}
