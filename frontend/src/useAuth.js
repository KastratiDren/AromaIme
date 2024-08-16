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
        state,
        login,
        logout
    };
}