import React, { useState } from 'react';

const BookDetails = () => (
  <div style={{ padding: '1rem', border: '1px solid #3b82f6', borderRadius: '4px', margin: '1rem 0' }}>
    <h3>Book Details Component</h3>
    <p>This component renders when the type is 'book'. (Using if/else)</p>
  </div>
);

const BlogDetails = () => (
  <div style={{ padding: '1rem', border: '1px solid #10b981', borderRadius: '4px', margin: '1rem 0' }}>
    <h3>Blog Details Component</h3>
    <p>This component renders when the type is 'blog'. (Using Switch statement)</p>
  </div>
);

const CourseDetails = () => (
  <div style={{ padding: '1rem', border: '1px solid #f59e0b', borderRadius: '4px', margin: '1rem 0' }}>
    <h3>Course Details Component</h3>
    <p>This component renders when the type is 'course'. (Using Ternary Operator)</p>
  </div>
);

export default function BloggerApp() {
  const [activeTab, setActiveTab] = useState('book');

  // Method 1: If-Else Rendering
  const renderIfElse = () => {
    if (activeTab === 'book') {
      return <BookDetails />;
    }
    return null;
  };

  // Method 2: Switch Case Rendering
  const renderSwitch = () => {
    switch(activeTab) {
      case 'blog':
        return <BlogDetails />;
      default:
        return null;
    }
  };

  return (
    <div className="card">
      <h2>Blogger App (HOL 13)</h2>
      <p>Demonstrating Conditional Rendering in React.</p>
      
      <div style={{ display: 'flex', gap: '1rem', margin: '1rem 0' }}>
        <button 
          onClick={() => setActiveTab('book')}
          style={{ opacity: activeTab === 'book' ? 1 : 0.6 }}>
          Show Book
        </button>
        <button 
          onClick={() => setActiveTab('blog')}
          style={{ opacity: activeTab === 'blog' ? 1 : 0.6 }}>
          Show Blog
        </button>
        <button 
          onClick={() => setActiveTab('course')}
          style={{ opacity: activeTab === 'course' ? 1 : 0.6 }}>
          Show Course
        </button>
      </div>

      <div style={{ marginTop: '2rem' }}>
        {/* Method 1: If Else invoked */}
        {renderIfElse()}
        
        {/* Method 2: Switch invoked */}
        {renderSwitch()}

        {/* Method 3: Ternary Operator */}
        {activeTab === 'course' ? <CourseDetails /> : null}

        {/* Method 4: Logical && */}
        {activeTab === 'book' && <p style={{color: '#3b82f6'}}>Logical && operator triggered for Book.</p>}
      </div>
    </div>
  );
}
