<template>
  <div class="app">
    <HeaderComponent /> 
    <router-view />
  </div>
</template>

<script>
import HeaderComponent from './components/HeaderComponent.vue'; // Import the Header component
import { mapGetters } from 'vuex';

export default {
  components: {
    HeaderComponent // Register the Header component
  },
  computed: {
    ...mapGetters(['isAuthenticated'])
  },
  watch: {
    isAuthenticated(newVal) {
      if (!newVal) {
        this.$router.push('/login');
      }
    }
  }
}
</script>

<style>
html, body {
  margin: 0;
  padding: 0;
  height: 100%;
  background-color: #0f2537; 
}

.app {
  overflow-y: auto; 
  overflow-x: hidden; 
  margin: 0;
  background-color: #0f2537;
}
</style>
