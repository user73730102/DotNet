import React from 'react';
import { Link } from 'react-router-dom';
import { mockTrainers } from './TrainersMock';

export default function TrainersList() {
  return (
    <div className="card">
      <h2>Trainers List</h2>
      <ul>
        {mockTrainers.map(trainer => (
          <li key={trainer.TrainerId}>
            <Link to={`/hol6/trainers/${trainer.TrainerId}`}>{trainer.Name}</Link>
          </li>
        ))}
      </ul>
    </div>
  );
}
