using AutoMapper;
using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ExternalService
    {
        private readonly IMapper _autoMapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="autoMapper"></param>
        public ExternalService(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }

        public async Task<List<DepartmentDTO>> GetDepartments()
        {
            List<DepartmentDTO> m_departments = new List<DepartmentDTO>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://132.148.242.138/FPUMS/api/user/GetDepartments"))
                {
                    string strResponse = await response.Content.ReadAsStringAsync();
                    APIResponse apiResponse = JsonConvert.DeserializeObject<APIResponse>(strResponse);
                    m_departments = _autoMapper.Map<List<DepartmentDTO>>(apiResponse.returnObject);
                }
            }
            return m_departments;
        }

        public async Task<List<RoleDTO>> GetRoles()
        {
            List<RoleDTO> m_departments = new List<RoleDTO>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://132.148.242.138/FPUMS/api/user/GetRoles"))
                {
                    string strResponse = await response.Content.ReadAsStringAsync();
                    APIResponse apiResponse = JsonConvert.DeserializeObject<APIResponse>(strResponse);
                    m_departments = _autoMapper.Map<List<RoleDTO>>(apiResponse.returnObject);
                }
            }
            return m_departments;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            List<UserDTO> m_departments = new List<UserDTO>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://132.148.242.138/FPUMS/api/user/GetUsers"))
                {
                    string strResponse = await response.Content.ReadAsStringAsync();
                    APIResponse apiResponse = JsonConvert.DeserializeObject<APIResponse>(strResponse);
                    m_departments = _autoMapper.Map<List<UserDTO>>(apiResponse.returnObject);
                }
            }
            return m_departments;
        }

        public async Task<CreateDocumentDTO> GetFileNameByFileGuid(System.Guid guid)
        {
            CreateDocumentDTO FileName = new CreateDocumentDTO();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://132.148.242.138/FPDMS/api/GetDocumentByGUID?docGuid=" + guid.ToString()))
                    {
                        string strResponse = await response.Content.ReadAsStringAsync();
                        APIResponse apiResponse = JsonConvert.DeserializeObject<APIResponse>(strResponse);
                        FileName = _autoMapper.Map<CreateDocumentDTO>(apiResponse.returnObject);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return FileName;
        }

        public async Task<List<CustomFieldsDTO>> CreateCustomFields(List<CustomFieldsDTO> customFields, string ProductID)
        {
            //Queue
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var dataAsString = JsonConvert.SerializeObject(customFields);
                    var content = new StringContent(dataAsString);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpResponseMessage response = client.PostAsync("http://132.148.242.138/FPDMS/api/SaveCustomFields?EntityID=" + ProductID.ToString(), content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        customFields = _autoMapper.Map<List<CustomFieldsDTO>>(await response.Content.ReadAsStringAsync());
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return customFields;
        }
        public async Task<List<CustomFieldsDTO>> GetCustomFields()
        {
            List<CustomFieldsDTO> main = new List<CustomFieldsDTO>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://132.148.242.138/FPUMS/api/user/GetCustomFields"))
                    {
                        string strResponse = await response.Content.ReadAsStringAsync();
                        APIResponse apiResponse = JsonConvert.DeserializeObject<APIResponse>(strResponse);
                        main = _autoMapper.Map<List<CustomFieldsDTO>>(apiResponse.returnObject);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return main;
        }
        public async Task<List<CustomFieldsDTO>> GetCustomFieldsbyProductID(string ProductID)
        {
            List<CustomFieldsDTO> main = new List<CustomFieldsDTO>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://132.148.242.138/FPUMS/api/user/GetCustomFieldsByEntityID?EntityID=" + ProductID.ToString()))
                    {
                        string strResponse = await response.Content.ReadAsStringAsync();
                        APIResponse apiResponse = JsonConvert.DeserializeObject<APIResponse>(strResponse);
                        main = _autoMapper.Map<List<CustomFieldsDTO>>(apiResponse.returnObject);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return main;
        }

        public async Task<CreateDocumentDTO> CreateDocument(CreateDocumentDTO createDocument)
        {
            CreateDocumentDTO main = new CreateDocumentDTO();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var dataAsString = JsonConvert.SerializeObject(createDocument);
                    var content = new StringContent(dataAsString);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpResponseMessage response = client.PostAsync("http://132.148.242.138/FPUMS/api/user/CreateDocument", content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        main = _autoMapper.Map<CreateDocumentDTO>(await response.Content.ReadAsStringAsync());
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return main;
        }
    }
}
