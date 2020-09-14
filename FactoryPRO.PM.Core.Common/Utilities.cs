using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPRO.PM.Core.Common
{
   public class Utilities
    {

        private IMapper _mapper;

        public Utilities(IMapper mapper)
        {
            _mapper = mapper;
        }
        //public static List<TOut> CastObject<TIn, TOut>(List<TIn> input)
        //{
        //    List<TOut> lstOut = new List<TOut>();
        //    foreach (TIn tIn in input)
        //    {
        //        TOut tOut = _mapper.Map<TOut>(tIn);
        //        lstOut.Add(tOut);
        //    }
        //    return lstOut;
        //}


    }
}
