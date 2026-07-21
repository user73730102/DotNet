import React, { useState } from 'react';
import ThemeContext from './ThemeContext';
import EmployeeList from './EmployeeList';

export default function ThemeApp() {
  const [theme, setTheme] = useState('light');

  const employees = [
    { id: 1, name: 'Alice', designation: 'Software Engineer' },
    { id: 2, name: 'Bob', designation: 'Product Manager' }
  ];

  return (
    <ThemeContext.Provider value={theme}>
      <div className="card">
        <h2>Context API Theme App (HOL 14)</h2>
        <p>Current Theme: <strong>{theme}</strong></p>
        
        <button 
          onClick={() => setTheme(theme === 'light' ? 'dark' : 'light')}
          style={{ marginBottom: '1rem' }}
        >
          Toggle Theme
        </button>

        <EmployeeList employees={employees} />
      </div>
    </ThemeContext.Provider>
  );
}
