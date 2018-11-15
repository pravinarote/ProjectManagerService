
using Moq;
using NUnit.Framework;
using ProjectManager.API.Controllers;
using ProjectManager.BusinessLayer;
using ProjectManager.BusinessLayer.BusinessEntities;
using ProjectManager.BusinessLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace ProjectManager.Tests.ServiceLayer
{
    [TestFixture]
    public class ProjectManagerControllerTests
    {
        readonly ProjectManagerController controller = null;
        public ProjectManagerControllerTests()
        {
            var service = this.Configure();
            controller = new ProjectManagerController(service.Object);
        }

        [Test]
        public void When_GetAllTasks_Then_ShouldReturnAllTasks()
        {
            var result = controller.GetAllTasks() as OkNegotiatedContentResult<List<TaskEntity>>;
            Assert.IsNotNull(result);
            //Assert.AreEqual(result.Content.Count, 2);
        }

        [Test]
        public void When_GetAllParentTasks_Then_ShouldReturnAllTasks()
        {
            var result = controller.GetAllParentTasks() as OkNegotiatedContentResult<List<TaskEntity>>;
            Assert.IsNotNull(result);
            //Assert.AreEqual(result.Content.Count, 1);
        }

        [Test]
        public void When_GetAllProjects_Then_ShouldReturnAllProjects()
        {
            var result = controller.GetAllProjects() as OkNegotiatedContentResult<List<ProjectEntity>>;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Count, 1);
        }

        [Test]
        public void When_GetAllUsers_Then_VerifyResults()
        {
            var result = controller.GetAllUsers() as OkNegotiatedContentResult<List<UserEntity>>;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Count, 1);
        }

        [Test]
        public void When_GetUserById_Then_VerifyResults()
        {
            var result = controller.GetUserById(1) as OkNegotiatedContentResult<UserEntity>;
            Assert.IsNotNull(result);
        }

        [Test]
        public void When_GetProjectById_Then_VerifyResults()
        {
            var result = controller.GetProjectById(1) as OkNegotiatedContentResult<ProjectEntity>;
            Assert.IsNotNull(result);
        }

        [Test]
        public void When_GetTaskById_Then_VerifyResults()
        {
            var result = controller.GetTaskById(1) as OkNegotiatedContentResult<TaskEntity>;
            Assert.IsNotNull(result);
        }

        [Test]
        public void When_GetParentTaskById_Then_VerifyResults()
        {
            var result = controller.GetParentTaskById(1) as OkNegotiatedContentResult<TaskEntity>;
            Assert.IsNotNull(result);
        }

        [Test]
        public void When_AddUser_Then_VerifyResults()
        {
            var user = TestDataHelper.GetUser().Map();
            var result = controller.CreateUser(user);
            Assert.NotNull(result);
        }

        [Test]
        public void When_AddProject_Then_VerifyResults()
        {
            var project = TestDataHelper.GetProject().Map();
            var result = controller.CreateProject(project);
            Assert.NotNull(result);
        }

        [Test]
        public void When_AddTask_Then_VerifyResults()
        {
            var project = TestDataHelper.GetTask().Map();
            var result = controller.AddTask(project);
            Assert.NotNull(result);
        }

        [Test]
        public void When_AddParentTask_Then_VerifyResults()
        {
            var project = TestDataHelper.GetTask().Map();
            var result = controller.AddParentTask(project);
            Assert.NotNull(result);
        }

        [Test]
        public void When_UpdateTask_Then_VerifyResults()
        {
            var project = TestDataHelper.GetTask().Map();
            project.TaskId = 10;
            var result = controller.UpdateTask(project);
            Assert.NotNull(result);

            project.TaskId = 0;
            result = controller.UpdateTask(project);
            Assert.NotNull(result);
        }

        [Test]
        public void When_EndTask_Then_VerifyResults()
        {
            var project = TestDataHelper.GetTask().Map();
            project.TaskId = 10;
            var result = controller.EndTask(project.TaskId);
            Assert.NotNull(result);
        }

        [Test]
        public void When_SuspendProject_Then_VerifyResults()
        {
            var result = controller.SuspendProject(1);
            Assert.NotNull(result);
        }

        [Test]
        public void When_UpdateParentTask_Then_VerifyResults()
        {
            var project = TestDataHelper.GetTask().Map();
            project.TaskId = 10;
            var result = controller.UpdateParentTask(project);
            Assert.NotNull(result);

            project.TaskId = 0;
            result = controller.UpdateParentTask(project);
            Assert.NotNull(result);
        }

        [Test]
        public void When_UpdateUser_Then_VerifyResults()
        {
            var project = TestDataHelper.GetUser().Map();
            var result = controller.UpdateUser(project);
            Assert.NotNull(result);

            project.UserId = 0;
            result = controller.UpdateUser(project);
            Assert.NotNull(result);
        }

        [Test]
        public void When_UpdateProject_Then_VerifyResults()
        {
            var project = TestDataHelper.GetProject().Map();
            var result = controller.UpdateProject(project);
            Assert.NotNull(result);

            project.ProjectId = 0;
            result = controller.UpdateProject(project);
            Assert.NotNull(result);
        }

        [Test]
        public void When_DeleteProject_Then_VerifyResults()
        {
            var result = controller.DeleteProject(1);
            Assert.NotNull(result);

            result = controller.DeleteProject(0);
            Assert.NotNull(result);
        }

        [Test]
        public void When_DeleteUser_Then_VerifyResults()
        {
            var result = controller.DeleteUser(1);
            Assert.NotNull(result);

            result = controller.DeleteUser(0);
            Assert.NotNull(result);
        }

        [Test]
        public void When_DeleteTask_Then_VerifyResults()
        {
            var result = controller.DeleteTask(1);
            Assert.NotNull(result);

            result = controller.DeleteTask(0);
            Assert.NotNull(result);
        }

        [Test]
        public void When_DeleteParentTask_Then_VerifyResults()
        {
            var result = controller.DeleteParentTask(1);
            Assert.NotNull(result);

            result = controller.DeleteParentTask(0);
            Assert.NotNull(result);
        }

        private Mock<IProjectManagerService> Configure()
        {
            Mock<IProjectManagerService> projectManagerService = new Mock<IProjectManagerService>();

            var taskList = TestDataHelper.GetTaskList().Map();
            projectManagerService.Setup(x => x.GetAllTasks()).Returns(taskList);
            projectManagerService.Setup(x => x.GetAllParentTasks()).Returns(taskList);
            projectManagerService.Setup(mr => mr.GetTaskById(It.IsAny<int>()));
            projectManagerService.Setup(mr => mr.GetParentTaskById(It.IsAny<int>()));

            projectManagerService.Setup(mr => mr.AddTask(It.IsAny<TaskEntity>())).Returns(
                (TaskEntity target) =>
                {
                    target.TaskId = 101;
                    return target.TaskId;
                });
            projectManagerService.Setup(mr => mr.AddParentTask(It.IsAny<TaskEntity>())).Returns(
                (TaskEntity target) =>
                {
                    target.TaskId = 101;
                    return target.TaskId;
                });
            projectManagerService.Setup(mr => mr.UpdateTask(It.IsAny<TaskEntity>())).Returns(true);
            projectManagerService.Setup(mr => mr.EndTask(It.IsAny<int>())).Returns(true);
            projectManagerService.Setup(mr => mr.SuspendProject(It.IsAny<int>())).Returns(true);
            projectManagerService.Setup(mr => mr.UpdateParentTask(It.IsAny<TaskEntity>())).Returns(true);
            projectManagerService.Setup(x => x.DeleteTask(It.IsAny<int>())).Returns(true);
            projectManagerService.Setup(x => x.DeleteParentTask(It.IsAny<int>())).Returns(true);

            var projectList = TestDataHelper.GetProjectList().Map();
            projectManagerService.Setup(x => x.GetAllProject()).Returns(projectList);
            projectManagerService.Setup(mr => mr.GetProjectById(
                It.IsAny<int>()));
            projectManagerService.Setup(mr => mr.AddProject(It.IsAny<ProjectEntity>())).Returns(
                (ProjectEntity target) =>
                {
                    target.ProjectId = 101;
                    return target.ProjectId;
                });
            projectManagerService.Setup(mr => mr.UpdateProject(It.IsAny<ProjectEntity>())).Returns(true);
            projectManagerService.Setup(x => x.DeleteProject(It.IsAny<int>())).Returns(true);

            var userList = TestDataHelper.GetUserList().Map();
            projectManagerService.Setup(x => x.GetAllUsers()).Returns(userList);
            projectManagerService.Setup(mr => mr.GetUserById(
                It.IsAny<int>()));
            projectManagerService.Setup(mr => mr.AddUser(It.IsAny<UserEntity>())).Returns(
                (UserEntity target) =>
                {
                    target.UserId = 101;
                    return target.UserId;
                });
            projectManagerService.Setup(mr => mr.UpdateUser(It.IsAny<UserEntity>())).Returns(true);
            projectManagerService.Setup(x => x.DeleteUser(It.IsAny<int>())).Returns(true);
            return projectManagerService;
        }
    }
}
