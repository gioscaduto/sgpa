import { Box, Button, TextField, Typography } from "@mui/material";
import React, { useState } from "react";

const SignupForm = () => {
  const [isSignup, setIsSignup] = useState(false);
  const [inputs, setInputs] = useState({
    name: "",
    email: "",
    password: ""
  })
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setInputs((prevState) => ({
      ...prevState, [e.target.name]: e.target.value
    }))
  }

  const handleSubmit = (e: React.ChangeEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log(inputs);
  }

  const resetState = () => {
    setIsSignup(!isSignup);
    setInputs({name: '', email: '', password: ''})
  }

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <Box display="flex" 
          flexDirection={"column"} 
          maxWidth={400}
          alignItems="center"
          justifyContent={"center"}
          margin="auto"
          marginTop={5}
          padding={3}
          borderRadius={5}
          boxShadow={'5px 5px 10px #ccc'}
          sx={{":hover": {
            boxShadow: "10px 10px 20px #ccc",
          }}}>
          <Typography variant="h2" padding={3} textAlign="center">Signup</Typography>

          <TextField onChange={handleChange} value={inputs.name} name="name" margin="normal" type={'text'} variant="outlined" placeholder="Name" />

          <TextField onChange={handleChange} value={inputs.email} name="email" margin="normal" type={'email'} variant="outlined" placeholder="Email"/>
          <TextField onChange={handleChange} value={inputs.password} name="password" margin="normal" type={'password'} variant="outlined" placeholder="Password"/>
          <Button type="submit" variant="contained" color="warning" sx={{marginTop: 3, borderRadius: 3 }}>Signup</Button>
        </Box>
      </form>
    </div>);
}

export default SignupForm;