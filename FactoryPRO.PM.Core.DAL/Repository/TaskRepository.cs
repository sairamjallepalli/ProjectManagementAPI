﻿using FactoryPRO.PM.Core.Common;
using FactoryPRO.PM.Core.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryPRO.PM.Core.DAL.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private ProjectContext _projectContext;
        public TaskRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<TblTasks> GetTasksByUserID(string UserGUID)
        {
            List<TblTasks> tasks = new List<TblTasks>();
            try
            {
                tasks = _projectContext.TblTasks.Where(m => m.Assignee == UserGUID).ToList();
            }
            catch (Exception ex)
            {
                //log
            }
            return tasks;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public TblTasks GetTasksByID(string TaskID)
        {
            TblTasks task = new TblTasks();
            try
            {
                task = _projectContext.TblTasks.Where(m => m.TaskId == TaskID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //log
            }
            return task;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<TblTasks> GetTasksByList(string ListID, String UserGUID)
        {
            List<TblTasks> tasks = new List<TblTasks>();
            try
            {
                tasks = _projectContext.TblTasks.Where(m => m.ListId == ListID && m.Assignee == UserGUID).ToList();
            }
            catch (Exception ex)
            {
                //log
            }
            return tasks;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectID"></param>
        /// <returns></returns>
        public List<TblTasks> GetTasksByProject(string ProjectID)
        {
            List<TblTasks> tasks = new List<TblTasks>();
            try
            {
                tasks = _projectContext.TblTasks.Where(m => m.ProjectId == ProjectID).ToList();
            }
            catch (Exception ex)
            {
                //log
            }
            return tasks;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public TblTasks CreateTask(TblTasks task)
        {
            _projectContext.TblTasks.Add(task);
            _projectContext.SaveChanges();
            return task;
        }

        public TblTasks UpdateTask(TblTasks task)
        {
            var _taskobj = _projectContext.TblTasks.Where(m => m.TaskId == task.TaskId && m.ProjectId == task.ProjectId).FirstOrDefault();

            if (_taskobj != null)
            {
                _taskobj.TaskName = task.TaskName;
                _taskobj.TaskStatus = task.TaskStatus;
                _taskobj.Assignee = task.Assignee;
                _taskobj.TaskParent = task.TaskParent;
                _taskobj.IsRequired = task.IsRequired;
                _taskobj.StartDate = task.StartDate;
                _taskobj.DueDate = task.DueDate;
                _taskobj.EstimatedEfforts = task.EstimatedEfforts;
                _taskobj.CompletedEfforts = task.CompletedEfforts;
                _taskobj.Priority = task.Priority;
                _taskobj.UpdatedBy = task.UpdatedBy;
                _taskobj.UpdatedDate = task.UpdatedDate;


                _projectContext.Update(_taskobj).Property(x => x.Tid).IsModified = false;
                _projectContext.SaveChanges();

            }
            return task;
        }

        public bool DeleteTask(TblTasks task)
        {
            var _taskObj = _projectContext.TblTasks.Where(m => m.TaskId == task.TaskId && m.ProjectId == task.ProjectId).FirstOrDefault();

            if (_taskObj != null)
            {
                _projectContext.Entry<TblTasks>(_taskObj).State = EntityState.Deleted;
                _projectContext.SaveChanges();
            }
            return true;
        }

    }
}
