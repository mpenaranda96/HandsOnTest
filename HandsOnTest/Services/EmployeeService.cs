using HandsOnTest.Entities;
using HandsOnTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandsOnTest.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGlobalRepository _globalRepository;

        public EmployeeService(IGlobalRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }

        public async Task<List<Employee>> Get()
        {
            try
            {
                var RawEmployeeData = await _globalRepository.Get();
                var ParsedEmployeeData = new List<Employee>();

                foreach (var E in RawEmployeeData)
                {
                    switch (E.ContractTypeName)
                    {
                        case "HourlySalaryEmployee":
                            ParsedEmployeeData.Add(new HourlySalaryEmployee().BuildEmployee(E));
                            break;
                        case "MonthlySalaryEmployee":
                            ParsedEmployeeData.Add(new MonthlySalaryEmployee().BuildEmployee(E));
                            break;
                        default:
                            continue;
                    }
                }

                return ParsedEmployeeData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Employee> GetOne(int Id)
        {
            try
            {
                var FixedEmployeeData = await Get();
                return FixedEmployeeData.Find(x => x.Id == Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
