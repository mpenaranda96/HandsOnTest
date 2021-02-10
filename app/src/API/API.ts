import Employee from '../interfaces/Employee.interface';
const ENDPOINT_URL: string = 'https://localhost:5001/api/Employees';

export const fetchAllEmployees = async () => {
    const data = await (await fetch(ENDPOINT_URL)).json();
    return { employees: data }
}

export const fetchOneEmployee = async (id: number) => {
    const employee = await (await fetch(`${ENDPOINT_URL}/${id}`)).json();
    return employee;
}