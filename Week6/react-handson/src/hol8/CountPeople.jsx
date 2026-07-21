import React, { Component } from 'react';

export default class CountPeople extends Component {
  constructor(props) {
    super(props);
    this.state = {
      entrycount: 0,
      exitcount: 0
    };
  }

  updateEntry = () => {
    this.setState(prevState => ({
      entrycount: prevState.entrycount + 1
    }));
  };

  updateExit = () => {
    this.setState(prevState => ({
      exitcount: prevState.exitcount + 1
    }));
  };

  render() {
    return (
      <div className="card" style={{ textAlign: 'center' }}>
        <h2>Counter App (HOL 8)</h2>
        <p>Demonstrating State in Class Components</p>
        
        <div style={{ display: 'flex', justifyContent: 'center', gap: '2rem', margin: '2rem 0' }}>
          <div>
            <button onClick={this.updateEntry}>Login</button>
            <p style={{ marginTop: '1rem', fontSize: '1.2rem' }}>
              {this.state.entrycount} people entered
            </p>
          </div>
          
          <div>
            <button onClick={this.updateExit} style={{ backgroundColor: '#ef4444' }}>Exit</button>
            <p style={{ marginTop: '1rem', fontSize: '1.2rem' }}>
              {this.state.exitcount} people left
            </p>
          </div>
        </div>
      </div>
    );
  }
}
