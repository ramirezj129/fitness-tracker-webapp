import { createStore } from 'vuex';

const store = createStore({
  state: {
    token: localStorage.getItem('token') || null,
    isAuthenticated: !!localStorage.getItem('token'),
    showAlert: false,

  },
  mutations: {
    setAuthenticated(state, isAuthenticated) {
      state.isAuthenticated = isAuthenticated;
      state.token = isAuthenticated ? localStorage.getItem('token') : null;
    },
    showAlert(state) {
      state.showAlert = true;
    },
    hideAlert(state) {
      state.showAlert = false;
    },
  },
  actions: {
    login({ commit }, token) {
      localStorage.setItem('token', token);
      commit('setAuthenticated', true);
    },
    logout({ commit }) {
      localStorage.removeItem('token');
      commit('setAuthenticated', false);
    }
  },
  getters: {
    isAuthenticated(state) {
      return state.isAuthenticated;
    }
  },
  
});

export default store;
