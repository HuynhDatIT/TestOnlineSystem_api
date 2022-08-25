using AutoFixture;
using FluentAssertions;
using Mini_project_API.Models;
using Mini_project_API.Service;
using Mini_project_API.ViewModel.Response;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestOnlineSystem_api_UnitTest.ServiceTest
{
    public class AdminServiceTest : SetupTest
    {
        private readonly AdminService _adminService;
        public AdminServiceTest()
        {
            _adminService = new AdminService(_unitOfWorkMock.Object, _mapper);
        }

        [Fact]
        public async void ActiveAccountAsync_WhenAccountNotNull()
        {
            //arrange
            var id = It.IsAny<int>();
           
            var mockAccount = _fixture.Build<Account>()
                                        .Without(x => x.TestAccounts)
                                        .Without(x => x.Role).With(x => x.Id, id).Create();

            _unitOfWorkMock
                .Setup(x => x.AccountRepository.GetByIdAsync(id)).ReturnsAsync(mockAccount);
           
            mockAccount.IsActive = true;
            
            _unitOfWorkMock.Setup(x => x.AccountRepository.Update(mockAccount));
            
            _unitOfWorkMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);
            //act

            var result = await _adminService.ActiveAccountAsync(id);

            //assert
            Assert.True(result);
        }
        [Fact]
        public async void ActiveAccountAsync_WhenAccountNull()
        {
            //arrange
            var id = It.IsAny<int>();

            var mockAccount = _fixture.Build<Account>()
                                        .Without(x => x.TestAccounts)
                                        .Without(x => x.Role).With(x => x.Id, id).Create();

            _unitOfWorkMock
                .Setup(x => x.AccountRepository
                .GetByIdAsync(It.IsAny<int>())).ReturnsAsync(mockAccount);

           
            //act

            var result = await _adminService.ActiveAccountAsync(id);

            //assert
            Assert.False (result);
        }
        [Fact]
        public async void ActiveAccountAsync_WhenSaveChangesFail()
        {

            //arrange
            var id = It.IsAny<int>();

            var mockAccount = _fixture.Build<Account>()
                                        .Without(x => x.TestAccounts)
                                        .Without(x => x.Role).With(x => x.Id, id).Create();

            _unitOfWorkMock
                .Setup(x => x.AccountRepository.GetByIdAsync(id)).ReturnsAsync(mockAccount);

            mockAccount.IsActive = true;

            _unitOfWorkMock.Setup(x => x.AccountRepository.Update(mockAccount));

            _unitOfWorkMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(0);
            //act

            var result = await _adminService.ActiveAccountAsync(id);

            //assert
            Assert.False(result);
        }
        [Fact]
        public async void BlockAccountAsync_WhenSaveChangesSuccess()
        {
            //arrange
            var id = It.IsAny<int>();

            var mockAccount = _fixture.Build<Account>()
                                        .Without(x => x.TestAccounts)
                                        .Without(x => x.Role).With(x => x.Id, id).Create();

            _unitOfWorkMock
                .Setup(x => x.AccountRepository.GetByIdAsync(id)).ReturnsAsync(mockAccount);

            mockAccount.IsBlock = true;

            _unitOfWorkMock.Setup(x => x.AccountRepository.Update(mockAccount));

            _unitOfWorkMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);
            //act

            var result = await _adminService.BlockAccountAsync(id);

            //assert
            Assert.True(result);
        }
        [Fact]
        public async void BlockAccountAsync_WhenSaveChangesFail()
        {
            //arrange
            var id = It.IsAny<int>();

            var mockAccount = _fixture.Build<Account>()
                                        .Without(x => x.TestAccounts)
                                        .Without(x => x.Role).With(x => x.Id, id).Create();

            _unitOfWorkMock
                .Setup(x => x.AccountRepository.GetByIdAsync(id)).ReturnsAsync(mockAccount);

            mockAccount.IsBlock = true;

            _unitOfWorkMock.Setup(x => x.AccountRepository.Update(mockAccount));

            _unitOfWorkMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(0);
            //act

            var result = await _adminService.BlockAccountAsync(id);

            //assert
            Assert.False(result);
        }
        [Fact]
        public async void BlockAccountAsync_WhenAccountNull()
        {
            //arrange
            var id = It.IsAny<int>();

            var mockAccount = _fixture.Build<Account>()
                                        .Without(x => x.TestAccounts)
                                        .Without(x => x.Role).With(x => x.Id, id).Create();

            _unitOfWorkMock
                .Setup(x => x.AccountRepository.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(mockAccount);

            //act

            var result = await _adminService.BlockAccountAsync(id);

            //assert
            Assert.False(result);
        }
        [Fact]
        public async void GetAccountsAsync_ReturnList_Test()
        {
            //arrange
            var mockRole = _fixture.Build<Role>().Without(x => x.Accounts).Create();

            var mockAccounts = _fixture.Build<Account>()
                .Without(x => x.TestAccounts)
                .With(x => x.Role, mockRole)
                .CreateMany(10).ToList();

            _unitOfWorkMock
                .Setup(x => x.AccountRepository.GetAllWithRoleNameAsync()).ReturnsAsync(mockAccounts);

            var map = _mapper.Map<List<GetAccount>>(mockAccounts);

            //act
            var result = await _adminService.GetAccountsAsync();

            //assert1
            _unitOfWorkMock.Verify(x => x.AccountRepository, Times.Once());
            result.Should().BeEquivalentTo(map);
        }
        [Fact]
        public async void GetAccountsAsync_ReturnNull_Test()
        {
            //arrange
            var mockRole = _fixture.Build<Role>().Without(x => x.Accounts).Create();

            var mockAccounts = _fixture.Build<Account>()
                .Without(x => x.TestAccounts)
                .With(x => x.Role, mockRole)
                .CreateMany(0).ToList();
            
            _unitOfWorkMock
                .Setup(x => x.AccountRepository.GetAllWithRoleNameAsync()).ReturnsAsync(mockAccounts);

            var map = _mapper.Map<List<GetAccount>>(mockAccounts);

            //act
            var result = await _adminService.GetAccountsAsync();

            //assert1
            _unitOfWorkMock.Verify(x => x.AccountRepository, Times.Once());
            result.Should().BeEquivalentTo(map);
        }
        [Fact]
        public async void GetReportTestAsync_WhenTestNull_Test()
        {
            //arrange
           var id = It.IsAny<int>();
          
            _unitOfWorkMock
                .Setup(x => x.TestRepository.GetByIdAsync(id)).ReturnsAsync(new Test());

            //act
            var result = await _adminService.GetReportTestAsync(1);

            //assert1
            _unitOfWorkMock.Verify(x => x.TestRepository, Times.Once());
            result.Should().BeNull();
        }
        [Fact]
        public async void GetReportTestAsync_WhenTestNotNull_Test()
        {
            //arrange
            var id = It.IsAny<int>();

            var mockTest = _fixture.Build<Test>()
                .Without(x => x.TestAccounts)
                .Without(x => x.TestQuestions)
                .With(x => x.Id, id)
                .Create();

            _unitOfWorkMock.Setup(x => x.TestRepository.GetByIdAsync(id)).ReturnsAsync(mockTest);

            var report = _mapper.Map<GetReportTest>(mockTest);

            var mockAccountsReport = _fixture.Build<GetAccountReport>()
                                            .CreateMany(10).ToList();

            //_unitOfWorkMock.Setup(x => x.TestAccountRepository
            //                            .GetAccountsByTestIdAsync(id))
            //                            .ReturnsAsync(mockAccountsReport);

            report.AccountReports = mockAccountsReport;

            //act
            var result = await _adminService.GetReportTestAsync(id);

            //assert1
            result.Should().BeEquivalentTo(report);
        }
        [Fact]
        public async void GetReportTestAsync_WhenTestNotAccount_Test()
        {
            //arrange
            var id = It.IsAny<int>();

            var mockTest = _fixture.Build<Test>()
                .Without(x => x.TestAccounts)
                .Without(x => x.TestQuestions)
                .With(x => x.Id, id)
                .Create();

            _unitOfWorkMock.Setup(x => x.TestRepository.GetByIdAsync(id)).ReturnsAsync(mockTest);

            var report = _mapper.Map<GetReportTest>(mockTest);

            var mockAccountsReport = _fixture.Build<GetAccountReport>()
                                            .CreateMany(0).ToList();

            //_unitOfWorkMock.Setup(x => x.TestAccountRepository
            //                            .GetAccountsByTestIdAsync(id))
            //                            .ReturnsAsync(mockAccountsReport);

            report.AccountReports = mockAccountsReport;

            //act
            var result = await _adminService.GetReportTestAsync(id);

            //assert1
            result.Should().BeEquivalentTo(report);
        }
    }
}
