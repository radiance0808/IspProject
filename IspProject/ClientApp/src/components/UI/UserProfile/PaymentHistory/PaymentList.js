import React, { useContext, useEffect, useState } from "react";
import AuthContext from "../../../store/AuthContext";
import UserContext from "../../../store/UserContext";
import Payments from "./Payments";


const PaymentList = () => {
  const [payments, setPayments] = useState([]);

  const authCtx = useContext(AuthContext);
  const userCtx = useContext(UserContext);
  const [Error, setError] = useState();
  const loadedPayments = [];

  useEffect(() => {
    const fetchUserData = async () => {
      let url = "https://localhost:7012/api/Payment";
      const response = await fetch(url, {
        method: "GET",
        headers: new Headers({
          Authorization: "Bearer " + authCtx.token,
        }),
      });
      if (!response.ok) {
        throw new Error("Something went wrong!");
      }

      const responseData = await response.json();

      for (const key in responseData) {
        loadedPayments.push({
          id: responseData[key].idPayment,
          idPayment: responseData[key].idPayment,
          amount: responseData[key].amount,
          date: responseData[key].date,
        });
      }
      setPayments(loadedPayments);
      userCtx.loadPaymentHistory(loadedPayments);
    };
    fetchUserData().catch((error) => {
      setError(error.message);
    });
  }, []);

  return(
    <Payments payments={payments}/>
  )
};

export default PaymentList;
