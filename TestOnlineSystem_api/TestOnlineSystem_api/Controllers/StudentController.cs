using Microsoft.AspNetCore.Mvc;
using Mini_project_API.Filter;
using Mini_project_API.Interface.IService;
using Mini_project_API.ViewModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mini_project_API.Controllers
{
    [AuthorizeFilter(role: "student")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            this._studentService = studentService;
        }

        [HttpGet("Gettest/{id}")]
        public async Task<IActionResult> GetTestById(int id)
        {
            var test = await _studentService.GetTestAsync(id);
            
            return test != null ? Ok(test) : NotFound();
        }

        [HttpGet("GetAllTestByAccountId/{id}")]
        public async Task<IActionResult> GetAllTestByAccountId(int id)
        {
            var testaccountList = await _studentService.GetTestAccountByAccountIdAsync(id);
           
            return testaccountList != null ? Ok(testaccountList) : NotFound();
        }

    }
}
