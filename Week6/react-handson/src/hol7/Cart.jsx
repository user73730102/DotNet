import React, { Component } from 'react';

export default class Cart extends Component {
  render() {
    const { Itemname, Price } = this.props;
    return (
      <tr style={{ borderBottom: '1px solid var(--border)' }}>
        <td style={{ padding: '0.5rem' }}>{Itemname}</td>
        <td style={{ padding: '0.5rem' }}>${Price}</td>
      </tr>
    );
  }
}
