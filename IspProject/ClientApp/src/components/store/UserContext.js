import React from "react";
import { useState } from "react/cjs/react.development";

const UserContext = React.createContext({
  balance: 0,
  notifications: "",
  equipment: "",
  plan: "",
  paymentHistory: [],
  updateBalance: (value) => {},
  loadData: (balance, notifications, equipment, plan, isActive) => {},
  loadPaymentHistory: (paymentHistory) => {},
});

export const UserContextProvider = (props) => {
  const [balance, setBalance] = useState(0);
  const [notifications, setNotifications] = useState("");
  const [equipment, setEquipment] = useState("");
  const [plan, setPlan] = useState("");
  const [isActive, setIsActive] = useState(null);
  const [paymentHistory, setPaymentHistory] = useState([]);
  const freezeAccountHandler = () => {};
  const loadDataHandler = (
    balance,
    notifications,
    equipment,
    plan,
    isActive
  ) => {
    setBalance(balance);
    setNotifications(notifications);
    setEquipment(equipment);
    setPlan(plan);
    setIsActive(isActive);
  };

  const loadPaymentHistory = (paymentHistory) => {
    setPaymentHistory(paymentHistory);
  }

  const contextValue = {
    balance: balance,
    notifications: notifications,
    equipment: equipment,
    plan: plan,
    isActive: isActive,
    paymentHistory: paymentHistory,
    freezeAccount: freezeAccountHandler,
    loadData: loadDataHandler,
    loadPaymentHistory: loadPaymentHistory,
  };

  return (
    <UserContext.Provider value={contextValue}>
      {props.children}
    </UserContext.Provider>
  );
};

export default UserContext;
