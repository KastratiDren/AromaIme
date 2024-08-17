import { reactive, computed } from 'vue';

const state = reactive({
  isLoggedIn: !!localStorage.getItem('token'),
  username: localStorage.getItem('userName') || '',
  role: localStorage.getItem('role') || '' // Add role state
});

export function useAuth() {
  const login = (token, userName, role) => {
    state.isLoggedIn = true;
    state.username = userName;
    state.role = role; // Set role
    localStorage.setItem('token', token);
    localStorage.setItem('userName', userName);
    localStorage.setItem('role', role); // Save role to localStorage
  };

  const logout = () => {
    state.isLoggedIn = false;
    state.username = '';
    state.role = ''; // Clear role
    localStorage.removeItem('token');
    localStorage.removeItem('userName');
    localStorage.removeItem('role'); // Remove role from localStorage
  };

  return {
    state: computed(() => state),
    login,
    logout
  };
}

