import React, { useState } from 'react';

export default function Register() {
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    password: ''
  });

  const [errors, setErrors] = useState({});
  const [successMsg, setSuccessMsg] = useState('');

  const validate = () => {
    const newErrors = {};
    if (formData.name.length < 5) {
      newErrors.name = 'Name should have at least 5 characters.';
    }
    if (!formData.email.includes('@') || !formData.email.includes('.')) {
      newErrors.email = 'Email should have @ and . symbols.';
    }
    if (formData.password.length < 8) {
      newErrors.password = 'Password should have at least 8 characters.';
    }
    return newErrors;
  };

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
    // Clear errors when user types
    setErrors({ ...errors, [e.target.name]: '' });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const validationErrors = validate();
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors);
      setSuccessMsg('');
    } else {
      setErrors({});
      setSuccessMsg('Registration Successful!');
      setFormData({ name: '', email: '', password: '' });
    }
  };

  return (
    <div className="card" style={{ maxWidth: '500px' }}>
      <h2>Mail Register (HOL 16)</h2>
      <p>Demonstrating Form Validations</p>

      {successMsg && <div style={{ padding: '1rem', backgroundColor: '#064e3b', color: '#34d399', borderRadius: '4px', marginBottom: '1rem' }}>{successMsg}</div>}

      <form onSubmit={handleSubmit} style={{ marginTop: '1.5rem' }}>
        <div className="form-group">
          <label htmlFor="name">Name:</label>
          <input 
            type="text" 
            id="name" 
            name="name"
            value={formData.name} 
            onChange={handleChange} 
            placeholder="Enter your name"
          />
          {errors.name && <span style={{ color: '#ef4444', fontSize: '0.875rem' }}>{errors.name}</span>}
        </div>

        <div className="form-group">
          <label htmlFor="email">Email:</label>
          <input 
            type="text" 
            id="email" 
            name="email"
            value={formData.email} 
            onChange={handleChange} 
            placeholder="Enter your email"
          />
          {errors.email && <span style={{ color: '#ef4444', fontSize: '0.875rem' }}>{errors.email}</span>}
        </div>

        <div className="form-group">
          <label htmlFor="password">Password:</label>
          <input 
            type="password" 
            id="password" 
            name="password"
            value={formData.password} 
            onChange={handleChange} 
            placeholder="Enter your password"
          />
          {errors.password && <span style={{ color: '#ef4444', fontSize: '0.875rem' }}>{errors.password}</span>}
        </div>

        <button type="submit" style={{ width: '100%', marginTop: '1rem' }}>
          Register
        </button>
      </form>
    </div>
  );
}
