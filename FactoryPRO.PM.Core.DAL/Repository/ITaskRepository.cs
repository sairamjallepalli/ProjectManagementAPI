using FactoryPRO.PM.Core.Common;
using FactoryPRO.PM.Core.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPRO.PM.Core.DAL.Repository
{
    public interface ITaskRepository
    {
        List<TblTasks> GetTasksByUserID(string UserGUID);
        List<TblTasks> GetTasksByList(string ListID);
        List<TblTasks> GetTasksByProject(string ProjectID);
        TblTasks CreateTask(TblTasks task);
        TblTasks UpdateTask(TblTasks Task);
        bool DeleteTask(TblTasks task);
    }
}
