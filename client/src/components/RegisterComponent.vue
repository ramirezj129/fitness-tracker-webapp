<template>
  <div class="container">
    <form class="register-form was-validated" id="register-form" @submit.prevent="submitForm">
      <div class="row mb-3 justify-content-center">
        <div class="col-md-6">
          <label for="username" class="form-label">Username</label>
          <input type="text" class="form-control" id="username" placeholder="Enter Username" required>
          <div class="invalid-feedback">Please provide a username.</div> <!-- Display validation feedback -->
        </div>
      </div>
      <div class="row mb-3 justify-content-center">
        <div class="col-md-6">
          <label for="email" class="form-label">Email</label>
          <input type="email" class="form-control" id="email" placeholder="Enter Email" required>
          <div class="invalid-feedback">Please provide a valid email address.</div> <!-- Display validation feedback -->
        </div>
      </div>
      <div class="row mb-3 justify-content-center">
        <div class="col-md-6">
          <label for="password" class="form-label">Password:</label>
          <input type="password" class="form-control" id="password" placeholder="Enter Password" required>
          <div class="invalid-feedback">Please provide a password.</div> <!-- Display validation feedback -->
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
  methods: {
    async submitForm() {
      try {
        const formData = new FormData(document.getElementById('register-form'));
        const jsonData = Object.fromEntries(formData.entries()); // Convert FormData to JSON

        console.log(formData)
        console.log(jsonData)

        const response = await axios.post('http://localhost:5277/User/register', jsonData, {
          headers: {
            'Content-Type': 'application/json'
          }
        });

        console.log(response.data); // Handle response
      } catch (error) {
        console.error('Error submitting form:', error);
      }
    }
  }
};
</script>
