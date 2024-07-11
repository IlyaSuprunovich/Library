import axios from "axios";
import { useLocalStorageContext } from "./helpers/hooks/loginProvider";
import { AXIOS_DEFAULTS_BASE_URL } from "./helpers/constants/constants";

axios.defaults.baseURL = AXIOS_DEFAULTS_BASE_URL;
const { token, setToken } = useLocalStorageContext();

axios.interceptors.request.use(
  (config) => {
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  },
);
