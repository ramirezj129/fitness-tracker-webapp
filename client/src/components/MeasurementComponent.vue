<template>
  <div class="container text-white">
    <div class="row d-flex justify-content-evenly">
      <div class="col-md-6">
        <img src="/icons/measurement.jpg" class="img-fluid" alt="Description of the image">
      </div>
      <div class="col-md-6">
        <form @submit.prevent="createMeasurement">
          <div class="mb-3">
            <label for="name" class="form-label">Type of Measurement</label>
            <input
              type="text"
              class="form-control"
              id="name"
              v-model="newMeasurement.type"
              placeholder="Measurement"
              required
            />
          </div>
          <div class="mb-3">
            <label for="amount" class="form-label">Enter Amount</label>
            <input
              type="number"
              class="form-control"
              id="amount"
              v-model="newMeasurement.value"
              placeholder="Number Amount"
              required
            />
          </div>
          <div class="mb-3">
            <label for="date" class="form-label">Enter Date</label>
            <input
              type="date"
              class="form-control"
              id="date"
              v-model="newMeasurement.date"
              required
            />
          </div>
          <button type="submit" class="btn btn-primary">Submit</button>
        </form>



      </div>

      <div class="mt-5">
        <h5>Your Measurements Log:</h5>
      </div>

      <div v-if="measurements.length">
        <table class="table table-dark table-striped table-bordered mt-3">
          <thead>
            <tr>
              <th>Measurement Type</th>
              <th>Measurement</th>
              <th>Date Recorded</th>
              <th>Actions</th>

            </tr>
           

          </thead>


          <tbody>

            <tr v-for="measurement in measurements" :key="measurement.id">
              <template v-if="isEditing === measurement.id">
              <td><input v-model="measurement.name" class="form-control"></td>
              <td><input v-model="measurement.sets" type="number" class="form-control"></td>
              <td><input v-model="measurement.reps" type="number" class="form-control"></td>
              <td class="text-center">
                <button class="btn btn-success mx-2 p-1" @click="saveEdit(measurement)">Save</button>
                <button class="btn btn-secondary p-1" @click="cancelEdit">Cancel</button>
              </td>
            </template>
            <template v-else>
              <td>{{ measurement.type }}</td>
              <td>{{ measurement.value }}</td>
              <td>{{ measurement.date }}</td>
              <td class="text-center">
                <button class="btn btn-primary mx-2 p-1" @click="editMeasurement(measurement.id)">Edit</button>
                <button class="btn btn-danger p-1" @click="deleteMeasurement(measurement.id)">Delete</button>
              </td>
            </template>
          </tr>
        </tbody>
        </table>
      </div>

    </div>
  </div>
</template>

  <script>
import axios from 'axios';
import { mapState } from 'vuex';

export default {
  data() {
    return {
      measurements: [],
      newMeasurement: {
        type: '',
        value: 0,
        date: '',
      },
      isEditing: null,
      originalMeasurement: null,
    };
  },
  computed: {
    ...mapState(['token']),
  },
  methods: {
    async fetchMeasurements() {
      try {
        const response = await axios.get('http://localhost:5277/api/Measurement', {
          headers: {
            Authorization: `Bearer ${this.token}`,
          },
        });
        this.measurements = response.data;
      } catch (error) {
        console.error('Error fetching measurements:', error);
      }
    },
    async createMeasurement() {
      try {
        const response = await axios.post(
          'http://localhost:5277/api/Measurement',
          this.newMeasurement,
          {
            headers: {
              Authorization: `Bearer ${this.token}`,
            },
          }
        );
        this.measurements.push(response.data);
        this.newMeasurement = {
          type: '',
          value: 0,
          date: '',
        };
      } catch (error) {
        console.error('Error creating measurement:', error.response ? error.response.data : error.message);
      }
    },
    async deleteMeasurement(id) {
      try {
        await axios.delete(`http://localhost:5277/api/Measurement/${id}`, {
          headers: {
            Authorization: `Bearer ${this.token}`,
          },
        });
        this.measurements = this.measurements.filter(measurement => measurement.id !== id);
      } catch (error) {
        console.error('Error deleting measurement:', error);
      }
    },
    editMeasurement(id) {
      this.isEditing = id;
      const measurement = this.measurements.find(measurement => measurement.id === id);
      this.originalMeasurement = { ...measurement };
    },
    async saveEdit(measurement) {
      try {
        await axios.put(`http://localhost:5277/api/Measurement/${measurement.id}`, measurement, {
          headers: {
            Authorization: `Bearer ${this.token}`,
          },
        });
        this.isEditing = null;
        this.originalMeasurement = null;
      } catch (error) {
        console.error('Error updating measurement:', error);
        this.cancelEdit();
      }
    },
    cancelEdit() {
      if (this.originalMeasurement) {
        const index = this.measurements.findIndex(measurement => measurement.id === this.originalMeasurement.id);
        this.measurements.splice(index, 1, this.originalMeasurement);
        this.originalMeasurement = null;
      }
      this.isEditing = null;
    },
  },
  mounted() {
    this.fetchMeasurements();
  },
};

</script>
  
  <style scoped>
  .container {
    margin-top: 20px;
  }
  .img-fluid{
    width: 100%;
  }
  </style>
  