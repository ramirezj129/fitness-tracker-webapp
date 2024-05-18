<script>
 import HeaderComponent from './components/HeaderComponent.vue'; // Import the Header component
  
  export default {
    components: {
      HeaderComponent // Register the Header component
    }
  }


</script>

<template>
  <div class="app">
    <!-- Your navigation, header, and other common components -->
    

      <HeaderComponent /> <!-- Display the header component -->

    
      
    <!-- Main content area -->
    <router-view />

    <!-- Footer or other common components -->
  </div>
</template>

<style>
/* Set background color for entire application */
html, body {
  margin: 0;
  padding: 0;
  height: 100%;
  background-color: #0f2537; /* Set background color */
}

/* Style for the root component */
.app {
  overflow-y: auto; /* Enable vertical scrollbar if content exceeds viewport height */
  overflow-x: hidden; /* Hide horizontal scrollbar */
  margin: 0;
  background-color: #0f2537; /* Set background color */
  

}

</style>
