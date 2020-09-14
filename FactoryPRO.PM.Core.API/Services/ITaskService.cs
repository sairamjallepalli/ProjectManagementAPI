using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.Services
{
    public interface ITaskService
    {
        List<TaskDTO> GetTasksByUserID(int UserID);
        List<TaskDTO> GetTasksByList(string ListID);
        List<TaskDTO> GetTasksByProject(string ProjectID);
        bool CreateTask(TaskDTO Task);
        bool UpdateTask(TaskDTO Task);
        bool DeleteTask(TaskDTO task);
    }
}
