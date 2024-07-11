import { useState, useEffect } from "react";

const useLocalStorage = (key, initialValue) => {
  const readValue = () => {
    if (typeof window === "undefined") {
      return initialValue;
    }

    try {
      const item = window.localStorage.getItem(key);
      return item ? JSON.parse(item) : initialValue;
    } catch (error) {
      console.warn(`Ошибка при чтении ключа "${key}" из localStorage:`, error);
      return initialValue;
    }
  };

  const [storedValue, setStoredValue] = useState(readValue);

  const setValue = (value) => {
    try {
      const valueToStore =
        value instanceof Function ? value(storedValue) : value;
      setStoredValue(valueToStore);
      if (typeof window !== "undefined") {
        window.localStorage.setItem(key, JSON.stringify(valueToStore));
      }
    } catch (error) {
      console.warn(
        `Ошибка при установке ключа "${key}" в localStorage:`,
        error,
      );
    }
  };

  const removeValue = () => {
    try {
      setStoredValue(initialValue);
      if (typeof window !== "undefined") {
        window.localStorage.removeItem(key);
      }
    } catch (error) {
      console.warn(
        `Ошибка при удалении ключа "${key}" из localStorage:`,
        error,
      );
    }
  };

  useEffect(() => {
    setStoredValue(readValue());
  }, [key]);

  return [storedValue, setValue, removeValue];
};

export default useLocalStorage;
