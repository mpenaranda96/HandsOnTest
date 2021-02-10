using HandsOnTest.DTO;

namespace HandsOnTest.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public long HourlySalary { get; set; }
        public long MonthlySalary { get; set; }
        public long YearlySalary { get; set; }
    }

    public class HourlySalaryEmployee : Employee, IEmployee
    {
        public Employee BuildEmployee(EmployeeDTO dto)
        {
            Employee e = new Employee
            {
                Id = dto.Id,
                Name = dto.Name,
                ContractTypeName = dto.ContractTypeName,
                RoleId = dto.RoleId,
                RoleName = dto.RoleName,
                RoleDescription = dto.RoleDescription,
                HourlySalary = dto.HourlySalary,
                MonthlySalary = dto.MonthlySalary
            };
            e.YearlySalary = GetYearlySalary(e.HourlySalary);
            return e;
        }

        public long GetYearlySalary(long HourlySalary)
        {
            return 120 * HourlySalary * 12;
        }
    }

    public class MonthlySalaryEmployee : Employee, IEmployee
    {
        public Employee BuildEmployee(EmployeeDTO dto)
        {
            Employee e = new Employee
            {
                Id = dto.Id,
                Name = dto.Name,
                ContractTypeName = dto.ContractTypeName,
                RoleId = dto.RoleId,
                RoleName = dto.RoleName,
                RoleDescription = dto.RoleDescription,
                HourlySalary = dto.HourlySalary,
                MonthlySalary = dto.MonthlySalary
            };
            e.YearlySalary = GetYearlySalary(e.MonthlySalary);
            return e;
        }

        public long GetYearlySalary(long MonthlySalary)
        {
            return MonthlySalary * 12;
        }
    }
}
