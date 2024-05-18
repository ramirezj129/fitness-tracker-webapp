<template>
  <div class="container">
    <!-- Your exercise component content here -->
    
    <!-- Form for creating a new exercise -->
    <form @submit.prevent="createExercise">
      <div class="row my-2">
        <div class="col-sm-3">
          <label for="name" class="name-label form-label">Name:</label>
        </div>
        <div class="col-sm-9">
          <input class="form-control" placeholder="Enter Exercise Name" type="text" id="name" v-model="newExercise.name">
        </div>
      </div>
      
      <div class="row my-2">
        <div class="col-sm-3">
          <label for="sets" class="form-label">Sets:</label>
        </div>
        <div class="col-sm-9">
          <input class="form-control" placeholder="Enter Number of Sets" id="sets" v-model="newExercise.sets">
        </div>
      </div>
      
      <div class="row my-2">
        <div class="col-sm-3">
          <label for="reps" class="form-label">Reps:</label>
        </div>
        <div class="col-sm-9">
          <input class="form-control" placeholder="Enter number of Reps" type="number" id="reps" v-model="newExercise.reps">
        </div>
      </div>
      
      <div class="row my-2">
        <div class="col-sm-3">
          <label for="weight" class="form-label">Weight:</label>
        </div>
        <div class="col-sm-9">
          <input class="form-control" placeholder="Enter Weight Amount" type="number" id="weight" v-model="newExercise.weight">
        </div>
      </div>
      
      <div class="row my-2">
        <div class="col-sm-3">
          <label for="duration" class="form-label">Duration:</label>
        </div>
        <div class="col-sm-9">
          <input class="form-control" type="text" placeholder="Enter Duration of Workout" id="duration" v-model="newExercise.duration">
        </div>
      </div>
      <div class="d-flex justify-content-end">
        <button class="btn btn-secondary mt-3" type="submit">Create Exercise</button>
      </div>
    </form>

    <!-- Display fetched exercises -->
    <div class="mt-5 d-flex justify-content-between">
      <h3>Your Exercises</h3>
      <button class="btn btn-secondary" @click="fetchExercises">Get All Exercises</button>
    </div>
    
    <!-- Display fetched exercises -->
    <div v-if="exercises.length">
      <!-- Exercise table -->
      <p v-for="exercise in exercises" :key="exercise.id">
        <table class="table table-striped table-bordered mt-4">
          <!-- Table headers -->
          <thead class="table-dark">
            <tr>
              <th>Name</th>
              <th>Sets</th>
              <th>Reps</th>
              <th>Weight</th>
              <th>Duration</th>
            </tr>
          </thead>
          <!-- Table body -->
          <tbody>
            <tr>
              <td>{{ exercise.name }}</td>
              <td>{{ exercise.sets }}</td>
              <td>{{ exercise.reps }}</td>
              <td>{{ exercise.weight }}</td>
              <td>{{ exercise.duration }}</td>
            </tr>
          </tbody>
        </table>
      </p>
    </div>
    <!-- Display message if no exercises found -->
    <div v-else>
      No exercises found.
    </div>
  </div>
</template>

<!-- Script section... -->

<!-- Style section... -->


  <script>
  import axios from 'axios';
  
  export default {
    data() {
      return {
        exercises: [],
        newExercise: {
          name: '',
          sets: 0,
          reps: 0,
          weight: 0,
          duration: ''
        }
      };
    },
    methods: {
      async fetchExercises() {
  try {
    const response = await axios.get('http://localhost:5000/api/Exercises');
    this.exercises = response.data;
  } catch (error) {
    console.error('Error fetching exercises:', error);
  }
},
async createExercise() {
  try {
    const response = await axios.post('http://localhost:5000/api/Exercises', this.newExercise);
    this.exercises.push(response.data);
    this.newExercise = {
      name: '',
      sets: 0,
      reps: 0,
      weight: 0,
      duration: ''
    };
  } catch (error) {
    console.error('Error creating exercise:', error);
  }
},

      // Add methods for updating and deleting exercises as needed
    }
  };
  </script>
  
<style>
.exercise-form {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

label{
  color: white;

}

body{
  overflow-y: auto !important;
}


div{
  color: white;
}

</style>