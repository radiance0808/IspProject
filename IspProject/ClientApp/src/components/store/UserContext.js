import React, { useContext } from "react";
import { useState } from "react/cjs/react.development";
import AuthContext from "./AuthContext";




const UserContext = React.createContext({
  balance: 30,
  notifications: "sms",
  equipment: "Mikrotik",
  paymentHistory: [
    {
      payment_id: "123",
      date: new Date(2022, 5, 2),
      amount: 50.0,
    },
    { payment_id: "234", date: new Date(2022, 6, 3), amount: 30.0 },

    { payment_id: "423", date: new Date(2022, 6, 3), amount: 30.0 },
    { payment_id: "456", date: new Date(2022, 6, 3), amount: 30.0 },
    { payment_id: "345", date: new Date(2022, 7, 4), amount: 20.0 },
  ],
  updateBalance: (value) => { },
});




const getUserData = () => {
  const authCtx = useContext(AuthContext);

    let balance;
    let notifications;
    let equipment;
    let paymentHistory;
    let isActive;

    const axios = require('axios');

    axios.post('https://localhost:7012/api/Account', {
      token: authCtx.token
    })
    .then((response) => {
      balance = response.data.balance;
      notifications = response.data.notifications;
      equipment = response.data.equipment;
      isActive = response.data.isActive;
      paymentHistory = response.data.paymentHistory;
      console.log(response);
    }, (error) => {
      console.log(error);
    });
}

export const UserContextProvider = (props) => {

  const userData = getUserData();


  const [balance, setBalance] = useState(userData.balance);
  const [notifications, setNotifications] = useState(userData.notifications);
  const [equipment, setEquipment] = useState(userData.equipment);
  const [isActive, setIsActive] = useState(userData.isActive);
  const [paymentHistory, setPaymentHistory] = useState(userData.paymentHistory);

  const updateBalanceHandler = () => {

  }
  const freezeAccountHandler = () => {

  }

  const contextValue = {
    balance: balance,
    notifications: notifications,
    equipment: equipment,
    isActive: isActive,
    paymentHistory: paymentHistory,
    updateBalance: updateBalanceHandler,
    freezeAccount: freezeAccountHandler,
  };
  
  const updateBalance = (value) => {

  };
  return (
    <UserContext.Provider
      value={contextValue}
    >{props.children}</UserContext.Provider>
  );
};

export default UserContext;
