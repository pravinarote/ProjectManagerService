using NUnit.Framework;
using ProjectManager.BusinessLayer.Mapper;
using ProjectManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManager.Tests.BusinessLayer
{
    [TestFixture]
    public class ProjectManagerMapperTest
    {
        [Test]
        public void VerifyTaskMapperOperations()
        {
            var task = TestDataHelper.GetTask();
            var taskEntity = task.Map();
            Assert.NotNull(taskEntity);
            Assert.AreEqual(taskEntity.TaskName, task.TaskName);

            task.ParentTask = null;
            task.TaskStatusId = null;
            task.ProjectId = null;
            task.TaskStatus = null;
            taskEntity = task.Map();
            task.TaskStatusId = 1;
            taskEntity = task.Map();
            taskEntity.IsTaskEnded = false;
            task.TaskStatusId = 2;
            taskEntity = task.Map();
            taskEntity.IsTaskEnded = true;
            //taskEntity.Project = null;
            Assert.NotNull(taskEntity);
            Assert.AreEqual(taskEntity.TaskName, task.TaskName);

            var taskList = TestDataHelper.GetTaskList().ToList();

            var taskEntityList = taskList.Map().ToList();
            Assert.NotNull(taskEntityList);
            Assert.AreEqual(taskList.Count, taskEntityList.Count);


            var taskModel = taskEntity.Map(task);
            Assert.NotNull(taskModel);
            Assert.AreEqual(taskEntity.TaskName, taskModel.TaskName);

            task.ParentTask = null;
            task.TaskStatusId = 1;
            taskEntity.IsTaskEnded = false;
            taskModel = taskEntity.Map(task);

            taskModel = taskEntity.MapTask();
            Assert.NotNull(taskModel);

            task.ParentTask = null;
            task.TaskStatusId = 2;
            taskModel = taskEntity.MapTask();
            Assert.AreEqual(taskEntity.TaskName, taskModel.TaskName);
        }

        [Test]
        public void VerifyParentTaskMapperOperations()
        {
            var parentTask = TestDataHelper.GetParentTask();
            var entity = parentTask.Map();
            Assert.NotNull(parentTask);
            Assert.AreEqual(parentTask.ParentTaskName, entity.TaskName);

            var taskList = TestDataHelper.GetParentTaskList().ToList();
            var taskEntityList = taskList.Map().ToList();
            Assert.NotNull(taskEntityList);
            Assert.AreEqual(taskList.Count, taskEntityList.Count);
        }

        [Test]
        public void VerifyProjectMapperOperations()
        {
            var project = TestDataHelper.GetProject();
            var projectEntity = project.Map();
            Assert.NotNull(projectEntity);
            Assert.AreEqual(project.ProjectName, projectEntity.ProjectName);

            project.User = null;
            project.UserId = null;
            projectEntity = project.Map();
            Assert.NotNull(projectEntity);
            Assert.AreEqual(project.ProjectName, projectEntity.ProjectName);

            var projectList = TestDataHelper.GetProjectList();
            var projectEntityList = projectList.Map();
            Assert.NotNull(projectEntityList);
            Assert.AreEqual(projectList.Count, projectEntityList.Count);

            projectList = TestDataHelper.GetProjectList();
            var newProject = TestDataHelper.GetProject();
            project.User = null;
            projectList.Add(newProject);
            projectEntityList = projectList.Map();

            var projectModel = projectEntity.Map(project);
            Assert.NotNull(projectModel);
            Assert.AreEqual(projectEntity.ProjectName, projectModel.ProjectName);

            projectModel = projectEntity.Map();
            Assert.NotNull(projectModel);
            Assert.AreEqual(projectEntity.ProjectName, projectModel.ProjectName);

        }

        [Test]
        public void VerifyUserMapperOperations()
        {
            var user = TestDataHelper.GetUser();
            var userEntity = user.Map();
            Assert.NotNull(userEntity);
            Assert.AreEqual(user.FirstName, userEntity.FirstName);

            user = TestDataHelper.GetUser();
            //user.Task = null;
            //user.Project = null;
            userEntity = user.Map();
            Assert.NotNull(userEntity);
            Assert.AreEqual(user.FirstName, userEntity.FirstName);

            var userList = TestDataHelper.GetUserList();
            var userEntityList = userList.Map();
            //userEntity.Project = null;
            //user.Task = null;
            Assert.NotNull(userEntityList);
            Assert.AreEqual(userList.Count, userEntityList.Count);

            var userModel = userEntity.Map(user);
            Assert.NotNull(userModel);
            Assert.AreEqual(userEntity.LastName, userModel.LastName);

            userModel = userEntity.Map();
            Assert.NotNull(userModel);
            Assert.AreEqual(userEntity.LastName, userModel.LastName);
        }
    }
}
