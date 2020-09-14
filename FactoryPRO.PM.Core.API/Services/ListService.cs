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
        private IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listRepository"></param>
        /// <param name="mapper"></param>
        public ListService(IListRepository listRepository, IMapper mapper)
        {
            _listRepository = listRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Lists"></param>
        /// <returns></returns>
        public bool CreateList(ListDTO Lists)
        {
            var result = false;
            TblList list = _mapper.Map<TblList>(Lists);
            result = _listRepository.CreateList(list);
            return result;
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
        public bool UpdateList(ListDTO Lists)
        {
            var result = false;
            TblList list = _mapper.Map<TblList>(Lists);
            result = _listRepository.UpdateList(list);
            return result;
        }
    }
}
