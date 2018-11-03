using Moq;
using NUnit.Framework;
using ProjectManager.BusinessLayer;
using ProjectManager.BusinessLayer.BusinessEntities;
using ProjectManager.BusinessLayer.Mapper;
using ProjectManager.DataLayer;
using ProjectManager.DataLayer.Repository;
using ProjectManager.Entities;
using System.Data.Entity;
using System.Linq;

namespace ProjectManager.Tests.BusinessLayer
{
    [TestFixture]
    public class ProjectManagerServiceTests
    {
        readonly IProjectManagerService _mockProjectManagerService;

        public ProjectManagerServiceTests()
        {
            var taskList = TestDataHelper.GetTaskList();
            var taskObject = TestDataHelper.GetTask();
            var dbSetMockTask = new Mock<DbSet<Task>>();

            dbSetMockTask.Setup(x => x.Find(It.IsAny<int>())).Returns(taskObject);
            dbSetMockTask.Setup(x => x.Add(It.IsAny<Task>())).Returns(taskObject);
            dbSetMockTask.Setup(x => x.Remove(It.IsAny<Task>())).Returns(taskObject);

            dbSetMockTask.As<IQueryable<Task>>().Setup(x => x.Provider).Returns
                                                 (taskList.AsQueryable().Provider);
            dbSetMockTask.As<IQueryable<Task>>().Setup(x => x.Expression).
                                                 Returns(taskList.AsQueryable().Expression);
            dbSetMockTask.As<IQueryable<Task>>().Setup(x => x.ElementType).Returns
                                                 (taskList.AsQueryable().ElementType);
            dbSetMockTask.As<IQueryable<Task>>().Setup(x => x.GetEnumerator()).Returns
                                                 (taskList.AsQueryable().GetEnumerator());

            var dbSetMockUser = new Mock<DbSet<User>>();
            var userList = TestDataHelper.GetUserList();
            var userObject = TestDataHelper.GetUser();

            dbSetMockUser.Setup(x => x.Find(It.IsAny<int>())).Returns(userObject);
            dbSetMockUser.Setup(x => x.Add(It.IsAny<User>())).Returns(userObject);
            dbSetMockUser.Setup(x => x.Remove(It.IsAny<User>())).Returns(userObject);

            dbSetMockUser.As<IQueryable<User>>().Setup(x => x.Provider).Returns
                                                 (userList.AsQueryable().Provider);
            dbSetMockUser.As<IQueryable<User>>().Setup(x => x.Expression).
                                                 Returns(userList.AsQueryable().Expression);
            dbSetMockUser.As<IQueryable<User>>().Setup(x => x.ElementType).Returns
                                                 (userList.AsQueryable().ElementType);
            dbSetMockUser.As<IQueryable<User>>().Setup(x => x.GetEnumerator()).Returns
                                                 (userList.AsQueryable().GetEnumerator());

            var dbSetMockProject = new Mock<DbSet<Project>>();
            var projectList = TestDataHelper.GetProjectList();
            var projectObject = TestDataHelper.GetProject();

            dbSetMockProject.Setup(x => x.Find(It.IsAny<int>())).Returns(projectObject);
            dbSetMockProject.Setup(x => x.Add(It.IsAny<Project>())).Returns(projectObject);
            dbSetMockProject.Setup(x => x.Remove(It.IsAny<Project>())).Returns(projectObject);

            dbSetMockProject.As<IQueryable<Project>>().Setup(x => x.Provider).Returns
                                                 (projectList.AsQueryable().Provider);
            dbSetMockProject.As<IQueryable<Project>>().Setup(x => x.Expression).
                                                 Returns(projectList.AsQueryable().Expression);
            dbSetMockProject.As<IQueryable<Project>>().Setup(x => x.ElementType).Returns
                                                 (projectList.AsQueryable().ElementType);
            dbSetMockProject.As<IQueryable<Project>>().Setup(x => x.GetEnumerator()).Returns
                                                 (projectList.AsQueryable().GetEnumerator());

            var context = new Mock<ProjectManagerContext>();
            context.Setup(x => x.Set<Task>()).Returns(dbSetMockTask.Object);
            context.Setup(x => x.Set<User>()).Returns(dbSetMockUser.Object);
            context.Setup(x => x.Set<Project>()).Returns(dbSetMockProject.Object);

            // Act
            var taskRepository = new Repository<Task>(context.Object);
            var parentTaskRepository = new Repository<ParentTask>(context.Object);
            var userRepository = new Repository<User>(context.Object);
            var projectRepository = new Repository<Project>(context.Object);
            _mockProjectManagerService = new ProjectManagerService(taskRepository, projectRepository, userRepository, parentTaskRepository);
        }

        [Test]
        public void When_GetAllTasks_Then_VerifyResult()
        {
            var taskList = _mockProjectManagerService.GetAllTasks();

            Assert.NotNull(taskList);
            Assert.AreEqual(taskList.Count, 1);
        }

        [Test]
        public void When_GetAllUsers_Then_VerifyResult()
        {
            var userList = _mockProjectManagerService.GetAllUsers();

            Assert.NotNull(userList);
            Assert.AreEqual(userList.Count, 1);
        }

        [Test]
        public void When_GetAllProjects_Then_VerifyResult()
        {
            var projects = _mockProjectManagerService.GetAllProject();

            Assert.NotNull(projects);
            Assert.AreEqual(projects.Count, 1);
        }

        [Test]
        public void When_GetProjectById_Then_VerifyResult()
        {
            var projects = _mockProjectManagerService.GetProjectById(1);

            Assert.NotNull(projects);
        }

        [Test]
        public void When_GetUserById_Then_VerifyResult()
        {
            var users = _mockProjectManagerService.GetUserById(1);

            Assert.NotNull(users);
        }

        [Test]
        public void When_GetTaskById_Then_VerifyResult()
        {
            var tasks = _mockProjectManagerService.GetTaskById(1);

            Assert.NotNull(tasks);
        }

        [Test]
        public void When_DeleteTask_Then_VerifyResult()
        {
            var tasks = _mockProjectManagerService.DeleteTask(1);

            Assert.NotNull(tasks);
        }

        [Test]
        public void When_DeleteUser_Then_VerifyResult()
        {
            var tasks = _mockProjectManagerService.DeleteUser(1);

            Assert.NotNull(tasks);
        }

        [Test]
        public void When_DeleteProject_Then_VerifyResult()
        {
            var tasks = _mockProjectManagerService.DeleteProject(1);

            Assert.NotNull(tasks);
        }

        [Test]
        public void When_AddProject_Then_VerifyResult()
        {
            var projectModel = TestDataHelper.GetProject().Map();
            var project = _mockProjectManagerService.AddProject(projectModel);

            Assert.NotNull(project);
        }

        [Test]
        public void When_UpdateProject_Then_VerifyResult()
        {
            var projectModel = TestDataHelper.GetProject().Map();
            var project = _mockProjectManagerService.UpdateProject(projectModel);

            Assert.NotNull(project);
        }

        [Test]
        public void When_AddUser_Then_VerifyResult()
        {
            var userModel = TestDataHelper.GetUser().Map();
            var user = _mockProjectManagerService.AddUser(userModel);

            Assert.NotNull(user);
        }

        [Test]
        public void When_UpdateUser_Then_VerifyResult()
        {
            var userModel = TestDataHelper.GetUser().Map();
            var user = _mockProjectManagerService.UpdateUser(userModel);

            Assert.NotNull(user);
        }

        [Test]
        public void When_AddTask_Then_VerifyResult()
        {
            var taskModel = TestDataHelper.GetTask().Map();
            var task = _mockProjectManagerService.AddTask(taskModel);

            Assert.NotNull(task);
        }

        [Test]
        public void When_UpdateTask_Then_VerifyResult()
        {
            var taskModel = TestDataHelper.GetTask().Map();
            var task = _mockProjectManagerService.UpdateTask(taskModel);

            Assert.NotNull(task);
        }
    }
}
