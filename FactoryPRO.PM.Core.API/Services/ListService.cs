using AutoMapper;
using FactoryPRO.PM.Core.DAL.Models;
using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.Common;
//using FactoryPRO.PM.Core.DAL.Models;
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
    public class ListService : IListService
    {
        private IListRepository _listRepository;
        private ITaskRepository _taskRepository;
        private IMapper _mapper;
       /// <summary>
       /// 
       /// </summary>
       /// <param name="listRepository"></param>
       /// <param name="mapper"></param>
       /// <param name="taskRepository"></param>
        public ListService(IListRepository listRepository, IMapper mapper,ITaskRepository taskRepository)
        {
            _listRepository = listRepository;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Lists"></param>
        /// <returns></returns>
        public ListDTO CreateList(ListDTO Lists)
        {
            TblList list = _mapper.Map<TblList>(Lists);
            list.CreatedDate = DateTime.UtcNow;
            list.ListId = Guid.NewGuid().ToString();
            list = _listRepository.CreateList(list);
            ListDTO listdto = _mapper.Map<ListDTO>(list);
            return listdto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Lists"></param>
        /// <returns></returns>
        public bool DeleteList(ListDTO Lists)
        {
            var result = false;
            TblList list = _mapper.Map<TblList>(Lists);
            result = _listRepository.DeleteList(list);
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="listID"></param>
        /// <returns></returns>
        public ListDTO GetListByID(string listID,string ProjectID)
        {
            TblList list = _listRepository.GetListByID(listID, ProjectID);
            ListDTO Lists = _mapper.Map<ListDTO>(list);
            return Lists;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ListDTO> GetList(string ProjectID)
        {
            List<TblList> Lists = (List<TblList>)_listRepository.GetList(ProjectID);
            List<ListDTO> listsDTO = new List<ListDTO>();
            foreach (TblList list in Lists)
            {
                ListDTO listdto = _mapper.Map<ListDTO>(list);
                listsDTO.Add(listdto);
            }
            return listsDTO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Lists"></param>
        /// <returns></returns>
        public ListDTO UpdateList(ListDTO Lists)
        {
            TblList list = _mapper.Map<TblList>(Lists);
            list = _listRepository.UpdateList(list);

            ListDTO listdto = _mapper.Map<ListDTO>(list);
            return listdto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ListID"></param>
        /// <returns></returns>
        public bool UpdateListStatusByID(string ListID)
        {
            List<TblTasks> Tasks = (List<TblTasks>)_taskRepository.GetTasksByList(ListID);
            List<TaskDTO> lstTaskDTO = CastObject<TblTasks, TaskDTO>(Tasks);

            var count = lstTaskDTO.Where(m => m.TaskStatus != 4).Count();
            if (count > 0)
                return false;
            else
            {
               return  _listRepository.UpdateListStatusByID(ListID);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<TOut> CastObject<TIn, TOut>(List<TIn> input)
        {
            List<TOut> lstOut = new List<TOut>();
            foreach (TIn tIn in input)
            {
                TOut tOut = _mapper.Map<TOut>(tIn);
                lstOut.Add(tOut);
            }
            return lstOut;
        }

    }
}
