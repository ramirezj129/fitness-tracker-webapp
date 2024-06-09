<template>
  <div class="container">
    <form class="register-form was-validated" id="register-form" @submit.prevent="submitForm">
      <div class="row mb-3 justify-content-center">
        <div class="col-md-6">
          <label for="username" class="form-label">Username</label>
          <input
            type="text"
            class="form-control"
            id="username"
            v-model="username"
            placeholder="Enter Username"
            required
          />
          <div class="invalid-feedback">Please provide a username.</div>
        </div>
      </div>
      <div class="row mb-3 justify-content-center">
        <div class="col-md-6">
          <label for="email" class="form-label">Email</label>
          <input
            type="email"
            class="form-control"
            id="email"
            v-model="email"
            placeholder="Enter Email"
            required
          />
          <div class="invalid-feedback">Please provide a valid email address.</div>
        </div>
      </div>
      <div class="row mb-3 justify-content-center">
        <div class="col-md-6">
          <label for="password" class="form-label">Password:</label>
          <input
            type="password"
            class="form-control"
            id="password"
            v-model="password"
            placeholder="Enter Password"
            required
          />
          <div class="invalid-feedback">Please provide a password.</div>
        </div>
      </div>
      <div class="row justify-content-center">
        <div class="col-md-6 d-flex justify-content-start">
          <button type="submit" class="btn btn-primary">Register</button>
        </div>
      </div>
    </form>
  </div>
</template>


<script>
import axios from 'axios';

export default {
  data() {
    return {
      username: '',
      email: '',
      password: ''
    };
  },
  methods: {
    async submitForm() {
      try {
        const payload = {
          username: this.username,
          email: this.email,
          password: this.password
        };

        const response = await axios.post('http://localhost:5277/User/register', payload, {
          headers: {
            'Content-Type': 'application/json'
          }
        });

        
        console.log(response.data); // Handle response
        alert("You Registered!")
        this.$router.push('/login');

      } catch (error) {
        console.error('Error submitting form:', error.response ? error.response.data : error.message);
      }
    }
  }
};
</script>
