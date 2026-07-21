import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link, Outlet } from 'react-router-dom';
import TrainerApp from './hol6/TrainerApp';
import OnlineShopping from './hol7/OnlineShopping';
import CountPeople from './hol8/CountPeople';
import BloggerApp from './hol13/BloggerApp';
import ThemeApp from './hol14/ThemeApp';
import ComplaintRegister from './hol15/ComplaintRegister';
import Register from './hol16/Register';
import GetUser from './hol17/GetUser';
import './App.css';

function Home() {
  return (
    <div className="home-container">
      <h1>React Hands-On Exercises</h1>
      <p>Select an exercise from the sidebar to view its implementation.</p>
    </div>
  );
}

function Layout() {
  return (
    <div className="app-layout">
      <aside className="sidebar">
        <h2>Exercises</h2>
        <nav>
          <ul>
            <li><Link to="/">Home</Link></li>
            <li><Link to="/hol6">HOL 6: Router</Link></li>
            <li><Link to="/hol7">HOL 7: Props</Link></li>
            <li><Link to="/hol8">HOL 8: State</Link></li>
            <li><Link to="/hol13">HOL 13: Conditional</Link></li>
            <li><Link to="/hol14">HOL 14: Context API</Link></li>
            <li><Link to="/hol15">HOL 15: Forms</Link></li>
            <li><Link to="/hol16">HOL 16: Validation</Link></li>
            <li><Link to="/hol17">HOL 17: REST API</Link></li>
          </ul>
        </nav>
      </aside>
      <main className="main-content">
        <Outlet />
      </main>
    </div>
  );
}

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Home />} />
          <Route path="hol6/*" element={<TrainerApp />} />
          <Route path="hol7" element={<OnlineShopping />} />
          <Route path="hol8" element={<CountPeople />} />
          <Route path="hol13" element={<BloggerApp />} />
          <Route path="hol14" element={<ThemeApp />} />
          <Route path="hol15" element={<ComplaintRegister />} />
          <Route path="hol16" element={<Register />} />
          <Route path="hol17" element={<GetUser />} />
        </Route>
      </Routes>
    </Router>
  );
}

export default App;
