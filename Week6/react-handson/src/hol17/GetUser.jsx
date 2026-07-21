import React, { Component } from 'react';

export default class GetUser extends Component {
  constructor(props) {
    super(props);
    this.state = {
      user: null,
      loading: true,
      error: null
    };
  }

  async componentDidMount() {
    try {
      const response = await fetch('https://api.randomuser.me/');
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      const data = await response.json();
      this.setState({ user: data.results[0], loading: false });
    } catch (error) {
      this.setState({ error: error.message, loading: false });
    }
  }

  render() {
    const { user, loading, error } = this.state;

    return (
      <div className="card" style={{ maxWidth: '400px', textAlign: 'center' }}>
        <h2>Random User (HOL 17)</h2>
        <p>Fetching REST API in componentDidMount</p>

        <div style={{ marginTop: '2rem' }}>
          {loading && <p>Loading user data...</p>}
          
          {error && <p style={{ color: 'red' }}>Error: {error}</p>}
          
          {user && (
            <div>
              <img 
                src={user.picture.large} 
                alt={`${user.name.first} ${user.name.last}`} 
                style={{ borderRadius: '50%', border: '4px solid var(--border)', marginBottom: '1rem' }}
              />
              <h3>{user.name.title} {user.name.first} {user.name.last}</h3>
              <p style={{ color: 'var(--primary)', fontWeight: '500' }}>{user.email}</p>
              <p style={{ color: 'var(--text)', opacity: 0.8, marginTop: '0.5rem' }}>
                {user.location.city}, {user.location.country}
              </p>
            </div>
          )}
        </div>
      </div>
    );
  }
}
