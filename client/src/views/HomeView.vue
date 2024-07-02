<template>


      <!-- Main content specific to the home page -->
        <h1 class="workoutClass text-center">Fitness App Home Page</h1>
        <body class="container">
          
        <div class="bodyClass">

        <div class="row mt-5">
        <div class="col-6 d-flex justify-content-evenly">
          <img src="/icons/home-img.jpg" class="img"  alt="Description of the image">
        </div>

          <div class="col-6">
            <div class="home-desc">
              <p>This is my workout web app using .net backend with mssql database in order to access the features in this web app login/register in order to see more features</p>
                <p>Features Include: </p>
                <ul>
                  <li>creating exercises</li>
                  <li>measurement</li>
                  <li>run log</li>

                </ul>
               
          </div>
        </div>


          </div>
          <div  v-if="showAlert" class="alert alert-success position-absolute bottom-0 end-0 mb-5 me-3" style="display: block;" role="alert">
          You Have Successfully Logged In
        </div>

        </div>

    

        </body>
      
    
  </template>
  

  <script>
  import { mapState, mapMutations } from 'vuex';
  
  export default {
    computed: {
      ...mapState(['showAlert']),
    },
    methods: {
      ...mapMutations(['hideAlert']),
    },
    mounted() {
      if (this.showAlert) {
        setTimeout(() => {
          this.hideAlert();
        }, 3000);
      }
    }
  };
  </script>


<style>

body{
  overflow-y:auto;
}
li{
  padding-bottom: 8px;
}

.bodyClass {
background-color: #0f2537; 
padding: 15px;
min-height: 84vh;

}
.workoutClass {
  color: white;
  overflow-y: hidden
}

.img{
  object-fit: contain;
  width: 60%;
  margin-right: 50px;  
  border-radius: 10px;
}
.home-desc{
  font-size: large;
}


@media (max-width: 768px) {
  .img {
    width: 30%; 
    margin-right: 25px;
  }
}

  </style>
  