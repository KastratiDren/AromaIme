// src/useAuth.js
import { reactive, computed } from 'vue';

const state = reactive({
  isLoggedIn: !!localStorage.getItem('token'),
  username: localStorage.getItem('userName') || ''
});

export function useAuth() {
  const login = (token, userName) => {
    state.isLoggedIn = true;
    state.username = userName;
    localStorage.setItem('token', token);
    localStorage.setItem('userName', userName);
  };

  const logout = () => {
    state.isLoggedIn = false;
    state.username = '';
    localStorage.removeItem('token');
    localStorage.removeItem('userName');
  };

  return {
    state: computed(() => state),
    login,
    logout
  };
}
