import React from 'react';
import { useParams, Link } from 'react-router-dom';
import { mockTrainers } from './TrainersMock';

export default function TrainerDetail() {
  const { id } = useParams();
  const trainer = mockTrainers.find(t => t.TrainerId === parseInt(id));

  if (!trainer) {
    return <div>Trainer not found.</div>;
  }

  return (
    <div className="card">
      <h2>Trainer Details</h2>
      <p><strong>Name:</strong> {trainer.Name}</p>
      <p><strong>Phone:</strong> {trainer.Phone}</p>
      <p><strong>Email:</strong> {trainer.Email}</p>
      <p><strong>Stream:</strong> {trainer.Stream}</p>
      <p><strong>Skills:</strong> {trainer.Skills}</p>
      
      <Link to="/hol6/trainers">
        <button style={{marginTop: '1rem'}}>Back to Trainers</button>
      </Link>
    </div>
  );
}
