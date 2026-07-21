import React, { Component } from 'react';
import Cart from './Cart';

export default class OnlineShopping extends Component {
  constructor(props) {
    super(props);
    this.state = {
      cartItems: [
        { Itemname: 'Laptop', Price: 999 },
        { Itemname: 'Smartphone', Price: 699 },
        { Itemname: 'Headphones', Price: 199 },
        { Itemname: 'Monitor', Price: 299 },
        { Itemname: 'Keyboard', Price: 99 }
      ]
    };
  }

  render() {
    return (
      <div className="card">
        <h2>Online Shopping (HOL 7)</h2>
        <p>Demonstrating Props and Class Components</p>
        <table style={{ width: '100%', borderCollapse: 'collapse', marginTop: '1rem' }}>
          <thead>
            <tr style={{ backgroundColor: 'var(--surface-hover)', textAlign: 'left' }}>
              <th style={{ padding: '0.5rem' }}>Item Name</th>
              <th style={{ padding: '0.5rem' }}>Price</th>
            </tr>
          </thead>
          <tbody>
            {this.state.cartItems.map((item, index) => (
              <Cart key={index} Itemname={item.Itemname} Price={item.Price} />
            ))}
          </tbody>
        </table>
      </div>
    );
  }
}
