using ProjectManager.Entities;
using System;
using System.Collections.Generic;

namespace ProjectManager.Tests
{
    public static class TestDataHelper
    {
        public static Task GetTask()
        {
            return new Task()
            {
                TaskName = "Task 15",
                TaskId = 1,
                Priority = 13,
                StartDate = new DateTime(2009, 10, 01),
                EndDate = new DateTime(2019, 10, 01),
                ParentTaskId = 1,
                TaskStatusId = 2,
                ParentTask = new ParentTask() { ParentTaskId = 1, ParentTaskName = "Task" },
                TaskStatus = new TaskStatus() { Id = 2, Name = "Started" },
                ProjectId = 1,
                Project = new Project() { ProjectId = 1, ProjectName = "Test Project" },
                UserId = 1,
                User = GetUser() 
            };
        }

        public static Task GetTask1()
        {
            return new Task()
            {
                TaskName = "Task 15",
                TaskId = 2,
                Priority = 13,
                StartDate = new DateTime(2009, 10, 01),
                EndDate = new DateTime(2019, 10, 01),
                TaskStatusId = 1,
                ParentTaskId = 1,
                ParentTask = new ParentTask() { ParentTaskId = 1, ParentTaskName = "Task" },
                TaskStatus = new TaskStatus() { Id = 1, Name = "Started" },
                ProjectId = 1,
                Project = new Project() { ProjectId = 1, ProjectName = "Test Project" },
                User = GetUser()
            };
        }

        public static Task GetTask2()
        {
            return new Task()
            {
                TaskName = "Task 15",
                Priority = 13,
                TaskId = 3,
                StartDate = new DateTime(2009, 10, 01),
                EndDate = new DateTime(2019, 10, 01),
                TaskStatusId = 1,
                TaskStatus = new TaskStatus() { Id = 1, Name = "Started" },
            };
        }

        public static List<Task> GetTaskList()
        {
            return new List<Task>() { GetTask(), GetTask1(), GetTask2() };
        }

        public static ParentTask GetParentTask()
        {
            return new ParentTask() { ParentTaskId = 1, ParentTaskName = "Parent Task 1" };
        }

        public static List<ParentTask> GetParentTaskList()
        {
            return new List<ParentTask>() { GetParentTask() };
        }

        public static Project GetProject()
        {
            return new Project()
            {
                ProjectId = 1,
                ProjectName = "Trtafigura",
                StartDate = DateTime.Now.AddDays(-20),
                EndDate = DateTime.Now,
                Priority = 6,
                UserId = 1,
                User = GetUser(),
                IsSuspended = false,
                Tasks = GetTaskList()
            };
        }

        public static List<Project> GetProjectList()
        {
            return new List<Project>() { GetProject() };
        }

        public static User GetUser()
        {
            return new User()
            {
                UserId = 1,
                FirstName = "EMP 1",
                LastName = "LAST 1",
                EmployeeId = "EMP001",
            };
        }

        public static List<User> GetUserList()
        {
            return new List<User>() { GetUser() };
        }
    }
}
