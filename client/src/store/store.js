// store.js
import { createStore } from 'vuex';

const store = createStore({
  state: {
    isAuthenticated: !!localStorage.getItem('token')
  },
  mutations: {
    setAuthenticated(state, value) {
      state.isAuthenticated = value;
      if (!value) {
        localStorage.removeItem('token');
      }
    }
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
  }
});

export default store;
