import React from 'react';
import { Routes, Route, Link } from 'react-router-dom';
import Home from './Home';
import TrainersList from './TrainersList';
import TrainerDetail from './TrainerDetail';
import './TrainerApp.css';

export default function TrainerApp() {
  return (
    <div className="trainer-app">
      <nav className="trainer-nav">
        <Link to="/hol6">Home</Link>
        <Link to="/hol6/trainers">Trainers</Link>
      </nav>
      
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/trainers" element={<TrainersList />} />
        <Route path="/trainers/:id" element={<TrainerDetail />} />
      </Routes>
    </div>
  );
}
