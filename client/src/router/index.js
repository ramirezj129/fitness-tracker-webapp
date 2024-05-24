import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '@/views/HomeView.vue';
import ExerciseView from '@/views/ExerciseView.vue';
import LoginView from '@/views/LoginView.vue';
import MeasurementView from '@/views/MeasurementView.vue';
import RegisterView from '@/views/RegisterView.vue';
import store from '../store/store';

const routes = [
  { path: '/', name: 'home', component: HomeView },
  { path: '/exercise', name: 'exercise', component: ExerciseView, meta: { requiresAuth: true } },
  { path: '/measurements', name: 'measurements', component: MeasurementView, meta: { requiresAuth: true } },
  { path: '/login', name: 'login', component: LoginView },
  { path: '/register', name: 'register', component: RegisterView }
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
});

router.beforeEach((to, from, next) => {
  const isAuthenticated = store.state.isAuthenticated || localStorage.getItem('token');
  if (to.matched.some(record => record.meta.requiresAuth) && !isAuthenticated) {
    next({ name: 'login' });
  } else {
    next();
  }
});

export default router;
