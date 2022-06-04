import React from "react";

const UserContext = React.createContext({
    balance: 30,
    notifications: "sms",
    equipment: "Mikrotik",
    currentTariff: "Pro 200",
    paymentHistory:[{
        payment_id: "123",
        date: new Date(2022, 5, 2),
        amount: 50.0,
      },
      { payment_id: "234", date: new Date(2022, 6, 3), amount: 30.0 },
    
      { payment_id: "423", date: new Date(2022, 6, 3), amount: 30.0 },
      { payment_id: "456", date: new Date(2022, 6, 3), amount: 30.0 },
      { payment_id: "345", date: new Date(2022, 7, 4), amount: 20.0 },]
  });

  export default UserContext;