import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:7143',
  headers: {
    'Content-Type': 'application/json',
  },
  timeout: 10000,
});

export default api;

