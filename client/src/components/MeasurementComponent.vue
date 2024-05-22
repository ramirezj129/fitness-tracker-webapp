<template>
    <div class="container text-white ">
      <div class="row">
        <div class="col-md-6">
          <img src="/icons/measurement.jpg" class="img-fluid" alt="Description of the image">
        </div>
        <div class="col-md-6">
          <form @submit.prevent="submitForm">
            <div class="mb-3">
              <label for="name" class="form-label">Type of Measurement</label>
              <input type="text" class="form-control" id="name" v-model="formData.name" required>
            </div>
            <div class="mb-3">
              <label for="amount" class="form-label">Enter Amount</label>
              <input type="amount" class="form-control" id="amount" v-model="formData.email" required>
            </div>
            <div class="mb-3">
              <label for="date" class="form-label">Enter Date</label>
              <input type="date" class="form-control" id="date" v-model="formData.email" required>
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
          </form>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        imageSrc: 'path/to/your/image.jpg',
        formData: {
          type: '',
          amount: '',
          date:''
        }
      };
    },
    methods: {
      submitForm() {
        // Handle form submission
        console.log(this.formData);
      }
    }
  };
  </script>
  
  <style scoped>
  .container {
    margin-top: 20px;
  }
  </style>
  