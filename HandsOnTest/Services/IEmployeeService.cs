using HandsOnTest.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnTest.Services
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> Get();
        public Task<Employee> GetOne(int Id);
    }
}
