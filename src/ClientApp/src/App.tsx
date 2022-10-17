import React, { useState } from 'react';
import logo from './logo.svg';
import './App.css';
import Auth from './Auth';
import LoginForm from './LoginForm';
import { Box, Button } from '@mui/material';
import SignupForm from './SignupForm';

function App() {
  const [isSignup, setIsSignup] = useState(false);

  return (
    <div className="App">
      { !isSignup && (<LoginForm />)}
      { isSignup && (<SignupForm />)}    
      
      <Button onClick={() => setIsSignup(!isSignup) } sx={{marginTop: 3, borderRadius: 3 }}>
        { isSignup ? "Login" : "Signup"}
      </Button> 
    </div>
  );
}

export default App;
