<template>
  <div class="container">
    <form>
      <div class="row mb-3 justify-content-center">
        <div class="col-md-6">
          <label for="email" class="form-label">Email:</label>
          <input type="text" class="form-control" id="username" placeholder="Enter username or email">
        </div>
      </div>
      <div class="row mb-3 justify-content-center">
        <div class="col-md-6">
          <label for="password" class="form-label">Password:</label>
          <input type="password" class="form-control" id="password" placeholder="Enter password">
        </div>
      </div>
      <div class="row justify-content-center">
        <div class="col-md-6 d-flex justify-content-between">
          <button type="submit" class="btn btn-primary">Login</button>
          <button type="submit" class="btn btn-primary">Register</button>
        </div>
      </div>
    </form>
  </div>
</template>
