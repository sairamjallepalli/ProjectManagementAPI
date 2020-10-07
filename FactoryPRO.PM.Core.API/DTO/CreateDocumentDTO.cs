using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.DTO
{
    public class CreateDocumentDTO
    {

        public long Id { get; set; }
        public short PlantId { get; set; }
        public int DepartmentId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public Guid FileGuid { get; set; }
        public string FileName { get; set; }
        public string UserFileName { get; set; }
        public string ChkSum { get; set; }
        public decimal Revision { get; set; }
        public long RevisionParentId { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ReviewStatus { get; set; }
        public string IsArchived { get; set; }
        public int ArchivedBy { get; set; }
        public DateTime ArchivedDate { get; set; }
        public long EcoParentId { get; set; }
        public bool HasWorkflow { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long LastAccessedBy { get; set; }
        public DateTime LastAccessedDate { get; set; }

        public string DepartmentCode { get; set; }
        public string DocumentType { get; set; }
        public IFormFile NewFileStream { get; set; }
        public List<DocumentStandardsDTO> StandardClauses { get; set; }
        public List<DocumentModulesDTO> Modules { get; set; }
    }


    public class DocumentModulesDTO
    {
        public long Dmid { get; set; }
        public long DocumentId { get; set; }
        public int ModuleId { get; set; }
        public bool Active { get; set; }
    }

    public class DocumentStandardsDTO
    {
        public long Dscid { get; set; }
        public long DocumentId { get; set; }
        public int StandardId { get; set; }
        public int ClauseId { get; set; }
    }
}
