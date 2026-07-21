import React from 'react';
import EmployeeCard from './EmployeeCard';

export default function EmployeeList({ employees }) {
  return (
    <div>
      <h3>Employees Directory</h3>
      {employees.map(emp => (
        <EmployeeCard key={emp.id} employee={emp} />
      ))}
    </div>
  );
}
