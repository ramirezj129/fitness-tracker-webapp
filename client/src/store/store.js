import { createStore } from 'vuex';

const store = createStore({
  state: {
    isAuthenticated: false
  },
  mutations: {
    setAuthenticated(state, value) {
      state.isAuthenticated = value;
    }
  }
});

export default store;
