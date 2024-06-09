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
    

      <HeaderComponent /> 

    
      
   
    <router-view />

 
  </div>
</template>

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
