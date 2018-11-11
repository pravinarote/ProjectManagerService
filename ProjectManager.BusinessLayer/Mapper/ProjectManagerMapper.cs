using ProjectManager.BusinessLayer.BusinessEntities;
using ProjectManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManager.BusinessLayer.Mapper
{
    public static class ProjectManagerMapper
    {
        public static Task Map(this TaskEntity taskEntity, Task task)
        {
            task.TaskName = taskEntity.TaskName;
            task.Priority = taskEntity.Priority.Value;
            task.StartDate = taskEntity.StartDate.Value;
            task.EndDate = taskEntity.EndDate.Value;
            task.TaskStatusId = taskEntity.IsTaskEnded ? 2 : 1;
            task.ParentTaskId = taskEntity.ParentTaskId;
            task.ProjectId = taskEntity.ProjectId;
            task.UserId = taskEntity.UserId;
            return task;
        }

        public static ParentTask Map(this TaskEntity taskEntity, ParentTask parentTask)
        {
            parentTask.ParentTaskName = taskEntity.TaskName;
            return parentTask;
        }

        public static ParentTask Map(this TaskEntity taskEntity)
        {
            ParentTask parentTask = new ParentTask();
            parentTask.ParentTaskId = taskEntity.TaskId;
            parentTask.ParentTaskName = taskEntity.TaskName;
            return parentTask;
        }

        public static Task MapTask(this TaskEntity taskEntity)
        {
            var task = new Task();

            task.TaskId = taskEntity.TaskId;
            task.TaskName = taskEntity.TaskName;
            task.Priority = taskEntity.Priority.Value;
            task.StartDate = taskEntity.StartDate.Value;
            task.EndDate = taskEntity.EndDate.Value;
            task.TaskStatusId = taskEntity.IsTaskEnded ? 2 : 1;
            task.ParentTaskId = taskEntity.ParentTaskId;
            task.ProjectId = taskEntity.ProjectId;
            task.UserId = taskEntity.UserId;

            return task;
        }

        public static TaskEntity Map(this Task task)
        {
            var taskEntity = new TaskEntity();

            taskEntity.TaskId = task.TaskId;
            taskEntity.TaskName = task.TaskName;
            if (task.ParentTask != null)
            {
                taskEntity.ParentTaskId = task.ParentTask.ParentTaskId;
                taskEntity.ParentTaskName = task.ParentTask.ParentTaskName;
            }
            taskEntity.Priority = task.Priority;
            taskEntity.StartDate = task.StartDate;
            taskEntity.EndDate = task.EndDate;
            taskEntity.IsTaskEnded = task.TaskStatusId == 2;
            if (task.Project != null)
            {
                taskEntity.ProjectId = task.Project.ProjectId;
                taskEntity.ProjectName = task.Project.ProjectName;
            }
            if (task.User != null)
            {
                taskEntity.UserId = task.User.UserId;
                taskEntity.UserName = task.User.FirstName + " " + task.User.LastName;
            }

            if (task.TaskStatus != null)
            {
                taskEntity.TaskStatusEntity = new TaskStatusEntity() { Id = task.TaskStatus.Id, Name = task.TaskStatus.Name };
            }

            return taskEntity;
        }

        public static TaskEntity Map(this ParentTask parentTask)
        {
            var taskEntity = new TaskEntity();
            taskEntity.TaskId = parentTask.ParentTaskId;
            taskEntity.TaskName = parentTask.ParentTaskName;

            return taskEntity;
        }

        public static List<TaskEntity> Map(this List<ParentTask> parentTaskList)
        {
            var taskEntityList = new List<TaskEntity>();

            parentTaskList.ForEach(parentTask =>
            {
                var taskEntity = new TaskEntity();
                taskEntity.TaskId = parentTask.ParentTaskId;
                taskEntity.TaskName = parentTask.ParentTaskName;

                taskEntityList.Add(taskEntity);
            });

            return taskEntityList;
        }

        public static List<TaskEntity> Map(this List<Task> taskList)
        {
            var taskEntityList = new List<TaskEntity>();

            taskList.ForEach(task =>
            {
                var taskEntity = new TaskEntity();

                taskEntity.TaskId = task.TaskId;
                taskEntity.TaskName = task.TaskName;
                taskEntity.ParentTaskId = task.ParentTaskId;
                taskEntity.Priority = task.Priority;
                taskEntity.StartDate = task.StartDate;
                taskEntity.EndDate = task.EndDate;
                taskEntity.IsTaskEnded = task.TaskStatusId == 2;
                taskEntity.ProjectId = task.ProjectId;
                taskEntity.UserId = task.UserId;
                if (task.TaskStatus != null)
                {
                    taskEntity.TaskStatusEntity = new TaskStatusEntity() { Id = task.TaskStatus.Id, Name = task.TaskStatus.Name };
                }

                taskEntityList.Add(taskEntity);
            });

            return taskEntityList;
        }

        public static Project Map(this ProjectEntity projectEntity, Project project)
        {
            project.ProjectName = projectEntity.ProjectName;
            project.Priority = projectEntity.Priority;
            project.StartDate = projectEntity.StartDate;
            project.EndDate = projectEntity.EndDate;
            project.UserId = projectEntity.ManagerId;
            //if(projectEntity.ManagerId.HasValue)
            //project.User = new User() { UserId = projectEntity.ManagerId.Value };
            //if (projectEntity.User != null)
            //    project.UserId = projectEntity.User.UserId;

            return project;
        }

        public static Project Map(this ProjectEntity projectEntity)
        {
            var project = new Project();
            project.ProjectId = projectEntity.ProjectId;
            project.ProjectName = projectEntity.ProjectName;
            project.Priority = projectEntity.Priority;
            project.StartDate = projectEntity.StartDate;
            project.EndDate = projectEntity.EndDate;
            project.UserId = projectEntity.ManagerId;
            //if (projectEntity.User != null)

            //if (projectEntity.ManagerId.HasValue)
            //    project.User = new User() { UserId = projectEntity.ManagerId.Value };

            return project;
        }

        public static ProjectEntity Map(this Project project)
        {
            var projectEntity = new ProjectEntity();
            projectEntity.ProjectId = project.ProjectId;
            projectEntity.ProjectName = project.ProjectName;
            projectEntity.Priority = project.Priority;
            projectEntity.StartDate = project.StartDate;
            projectEntity.EndDate = project.EndDate;
            projectEntity.ManagerId = project.UserId;
            if (project.User != null)
            {
                projectEntity.ManagerId = project.User.UserId;
                projectEntity.ManagerName = project.User.FirstName + " " + project.User.LastName;
            }

            return projectEntity;
        }

        public static List<ProjectEntity> Map(this List<Project> projectList)
        {
            var projectEntityList = new List<ProjectEntity>();

            projectList.ForEach(project =>
            {
                var projectEntity = new ProjectEntity();
                projectEntity.ProjectId = project.ProjectId;
                projectEntity.ProjectName = project.ProjectName;
                projectEntity.Priority = project.Priority;
                projectEntity.StartDate = project.StartDate;
                projectEntity.EndDate = project.EndDate;
                projectEntity.ManagerId = project.UserId;

                if (project.User != null)
                {
                    projectEntity.ManagerId = project.User.UserId;
                    projectEntity.ManagerName = project.User.FirstName + " " + project.User.LastName;
                }

                projectEntityList.Add(projectEntity);
            });

            return projectEntityList;
        }

        public static User Map(this UserEntity userEntity, User user)
        {
            user.EmployeeId = userEntity.EmployeeId;
            user.FirstName = userEntity.FirstName;
            user.LastName = userEntity.LastName;
            //if (userEntity.Project != null)
            //    user.ProjectId = userEntity.Project.ProjectId;
            //if (userEntity.Task != null)
            //    user.TaskId = userEntity.Task.TaskId;

            return user;
        }

        public static User Map(this UserEntity userEntity)
        {
            User user = new User();
            user.EmployeeId = userEntity.EmployeeId;
            user.FirstName = userEntity.FirstName;
            user.LastName = userEntity.LastName;
            //if (userEntity.Project != null)
            //    user.ProjectId = userEntity.Project.ProjectId;
            //if (userEntity.Task != null)
            //    user.TaskId = userEntity.Task.TaskId;

            return user;
        }

        public static UserEntity Map(this User user)
        {
            var userEntity = new UserEntity();
            userEntity.UserId = user.UserId;
            userEntity.EmployeeId = user.EmployeeId;
            userEntity.FirstName = user.FirstName;
            userEntity.LastName = user.LastName;
            //if (user.Project != null)
            //    userEntity.Project = new ProjectEntity() { ProjectId = user.ProjectId.Value };
            //if (user.Task != null)
            //    userEntity.Task = new TaskEntity() { TaskId = user.TaskId.Value };

            return userEntity;
        }

        public static List<UserEntity> Map(this List<User> userList)
        {
            var userEntityList = new List<UserEntity>();
            userList.ForEach(user =>
            {
                var userEntity = new UserEntity();
                userEntity.UserId = user.UserId;
                userEntity.EmployeeId = user.EmployeeId;
                userEntity.FirstName = user.FirstName;
                userEntity.LastName = user.LastName;
                //if (user.Project != null)
                //    userEntity.Project = new ProjectEntity() { ProjectId = user.ProjectId.Value };
                //if (user.Task != null)
                //    userEntity.Task = new TaskEntity() { TaskId = user.TaskId.Value };

                userEntityList.Add(userEntity);
            });

            return userEntityList;
        }

    }
}
