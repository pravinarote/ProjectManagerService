using ProjectManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManager.Tests
{
    public static class TestDataHelper
    {
        public static Task GetTask()
        {
            return new Task()
            {
                TaskName = "Task 15",
                Priority = 13,
                StartDate = new DateTime(2009, 10, 01),
                EndDate = new DateTime(2019, 10, 01),
                ParentTaskId = null,
                ParentTask = new ParentTask() { ParentTaskId = 1, ParentTaskName = "Task" },
                TaskStatus = new TaskStatus() { Id = 1, Name = "Started" },
                ProjectId = 1,
                Project = new Project() { ProjectId = 1, ProjectName = "Test Project" }
            };
        }

        public static List<Task> GetTaskList()
        {
            return new List<Task>() { GetTask() };
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
                ProjectId = 1,
                Project = new Project()
                {
                    ProjectId = 1,
                    ProjectName = "Trtafigura",
                    StartDate = DateTime.Now.AddDays(-20),
                    EndDate = DateTime.Now,
                    Priority = 6,
                },
                TaskId = 1,
                Task = new Task()
                {
                    TaskName = "Task 15",
                    Priority = 13,
                    StartDate = new DateTime(2009, 10, 01),
                    EndDate = new DateTime(2019, 10, 01),
                    ParentTaskId = null,
                    ParentTask = new ParentTask() { ParentTaskId = 1, ParentTaskName = "Task" },
                    TaskStatus = new TaskStatus() { Id = 1, Name = "Started" },
                    ProjectId = 1,
                    Project = new Project() { ProjectId = 1, ProjectName = "Test Project" }
                }
            };
        }

        public static List<User> GetUserList()
        {
            return new List<User>() { GetUser() };
        }
    }
}
