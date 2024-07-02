<template>
  <div class="container">
    <form @submit.prevent="login">
      <div class="row mb-3 justify-content-center">
        <div class="col-md-6">
          <label for="email" class="form-label">User or Email:</label>
          <input 
            type="text" 
            class="form-control" 
            id="username" 
            v-model="username" 
            placeholder="Enter username or email" 
            required 
          />
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
            placeholder="Enter password" 
            required 
          />
        </div>
      </div>
      <div class="row justify-content-center">
        <div class="col-md-6 d-flex justify-content-between">
          <button type="submit" class="btn btn-primary">Login</button>
          <router-link to="/register" class="btn btn-primary">Register</router-link>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import { mapMutations } from 'vuex';
import axios from 'axios';

export default {
  data() {
    return {
      username: '',
      password: ''
    };
  },
  methods: {
    ...mapMutations(['setAuthenticated', 'showAlert']),
    async login() {
      try {
        const response = await axios.post('http://localhost:5277/User/login/', {
          username: this.username,
          password: this.password
        });
        const token = response.data;
        localStorage.setItem('token', token);
        this.setAuthenticated(true);
        this.showAlert();

        this.$router.push('/');
      } catch (error) {
        console.error('Error during login:', error);
      }
    },






  }
};
</script>
