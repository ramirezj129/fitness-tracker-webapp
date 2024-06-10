<template>
  <nav class="navbar navbar-expand-lg bg-dark" data-bs-theme="dark">
    <div class="container-fluid">
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarColor02" aria-controls="navbarColor02" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarColor02">
        <ul class="navbar-nav me-auto">
          <li class="nav-item">
            <router-link to="/" class="nav-link" @click="collapseNavbar">
              Home <i class="navbar-brand fa-solid fa-house px-1"></i>      
            </router-link> 
          </li>
          <li class="nav-item" v-if="isAuthenticated">
            <router-link to="/exercise" class="nav-link" @click="collapseNavbar">
              Exercise <i class="navbar-brand fa-solid fa-dumbbell px-1"></i>
            </router-link>
          </li>
          <li class="nav-item" v-if="isAuthenticated">
            <router-link to="/measurements" class="nav-link" @click="collapseNavbar">
              Measurements <i class="navbar-brand fa-solid fa-weight-scale px-1"></i>
            </router-link>
          </li>      
        </ul>
        <ul class="navbar-nav">
          <li v-if="!isAuthenticated" class="nav-item">
            <router-link to="/login" class="nav-link" @click="collapseNavbar">
              Login <i class="navbar-brand fa-solid fa-user px-1"></i>
            </router-link>
          </li>
          <li v-if="isAuthenticated" class="nav-item">
            <button class="nav-link" @click="logout">
              Logout <i class="navbar-brand fa-solid fa-sign-out-alt px-1"></i>
            </button>
          </li>
        </ul>
      </div>
    </div>
  </nav>
</template>

<script>
import { mapState, mapActions } from 'vuex';

export default {
  computed: {
    ...mapState(['isAuthenticated'])
  },
  methods: {
    ...mapActions(['logout']),
    collapseNavbar() {
      const navbarToggler = document.querySelector('.navbar-toggler');
      const navbarCollapse = document.querySelector('.navbar-collapse');
      if (navbarToggler && navbarCollapse) {
        navbarToggler.classList.add('collapsed');
        navbarCollapse.classList.remove('show');
      }
    }
  }
}
</script>

<style scoped>
.nav-link {
  font-size: 18px;
}
.nav-item {
  padding-right: 0px; /* Adjust padding around the icons */
}
nav {
  margin: 15px;
  background-color: #0f2537;
  overflow-y: auto;
  border-radius: 15px;
}
</style>
