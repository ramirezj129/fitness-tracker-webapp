import { createStore } from 'vuex';

const store = createStore({
  state: {
    token: localStorage.getItem('token') || null,
    isAuthenticated: !!localStorage.getItem('token')
  },
  mutations: {
    setToken(state, token) {
      state.token = token;
      state.isAuthenticated = !!token;
    },
    clearToken(state) {
      state.token = null;
      state.isAuthenticated = false;
    }
  },
  actions: {
    login({ commit }, token) {
      localStorage.setItem('token', token);
      commit('setToken', token);
    },
    logout({ commit }) {
      localStorage.removeItem('token');
      commit('clearToken');
    }
  }
});

export default store;
