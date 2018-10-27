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
        public IRepository<Project> projectRepository;
        public IRepository<User> userRepository;

        //public ProjectManagerService(IUnitOfWork unitOfWork)
        //{
        //    this.unitOfWork = unitOfWork;
        //}

        public ProjectManagerService(IRepository<Task> taskRepository, 
            IRepository<Project> projectRepository, IRepository<User> userRepository)
        {
            this.taskRepository = taskRepository;
            this.projectRepository = projectRepository;
            this.userRepository = userRepository;
        }

        public int AddProject(ProjectEntity projectEntity)
        {
            //var project = this.unitOfWork.ProjectRepository.Add(projectEntity.Map());
            var project = projectRepository.Add(projectEntity.Map());
            return project.ProjectId;
        }

        public int AddTask(TaskEntity taskEntity)
        {
            var insertedTask = taskRepository.Add(taskEntity.Map());
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
            //var projects = this.unitOfWork.ProjectRepository.GetAll().ToList();
            var projects = projectRepository.GetAll().ToList();
            return projects.Map();
        }

        public List<TaskEntity> GetAllTasks()
        {
            //var tasks = this.unitOfWork.TaskRepository.GetAll().ToList();
            var tasks = taskRepository.GetAll().ToList();
            return tasks.Map();
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
            return task.Map();
        }

        public UserEntity GetUserById(int id)
        {
            var user = userRepository.Get(id);
            return user.Map();
        }

        public bool UpdateProject(ProjectEntity project)
        {
            var proj = projectRepository.Get(project.ProjectId);
            projectRepository.Update(project.Map(proj));

            return true;

        }

        public bool UpdateTask(TaskEntity taskEntity)
        {
            var taskModel = taskRepository.Get(taskEntity.TaskId);
            taskRepository.Update(taskEntity.Map(taskModel));

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
