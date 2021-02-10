using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HandsOnTest.DTO;

namespace HandsOnTest.Repositories
{
    public class GlobalRepository : IGlobalRepository
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<EmployeeDTO>> Get()
        {
            try
            {
                var responseString = await _httpClient.GetStringAsync("http://masglobaltestapi.azurewebsites.net/api/Employees");
                var employees = JsonConvert.DeserializeObject<List<EmployeeDTO>>(responseString);

                return employees;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EmployeeDTO> GetOne(int Id)
        {
            try
            {
                var employees = await Get();
                return employees.FirstOrDefault(x => x.Id == Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
