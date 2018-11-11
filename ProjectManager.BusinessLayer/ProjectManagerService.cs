using System.Collections.Generic;
using System.Linq;
using ProjectManager.BusinessLayer.BusinessEntities;
using ProjectManager.BusinessLayer.Mapper;
using ProjectManager.DataLayer.Repository;
using ProjectManager.Entities;

namespace ProjectManager.BusinessLayer
{
    public class ProjectManagerService : IProjectManagerService
    {
        //public IUnitOfWork unitOfWork;
        public IRepository<Task> taskRepository;
        public IRepository<ParentTask> parentTaskRepository;
        public IRepository<Project> projectRepository;
        public IRepository<User> userRepository;

        //public ProjectManagerService(IUnitOfWork unitOfWork)
        //{
        //    this.unitOfWork = unitOfWork;
        //}

        public ProjectManagerService(IRepository<Task> taskRepository,
            IRepository<Project> projectRepository, IRepository<User> userRepository,
            IRepository<ParentTask> parentTaskRepository)
        {
            this.taskRepository = taskRepository;
            this.projectRepository = projectRepository;
            this.userRepository = userRepository;
            this.parentTaskRepository = parentTaskRepository;
        }

        public int AddProject(ProjectEntity projectEntity)
        {
            var projectModel = projectEntity.Map();
            var project = projectRepository.Add(projectModel);

            return project.ProjectId;
        }

        public int AddParentTask(TaskEntity taskEntity)
        {
            var parentTask = parentTaskRepository.Add(taskEntity.Map());
            return parentTask.ParentTaskId;

        }

        public int AddTask(TaskEntity taskEntity)
        {
            var insertedTask = taskRepository.Add(taskEntity.MapTask());
            return insertedTask.TaskId;
        }

        public int AddUser(UserEntity userEntity)
        {
            var user = userRepository.Add(userEntity.Map());
            return user.UserId;
        }

        public bool DeleteProject(int id)
        {
            var project = projectRepository.Get(id);
            projectRepository.Remove(project);

            return true;
        }

        public bool DeleteTask(int id)
        {
            var task = taskRepository.Get(id);
            taskRepository.Remove(task);

            return true;

        }

        public bool DeleteUser(int id)
        {
            var user = userRepository.Get(id);
            userRepository.Remove(user);

            return true;
        }

        public List<ProjectEntity> GetAllProject()
        {
            var projects = projectRepository.GetAll().ToList();
            var projectEntities = projects.Map();
            projectEntities.ForEach(x =>
            {
                var taskList = taskRepository.GetAll().ToList();
                x.NoOfTasks = taskList.Count(y => y.ProjectId == x.ProjectId);
                x.NoOfCompletedTasks = taskList.Count(y => y.ProjectId == x.ProjectId && y.TaskStatusId == 2);
            });
            return projectEntities;
        }

        public List<TaskEntity> GetAllTasks()
        {
            //var tasks = this.unitOfWork.TaskRepository.GetAll().ToList();
            var tasks = taskRepository.GetAll().ToList();
            var taskEntities = tasks.Map();

            taskEntities.ForEach(x =>
            {
                if (x.ParentTaskId.HasValue)
                {
                    var parentTask = parentTaskRepository.Get(x.ParentTaskId.Value);
                    if (parentTask != null)
                        x.ParentTaskName = parentTask.ParentTaskName;
                }
            });

            return taskEntities;
        }

        public List<TaskEntity> GetAllParentTasks()
        {
            var parentTasks = parentTaskRepository.GetAll().ToList();
            return parentTasks.Map();
        }

        public List<UserEntity> GetAllUsers()
        {
            var users = userRepository.GetAll().ToList();
            return users.Map();
        }

        public ProjectEntity GetProjectById(int id)
        {
            var project = projectRepository.Get(id);
            return project.Map();
        }

        public TaskEntity GetTaskById(int id)
        {
            var task = taskRepository.Get(id);
            var taskEntity = task.Map();
            if (taskEntity.ParentTaskId.HasValue)
            {
                var parentTask = parentTaskRepository.Get(taskEntity.ParentTaskId.Value);
                if (parentTask != null)
                    taskEntity.ParentTaskName = parentTask.ParentTaskName;
            }
            if(taskEntity.ProjectId.HasValue)
            {
                var project = projectRepository.Get(taskEntity.ProjectId.Value);
                if(project!=null)
                {
                    taskEntity.ProjectName = project.ProjectName;
                }
            }
            if (taskEntity.UserId.HasValue)
            {
                var user = userRepository.Get(taskEntity.UserId.Value);
                if(user!=null)
                {
                    taskEntity.UserName = user.FirstName + " " + user.LastName;
                }
            }
            return taskEntity;
        }

        public TaskEntity GetParentTaskById(int id)
        {
            var parentTask = parentTaskRepository.Get(id);
            return parentTask.Map();
        }

        public UserEntity GetUserById(int id)
        {
            var user = userRepository.Get(id);
            return user.Map();
        }

        public bool UpdateProject(ProjectEntity project)
        {
            var proj = projectRepository.Get(project.ProjectId);
            var projectModel = project.Map(proj);
            //if(project.ManagerId.HasValue)
            //    projectModel.User = userRepository.Get(project.ManagerId.Value);
            projectRepository.Update(projectModel);

            return true;

        }

        public bool UpdateTask(TaskEntity taskEntity)
        {
            var taskModel = taskRepository.Get(taskEntity.TaskId);
            taskRepository.Update(taskEntity.Map(taskModel));

            return true;
        }

        public bool EndTask(int taskId)
        {
            var taskModel = taskRepository.Get(taskId);
            taskModel.TaskStatusId = 2;
            taskRepository.Update(taskModel);

            return true;
        }

        public bool UpdateParentTask(TaskEntity taskEntity)
        {
            var taskModel = parentTaskRepository.Get(taskEntity.TaskId);
            parentTaskRepository.Update(taskEntity.Map(taskModel));

            return true;
        }

        public bool UpdateUser(UserEntity user)
        {
            var userModel = userRepository.Get(user.UserId);
            userRepository.Update(user.Map(userModel));

            return true;
        }
    }
}
