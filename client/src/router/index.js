import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '@/views/HomeView.vue';
import ExerciseView from '@/views/ExerciseView.vue';
import LoginView from '@/views/LoginView.vue';
import MeasurementView from '@/views/MeasurementView.vue';


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
      path: '/measurement',
      name: 'measurement',
      component: MeasurementView
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView
    },
  
  
  ]
})

export default router
