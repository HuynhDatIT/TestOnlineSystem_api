using AutoFixture;
using AutoMapper;
using DatHT8_Mini_project_API.ConfigAutomap;
using Microsoft.EntityFrameworkCore;
using Mini_project_API.Data;
using Mini_project_API.Interface;
using Mini_project_API.Interface.IService;
using Mini_project_API.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOnlineSystem_api_UnitTest
{
    public class SetupTest
    {
        protected readonly IMapper _mapper;
        protected readonly Fixture _fixture;
        protected readonly Mock<IUnitOfWork> _unitOfWorkMock;
        protected readonly Mock<IElearningDbContext> _learningDbContextMock;
        protected readonly Mock<IAdminService> _adminServiceMock;

        public SetupTest()
        {
            var mapper = new MapperConfiguration(mc => 
            {
                mc.AddProfile(new AccountAutomap());
                mc.AddProfile(new AnswerAutomap());
                mc.AddProfile(new QuestionAutomap());
                mc.AddProfile(new TestAccountAutomap());
                mc.AddProfile(new TestAutoMap());
            });

            _mapper = mapper.CreateMapper();
            _fixture = new Fixture();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _adminServiceMock = new Mock<IAdminService>();
            _learningDbContextMock = new Mock<IElearningDbContext>();
           
        }
    }
}
