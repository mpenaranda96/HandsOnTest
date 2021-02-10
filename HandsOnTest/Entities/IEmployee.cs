using HandsOnTest.DTO;

namespace HandsOnTest.Entities
{
    public interface IEmployee
    {
        public long GetYearlySalary(long Salary);
        public Employee BuildEmployee(EmployeeDTO dto);
    }
}
