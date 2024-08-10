/** @type {import('tailwindcss').Config} */
export default {
  content: ['./index.html', './src/**/*.{vue,js,ts,jsx,tsx}'],
  theme: {
    extend: {
      fontFamily: {
        sans: ['Poppins', 'sans-serif'],
      },
      gridTemplateColumns: {
        '70/30': '70% 28%',
      },
      colors: {
        primary: '#7A1E4D',
        secondary: '#61183E',
        hover: '#4E1332',
      }
    },
  },
  variants: {
    extend: {},
  },
  plugins: [],
};

