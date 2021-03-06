﻿using ProjectManager.BusinessLayer.BusinessEntities;
using System.Collections.Generic;

namespace ProjectManager.BusinessLayer
{
    public interface IProjectManagerService
    {
        List<TaskEntity> GetAllTasks();
        TaskEntity GetTaskById(int id);
        bool UpdateTask(TaskEntity taskEntity);
        bool DeleteTask(int id);
        int AddTask(TaskEntity taskEntity);
        bool EndTask(int taskId);

        List<TaskEntity> GetAllParentTasks();
        TaskEntity GetParentTaskById(int id);
        int AddParentTask(TaskEntity taskEntity);
        bool UpdateParentTask(TaskEntity taskEntity);
        bool DeleteParentTask(int id);

        List<ProjectEntity> GetAllProject();
        ProjectEntity GetProjectById(int id);
        bool UpdateProject(ProjectEntity project);
        bool DeleteProject(int id);
        int AddProject(ProjectEntity projectEntity);
        bool SuspendProject(int projectId);

        List<UserEntity> GetAllUsers();
        UserEntity GetUserById(int id);
        bool UpdateUser(UserEntity user);
        bool DeleteUser(int id);
        int AddUser(UserEntity userEntity);
    }
}
