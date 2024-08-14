import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import EventListPage from './pages/EventListPage';
import EventFormPage from './pages/EventFormPage';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<EventListPage />} />
        <Route path="/event/new" element={<EventFormPage />} />
        <Route path="/event/edit/:id" element={<EventFormPage />} />
      </Routes>
    </Router>
  );
}

export default App;
