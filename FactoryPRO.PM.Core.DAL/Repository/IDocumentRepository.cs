using System;
using System.Collections.Generic;
using System.Text;
using FactoryPRO.PM.Core.DAL.Models;

namespace FactoryPRO.PM.Core.DAL.Repository
{
   public  interface IDocumentRepository
    {
        List<TblDocuments> CreateDocuments(List<TblDocuments> documents);
    }
}
