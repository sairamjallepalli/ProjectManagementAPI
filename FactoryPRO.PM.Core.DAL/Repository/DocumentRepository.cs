using FactoryPRO.PM.Core.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPRO.PM.Core.DAL.Repository
{
   public  class DocumentRepository:IDocumentRepository 
    {
        private ProjectContext _projectContext;
        public DocumentRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public   List<TblDocuments> CreateDocuments(List<TblDocuments> documents)
        {
            foreach (TblDocuments document in documents)
            {
                _projectContext.TblDocuments.Add(document);
            }

            _projectContext.SaveChanges();
            return documents;
        }

    }
}
