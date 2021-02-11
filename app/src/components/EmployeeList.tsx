import React from 'react';
import './EmployeeList.css';

type Props = {
    employees: any[]
}

const EmployeeList: React.FC<Props> = (
    {
        employees
    }
) => (
    <div>
        <table className="table">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>NAME</th>
                    <th>CONTRACT TYPE</th>
                    <th>ROLE NAME</th>
                    <th>HOURLY SALARY</th>
                    <th>MONTHLY SALARY</th>
                    <th>YEARLY SALARY</th>
                </tr>
            </thead>
            <tbody>
                {employees.map(e => (
                <tr key={e.id}>
                    <td>{e.id}</td>
                    <td>{e.name}</td>
                    <td>{e.contractTypeName}</td>
                    <td>{e.roleName}</td>
                    <td>{e.hourlySalary}</td>
                    <td>{e.monthlySalary}</td>
                    <td>{e.yearlySalary}</td>
                </tr>
            ))}
            </tbody>
        </table>
        
    </div>
);

export default EmployeeList;