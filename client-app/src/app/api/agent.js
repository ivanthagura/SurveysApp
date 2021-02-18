import axios from 'axios';
import { toast } from 'react-toastify';

axios.defaults.baseURL = process.env.REACT_APP_API_URL;

const responseBody = (response) => response.data;

axios.interceptors.response.use(undefined, (error) => {
    if (error.message === 'Network Error' && !error.response) {
      toast.error('Network error - make sure API is running');
    }
    const { status, data, config } = error.response;
    if (status === 404) {
        toast.error('Network Error');
    }
    if (
      status === 400 &&
      config.method === 'get' &&
      data.errors.hasOwnProperty('id')
    ) {
        toast.error('Page not found');
    }
    if (status === 500) {
      toast.error('Server error - check the terminal for more info!');
    }
    throw error.response;
  });

  const requests = {
    get: (url) => axios.get(url).then(responseBody),
    post: (url, body) => axios.post(url, body).then(responseBody),
  };

  const Surveys = {
      list: () => requests.get('/survey'),
      details: (id) => requests.get(`/survey/${id}`),
      submit: (surveyResponse) => requests.post('/survey', surveyResponse) 
  };

  // eslint-disable-next-line import/no-anonymous-default-export
  export default{
    Surveys 
  };