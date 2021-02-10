import React, { useState } from 'react';
import { EmployeeState } from './TYPES';
import { fetchAllEmployees, fetchOneEmployee } from './API/API';
import EmployeeList from './components/EmployeeList';
import { render } from '@testing-library/react';

const App = () => {
  const [employees, setEmployees] = useState<EmployeeState[]>([]);
  const [amount, setAmount] = useState(0);
  const [error, setError] = useState(false);

  let employeeRef: React.RefObject<HTMLInputElement> = React.createRef();

  const initValues = async () => {

    if (employeeRef.current?.value) {
      try {
        const employeeToLoad = await fetchOneEmployee(Number.parseInt(employeeRef.current.value));
        setEmployees([employeeToLoad]);
        setAmount(1);
        setError(false);
      }
      catch {
        setError(true);
      }
    }
    else {
      try {
        const employeesToLoad = await fetchAllEmployees();
        setEmployees(employeesToLoad.employees);
        setAmount(employeesToLoad.employees.length);
        setError(false);
      }
      catch {
        setError(true);
      }
    }
  }

  return (
    <div className="App">
      <input type="number" placeholder="Employee ID" ref={employeeRef} />
      <button className="Start" onClick={initValues}>Get Employee(s)</button>

      {
        (amount > 0 && !error) && <EmployeeList employees = {employees} />
      }

      { error && <p>Can't show this content at the moment, try again!</p> }

    </div>
  )
}

export default App;