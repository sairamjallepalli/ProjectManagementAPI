using AutoMapper;
using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.Common;
using FactoryPRO.PM.Core.DAL.Models;
using FactoryPRO.PM.Core.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskService : ITaskService
    {

        private ITaskRepository _taskRepository;
        private IDocumentRepository  _docRepository;
        private IMapper _mapper;
        private ExternalService _externalService;
      /// <summary>
      /// 
      /// </summary>
      /// <param name="taskRepository"></param>
      /// <param name="mapper"></param>
      /// <param name="docRepository"></param>
        public TaskService(ITaskRepository taskRepository, IMapper mapper,IDocumentRepository docRepository)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _docRepository = docRepository;
        }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="UserGUID"></param>
      /// <returns></returns>
        public List<TaskDTO> GetTasksByUserID(string UserGUID)
        {
            List<TblTasks> Tasks = (List<TblTasks>)_taskRepository.GetTasksByUserID(UserGUID);
            List<TaskDTO> tasks = new List<TaskDTO>();

            foreach (TblTasks Task in Tasks)
            {
                TaskDTO taskobj = _mapper.Map<TaskDTO>(Task);
                tasks.Add(taskobj);
            }
            return tasks;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="TaskID"></param>
       /// <returns></returns>
        public TaskDTO GetTasksByID(string TaskID)
        {
            TblTasks Task = (TblTasks)_taskRepository.GetTasksByID(TaskID);
            TaskDTO task = new TaskDTO();
            task = _mapper.Map<TaskDTO>(Task);
            return task;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ListID"></param>
        /// <returns></returns>
        public List<TaskDTO> GetTasksByList(string ListID)
        {
            List<TblTasks> Tasks = (List<TblTasks>)_taskRepository.GetTasksByList(ListID);
            List<TaskDTO> tasks = new List<TaskDTO>();

            foreach (TblTasks Task in Tasks)
            {
                TaskDTO taskobj = _mapper.Map<TaskDTO>(Task);
                tasks.Add(taskobj);
            }
            return tasks;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectID"></param>
        /// <returns></returns>
        public List<TaskDTO> GetTasksByProject(string ProjectID)
        {
            List<TblTasks> Tasks = (List<TblTasks>)_taskRepository.GetTasksByProject(ProjectID);
            List<TaskDTO> tasks = new List<TaskDTO>();

            foreach (TblTasks Task in Tasks)
            {
                TaskDTO taskobj = _mapper.Map<TaskDTO>(Task);
                tasks.Add(taskobj);
            }
            return tasks;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Task"></param>
        /// <returns></returns>
        public TaskDTO CreateTask(TaskDTO Task)
        {
            TblTasks task = _mapper.Map<TblTasks>(Task);
            List<TblDocuments> documents = new List<TblDocuments>();
            task.TaskId = Guid.NewGuid().ToString();
            task.CreatedDate = DateTime.UtcNow;
            task = _taskRepository.CreateTask(task);

            //Document Block Started
            int count = 1;
            foreach (TaskFilesDTO file in Task.TaskFiles )
            {
                if (file.IsExists == "N")
                {
                    CreateDocumentDTO createDocument = new CreateDocumentDTO();
                    createDocument.HasWorkflow = false;
                    createDocument.CreatedBy = 1;//file.ActionBy;
                    createDocument.CreatedDate = file.ActionDate;
                    createDocument.TypeId = 0;
                    createDocument.DepartmentId = file.DepartmentID;
                    createDocument.PlantId = 1;
                    createDocument.Title = file.ProjectName + "_1." + count.ToString();
                    createDocument.NewFileStream = file.NewFileStream;

                    List<DocumentModulesDTO> documentModules = new List<DocumentModulesDTO>();
                    DocumentModulesDTO dTO = new DocumentModulesDTO();
                    dTO.ModuleId = file.ModuleID;
                    dTO.DocumentId = 0;
                    dTO.Active = true;
                    documentModules.Add(dTO);
                    createDocument.Modules = documentModules;

                    createDocument = _externalService.CreateDocument(createDocument).Result;
                    file.FileGuid = createDocument.FileGuid;

                    TblDocuments tblDoc = new TblDocuments();
                    tblDoc.DocumentId = createDocument.DepartmentId.ToString();
                    tblDoc.TaskId = task.TaskId;
                    tblDoc.Files = file.FileName;
                    tblDoc.CreatedBy = task.CreatedBy;
                    tblDoc.CreatedDate = DateTime.UtcNow;

                    documents.Add(tblDoc);

                    count++;
                }
            }

            // Document Block closed

           documents = _docRepository.CreateDocuments(documents);

            TaskDTO Taskdto = new TaskDTO();
            Taskdto = _mapper.Map<TaskDTO>(task);
            return Taskdto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Task"></param>
        /// <returns></returns>
        public TaskDTO UpdateTask(TaskDTO Task)
        {
            TblTasks task = _mapper.Map<TblTasks>(Task);
            task.UpdatedDate = DateTime.UtcNow;
            task = _taskRepository.UpdateTask(task);

            TaskDTO Taskdto = new TaskDTO();
            Taskdto = _mapper.Map<TaskDTO>(task);
            return Taskdto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Task"></param>
        /// <returns></returns>
        public bool DeleteTask(TaskDTO Task)
        {
            var result = false;
            TblTasks task = _mapper.Map<TblTasks>(Task);
            result = _taskRepository.DeleteTask(task);
            return result;
        }

    }
}
