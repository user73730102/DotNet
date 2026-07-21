import React, { useState } from 'react';

export default function ComplaintRegister() {
  const [name, setName] = useState('');
  const [complaint, setComplaint] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    const refNum = Math.floor(Math.random() * 1000000);
    alert(`Thanks ${name}!\nYour complaint has been registered.\nReference Number: REF-${refNum}`);
    setName('');
    setComplaint('');
  };

  return (
    <div className="card" style={{ maxWidth: '500px' }}>
      <h2>Register Complaint (HOL 15)</h2>
      <p>Demonstrating Controlled Components in React Forms</p>

      <form onSubmit={handleSubmit} style={{ marginTop: '1.5rem' }}>
        <div className="form-group">
          <label htmlFor="name">Employee Name:</label>
          <input 
            type="text" 
            id="name" 
            value={name} 
            onChange={(e) => setName(e.target.value)} 
            required 
            placeholder="Enter your name"
          />
        </div>

        <div className="form-group">
          <label htmlFor="complaint">Complaint Details:</label>
          <textarea 
            id="complaint" 
            rows="5"
            value={complaint} 
            onChange={(e) => setComplaint(e.target.value)} 
            required
            placeholder="Describe your issue..."
          />
        </div>

        <button type="submit" style={{ width: '100%', marginTop: '1rem' }}>
          Submit Complaint
        </button>
      </form>
    </div>
  );
}
