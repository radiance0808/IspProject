import React, { useState, useEffect, useCallback } from 'react';

let logoutTimer;

const AuthContext = React.createContext({
  token: '',
  role: '',
  isLogged: false,
  UserIsClient: false,
  UserIsAdmin: false,
  login: (token, role) => { },
  logout: () => { },
});

const calculateRemainingTime = (expirationTime) => {
  const currentTime = new Date().getTime();
  const adjExpirationTime = new Date(expirationTime).getTime();

  const remainingDuration = adjExpirationTime - currentTime;

  return remainingDuration;
};

const retrieveStoredToken = () => {
  const storedToken = localStorage.getItem('token');
  const storedRole = localStorage.getItem('role');
  const storedExpirationDate = localStorage.getItem('expirationTime');

  const remainingTime = calculateRemainingTime(storedExpirationDate);

  if (remainingTime <= 3600) {
    localStorage.removeItem('token');
    localStorage.removeItem('expirationTime');
    localStorage.removeItem('role');
    return null;
  }

  return {
    token: storedToken,
    role: storedRole,
    duration: remainingTime,
  };
};

export const AuthContextProvider = (props) => {
  const tokenData = retrieveStoredToken();

  let userIsAdmin;
  let userIsClient;
  let initialToken;
  let initialRole;

  if (tokenData) {
    initialToken = tokenData.token;
    initialRole = tokenData.role;
    if (initialRole === "Admin") {
      console.log(initialRole);
      userIsAdmin = true;
    }
    if (initialRole === "Client") {
      console.log(initialRole);
      userIsClient = true;
    }
  }


  const [token, setToken] = useState(initialToken);
  const [role, setRole] = useState(initialRole);
  const [isAdmin, setIsAdmin] = useState(userIsAdmin);
  const [isClient, setIsClient] = useState(userIsClient);


  const userIsLoggedIn = !!token;

  const logoutHandler = useCallback(() => {
    setToken(null);
    setRole(null);
    setIsAdmin(false);
    setIsClient(false);
    localStorage.removeItem('token');
    localStorage.removeItem('expirationTime');
    localStorage.removeItem('role');

    if (logoutTimer) {
      clearTimeout(logoutTimer);
    }
  }, []);

  const loginHandler = (token, expirationTime, role) => {
    setToken(token);
    setRole(role);
    localStorage.setItem('token', token);
    localStorage.setItem('expirationTime', expirationTime);
    localStorage.setItem('role', role);

    if (role === "Admin") {
      setIsAdmin(true);
    }
    if (role === "Client") {
      setIsClient(true);
    }


    const remainingTime = calculateRemainingTime(expirationTime);


    logoutTimer = setTimeout(logoutHandler, remainingTime);
  };

  useEffect(() => {
    if (tokenData) {
      logoutTimer = setTimeout(logoutHandler, tokenData.duration);
    }
  }, [tokenData, logoutHandler]);

  const contextValue = {
    token: token,
    isLogged: userIsLoggedIn,
    UserIsClient: isClient,
    UserIsAdmin: isAdmin,
    login: loginHandler,
    logout: logoutHandler,
    role: role,
  };

  return (
    <AuthContext.Provider value={contextValue}>
      {props.children}
    </AuthContext.Provider>
  );
};

export default AuthContext;