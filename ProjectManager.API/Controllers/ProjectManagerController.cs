using ProjectManager.BusinessLayer;
using ProjectManager.BusinessLayer.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManager.API.Controllers
{
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
            return Ok(projectManagerService.GetAllTasks());
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

        [Route("Tasks/Update")]
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
        public IHttpActionResult UpdateUser([FromBody]UserEntity entity)
        {
            if (entity.UserId > 0)
            {
                return Ok(projectManagerService.UpdateUser(entity));
            }
            return Ok(false);
        }

        [Route("Tasks/Delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteTask(int id)
        {
            return Ok(projectManagerService.DeleteTask(id));
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
