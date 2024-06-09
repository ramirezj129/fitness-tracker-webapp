<template>
  <div class="container">
    <!-- Form for creating a new exercise -->
    <form @submit.prevent="createExercise">
      <div class="row my-2 mt-5">
        <div class="col-sm-3">
          <label for="name" class="name-label form-label">Name:</label>
        </div>
        <div class="col-sm-9">
          <input
            class="form-control"
            placeholder="Enter Exercise Name"
            type="text"
            id="name"
            v-model="newExercise.name"
            required
          />
        </div>
      </div>
      <div class="row my-2">
        <div class="col-sm-3">
          <label for="sets" class="form-label">Sets:</label>
        </div>
        <div class="col-sm-9">
          <input
            class="form-control"
            placeholder="Enter Number of Sets"
            id="sets"
            type="number"
            v-model="newExercise.sets"
            required
          />
        </div>
      </div>
      <div class="row my-2">
        <div class="col-sm-3">
          <label for="reps" class="form-label">Reps:</label>
        </div>
        <div class="col-sm-9">
          <input
            class="form-control"
            placeholder="Enter number of Reps"
            id="reps"
            type="number"
            v-model="newExercise.reps"
            required
          />
        </div>
      </div>
      <div class="row my-2">
        <div class="col-sm-3">
          <label for="weight" class="form-label">Weight:</label>
        </div>
        <div class="col-sm-9">
          <input
            class="form-control"
            placeholder="Enter Weight Amount"
            id="weight"
            type="number"
            v-model="newExercise.weight"
            required
          />
        </div>
      </div>
      <div class="row my-2">
        <div class="col-sm-3">
          <label for="duration" class="form-label">Duration:</label>
        </div>
        <div class="col-sm-9">
          <input
            class="form-control"
            placeholder="Enter Duration (HH:mm:ss)"
            id="duration"
            v-model="newExercise.duration"
            required
          />
        </div>
      </div>
      <div class="d-flex justify-content-end">
        <button class="btn btn-secondary mt-3" type="submit">
          Create Exercise
        </button>
      </div>
    </form>

     <div class="mt-5 d-flex justify-content-between">
      <h3>Your Exercises</h3>
      <button class="btn btn-secondary" @click="fetchExercises">
        Get All Exercises
      </button>
    </div>

    <div v-if="exercises.length">
      <table class="table table-striped table-dark table-bordered mt-4">
        <thead>
          <tr>
            <th>Name</th>
            <th>Sets</th>
            <th>Reps</th>
            <th>Weight</th>
            <th>Duration</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="exercise in exercises" :key="exercise.id">
            <template v-if="isEditing === exercise.id">
              <td><input v-model="exercise.name" class="form-control"></td>
              <td><input v-model="exercise.sets" type="number" class="form-control"></td>
              <td><input v-model="exercise.reps" type="number" class="form-control"></td>
              <td><input v-model="exercise.weight" type="number" class="form-control"></td>
              <td><input v-model="exercise.duration" type="text" class="form-control"></td>
              <td class="text-center">
                <button class="btn btn-success mx-2 p-1" @click="saveEdit(exercise)">Save</button>
                <button class="btn btn-secondary p-1" @click="cancelEdit">Cancel</button>
              </td>
            </template>
            <template v-else>
              <td>{{ exercise.name }}</td>
              <td>{{ exercise.sets }}</td>
              <td>{{ exercise.reps }}</td>
              <td>{{ exercise.weight }}</td>
              <td>{{ exercise.duration }}</td>
              <td class="text-center">
                <button class="btn btn-primary mx-2 p-1" @click="editExercise(exercise.id)">Edit</button>
                <button class="btn btn-danger p-1" @click="deleteExercise(exercise.id)">Delete</button>
              </td>
            </template>
          </tr>
        </tbody>
      </table>
    </div>

    <div v-else>No exercises found.</div>
  </div>
</template>

<script>
import axios from 'axios';
import { mapState } from 'vuex';

export default {
  data() {
    return {
      exercises: [],
      newExercise: {
        name: '',
        sets: 0,
        reps: 0,
        weight: 0,
        duration: '',
      },
      isEditing: null,
      originalExercise: null,
    };
  },
  computed: {
    ...mapState(['token']),
  },
  methods: {
    async fetchExercises() {
      try {
        const response = await axios.get('http://localhost:5277/api/Exercise', {
          headers: {
            Authorization: `Bearer ${this.token}`,
          },
        });
        this.exercises = response.data;
      } catch (error) {
        console.error('Error fetching exercises:', error);
      }
    },
    async createExercise() {
      try {
        const response = await axios.post(
          'http://localhost:5277/api/Exercise',
          this.newExercise,
          {
            headers: {
              Authorization: `Bearer ${this.token}`,
            },
          }
        );
        this.exercises.push(response.data);
        this.newExercise = {
          name: '',
          sets: 0,
          reps: 0,
          weight: 0,
          duration: '',
        };
      } catch (error) {
        console.error('Error creating exercise:', error.response ? error.response.data : error.message);
      }
    },
    async deleteExercise(id) {
      try {
        await axios.delete(`http://localhost:5277/api/Exercise/${id}`, {
          headers: {
            Authorization: `Bearer ${this.token}`,
          },
        });
        this.exercises = this.exercises.filter(exercise => exercise.id !== id);
      } catch (error) {
        console.error('Error deleting exercise:', error);
      }
    },
    editExercise(id) {
      this.isEditing = id;
      const exercise = this.exercises.find(exercise => exercise.id === id);
      this.originalExercise = { ...exercise };
    },
    async saveEdit(exercise) {
      try {
        await axios.put(`http://localhost:5277/api/Exercise/${exercise.id}`, exercise, {
          headers: {
            Authorization: `Bearer ${this.token}`,
          },
        });
        this.isEditing = null;
        this.originalExercise = null;
      } catch (error) {
        console.error('Error updating exercise:', error);
        this.cancelEdit();
      }
    },
    cancelEdit() {
      if (this.originalExercise) {
        const index = this.exercises.findIndex(exercise => exercise.id === this.originalExercise.id);
        this.exercises.splice(index, 1, this.originalExercise);
        this.originalExercise = null;
      }
      this.isEditing = null;
    },
  },
  mounted() {
    this.fetchExercises();
  },
};
</script>

<style>
.exercise-form {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

label {
  color: white;
}

body {
  overflow-y: auto !important;
}

div {
  color: white;
}
</style>