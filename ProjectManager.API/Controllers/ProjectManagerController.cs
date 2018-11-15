using ProjectManager.BusinessLayer;
using ProjectManager.BusinessLayer.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectManager.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectManagerController : ApiController
    {
        public IProjectManagerService projectManagerService;
        public ProjectManagerController(IProjectManagerService projectManagerService)
        {
            this.projectManagerService = projectManagerService;
        }
        // GET: api/ProjectManager
        [HttpGet]
        [Route("Tasks/GetAll")]
        public IHttpActionResult GetAllTasks()
        {
            var parentTasks = projectManagerService.GetAllParentTasks();
            var tasks = projectManagerService.GetAllTasks();
            parentTasks.AddRange(tasks);
            return Ok(parentTasks);
        }

        [HttpGet]
        [Route("ParentTasks/GetAll")]
        public IHttpActionResult GetAllParentTasks()
        {
            return Ok(projectManagerService.GetAllParentTasks());
        }

        [HttpGet]
        [Route("Projects/GetAll")]
        public IHttpActionResult GetAllProjects()
        {
            return Ok(projectManagerService.GetAllProject());
        }

        [HttpGet]
        [Route("Users/GetAll")]
        public IHttpActionResult GetAllUsers()
        {
            return Ok(projectManagerService.GetAllUsers());
        }

        [Route("Tasks/GetById/{id}")]
        [HttpGet]
        public IHttpActionResult GetTaskById(int id)
        {
            return Ok(projectManagerService.GetTaskById(id));
        }

        [Route("ParentTasks/GetById/{id}")]
        [HttpGet]
        public IHttpActionResult GetParentTaskById(int id)
        {
            return Ok(projectManagerService.GetParentTaskById(id));
        }

        [Route("Projects/GetById/{id}")]
        [HttpGet]
        public IHttpActionResult GetProjectById(int id)
        {
            return Ok(projectManagerService.GetProjectById(id));
        }

        [Route("Users/GetById/{id}")]
        [HttpGet]
        public IHttpActionResult GetUserById(int id)
        {
            return Ok(projectManagerService.GetUserById(id));
        }

        [Route("Tasks/Create")]
        [HttpPost]
        public IHttpActionResult AddTask([FromBody]TaskEntity taskEntity)
        {
            return Ok(projectManagerService.AddTask(taskEntity));
        }

        [Route("ParentTasks/Create")]
        [HttpPost]
        public IHttpActionResult AddParentTask([FromBody]TaskEntity taskEntity)
        {
            return Ok(projectManagerService.AddParentTask(taskEntity));
        }

        [Route("Projects/Create")]
        [HttpPost]
        public IHttpActionResult CreateProject([FromBody]ProjectEntity entity)
        {
            return Ok(projectManagerService.AddProject(entity));
        }

        [Route("Users/Create")]
        [HttpPost]
        public IHttpActionResult CreateUser([FromBody]UserEntity entity)
        {
            return Ok(projectManagerService.AddUser(entity));
        }

        [Route("ParentTasks/Update")]
        [HttpPut]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult UpdateParentTask([FromBody]TaskEntity taskEntity)
        {
            if (taskEntity.TaskId > 0)
            {
                return Ok(projectManagerService.UpdateParentTask(taskEntity));
            }
            return Ok(false);
        }

        [Route("Tasks/Update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPut]
        public IHttpActionResult UpdateTask([FromBody]TaskEntity taskEntity)
        {
            if (taskEntity.TaskId > 0)
            {
                return Ok(projectManagerService.UpdateTask(taskEntity));
            }
            return Ok(false);
        }

        [Route("Projects/Update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPut]
        public IHttpActionResult UpdateProject([FromBody]ProjectEntity entity)
        {
            if (entity.ProjectId > 0)
            {
                return Ok(projectManagerService.UpdateProject(entity));
            }
            return Ok(false);
        }

        [Route("Users/Update")]
        [HttpPut]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult UpdateUser([FromBody]UserEntity entity)
        {
            if (entity.UserId > 0)
            {
                return Ok(projectManagerService.UpdateUser(entity));
            }
            return Ok(false);
        }

        [Route("Tasks/End/{id}")]
        public IHttpActionResult EndTask(int id)
        {
            return Ok(projectManagerService.EndTask(id));
        }

        [Route("Projects/Suspend/{id}")]
        public IHttpActionResult SuspendProject(int id)
        {
            return Ok(projectManagerService.SuspendProject(id));
        }

        [Route("Tasks/Delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteTask(int id)
        {
            return Ok(projectManagerService.DeleteTask(id));
        }

        [Route("ParentTasks/Delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteParentTask(int id)
        {
            return Ok(projectManagerService.DeleteParentTask(id));
        }

        [Route("Projects/Delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteProject(int id)
        {
            return Ok(projectManagerService.DeleteProject(id));
        }

        [Route("Users/Delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            return Ok(projectManagerService.DeleteUser(id));
        }


    }
}
