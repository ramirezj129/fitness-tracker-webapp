import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '@/views/HomeView.vue';
import ExerciseView from '@/views/ExerciseView.vue';
import LoginView from '@/views/LoginView.vue';
import MeasurementView from '@/views/MeasurementView.vue';
import RegisterView from '@/views/RegisterView.vue'


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/exercise',
      name: 'exercise',
      component: ExerciseView
    },
    {
      path: '/measurements',
      name: 'measurements',
      component: MeasurementView
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView
    },
    {
      path: '/register',
      name: 'register',
      component: RegisterView
    },
  
  
  ]
})

export default router
