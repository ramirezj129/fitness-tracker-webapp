<template>


      <!-- Main content specific to the home page -->
        <h1 class="workoutClass text-center">Fitness App Home Page</h1>
        <body class="container">
          
        <div class="bodyClass">

        <div class="row mt-5">
        <div class="col-md-12 d-flex justify-content-center">
          <img src="/icons/home-img.jpg" class="img-fluid" style="border-radius: 10px;" alt="Description of the image">
          <div class="col-md-6">
            <div class="home-desc">
              <p>This is my workout web app using .net backend with mssql database in order to access the features in this web app login/register in order to see more features</p>
                <p>Feature Include: </p>
                <ul>
                  <li>creating exercises</li>
                  <li>measurement</li>
                  <li>run log</li>

                </ul>
               
            </div>
          </div>
        </div>

          </div>

        </div>
        </body>
      
    
  </template>
  
<script>



</script>



<style>

body{
  overflow-y:auto;
}
li{
  padding-bottom: 8px;
}

.bodyClass {
background-color: #0f2537; /* Background color for the main content area */
padding: 15px; /* Add padding as needed */
min-height: 84vh;

}
.workoutClass {
  color: white;
  overflow-y: hidden /* Text color for the welcome heading */
}

.img-fluid{
  object-fit: contain;
  width: 40%;
  margin-right: 50px;  
}
.home-desc{
  font-size: large;
}


/* Media query for smaller screens */
@media (max-width: 768px) {
  .img-fluid {
    width: 250%; /* Adjust the width as needed */
    margin-right: 25px; /* Adjust the margin as needed */
  }
}
 
  </style>
  