import React, { useContext } from 'react';
import ThemeContext from './ThemeContext';

export default function EmployeeCard({ employee }) {
  const theme = useContext(ThemeContext);

  const buttonStyle = theme === 'dark' 
    ? { backgroundColor: '#1f2937', color: 'white' } 
    : { backgroundColor: '#e5e7eb', color: 'black' };

  return (
    <div style={{ border: '1px solid var(--border)', padding: '1rem', margin: '0.5rem 0', borderRadius: '4px' }}>
      <h4>{employee.name}</h4>
      <p>{employee.designation}</p>
      <button style={{ ...buttonStyle, marginTop: '0.5rem' }}>View Profile (Theme: {theme})</button>
    </div>
  );
}
