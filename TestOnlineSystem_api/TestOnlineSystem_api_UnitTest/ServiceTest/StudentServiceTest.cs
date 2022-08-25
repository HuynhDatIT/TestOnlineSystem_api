using Mini_project_API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestOnlineSystem_api_UnitTest.ServiceTest
{
    public class StudentServiceTest : SetupTest
    {
        private readonly StudentService _studentService;

        public StudentServiceTest()
        {
            _studentService = new StudentService(_unitOfWorkMock.Object, _mapper);
        }

        [Fact]
        public void GetTestAsync_WhenTestNotNull()
        {
            //arrange

        }
    }
}
