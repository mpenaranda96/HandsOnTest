using HandsOnTest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnTest.Repositories
{
    public interface IGlobalRepository
    {
        public Task<List<EmployeeDTO>> Get();
        public Task<EmployeeDTO> GetOne(int Id);
    }
}
