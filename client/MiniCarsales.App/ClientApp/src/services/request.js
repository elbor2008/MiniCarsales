import axios from 'axios';
import alertifyjs from 'alertifyjs';
import { BASE_URL } from './config';

axios.defaults.baseURL = BASE_URL;

axios.interceptors.response.use(res => {
  return res.data;
}, error => {
  if (error && error.message && error.message === "Network Error") {
    alertifyjs.error('network error');
  } else if (error.response) {
    switch (error.response.status) {
      case 400:
        alertifyjs.error('bad request from client');
        break;
      case 500:
        alertifyjs.error('server error');
        break;
      default:
        alertifyjs.error('server error');
        break;
    }
  }
  throw error.response;
});

const carAgent = {
  getCarList: () => axios.get('cars'),
  addCar: car => axios.post('cars', { ...car }),
  deleteCar: id => axios.delete(`cars/${id}`)
};

export { carAgent };