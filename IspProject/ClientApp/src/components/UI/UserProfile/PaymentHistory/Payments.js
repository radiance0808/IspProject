import React, { useState, useEffect, useContext } from "react";
import AuthContext from "../../../store/AuthContext";
import UserContext from "../../../store/UserContext";
import Payment from "./Payment";
import classes from "./Payments.module.css";

const Payments = (props) => {

  const [payments, setPayments] = useState();

  const authCtx = useContext(AuthContext);
  const userCtx = useContext(UserContext);
  const [isLoading, setIsLoading] = useState(true);
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
          id: key,
          idPayment: responseData[key].idPayment,
          amount: responseData[key].amount,
          date: responseData[key].date,
        });

        setPayments(loadedPayments);
        userCtx.loadPaymentHistory(payments);
      }
    };
    fetchUserData().catch((error) => {
      setIsLoading(false);
      setError(error.message);
    });
  }, []);

  if (loadedPayments.length === 0) {
    return <h2 className={classes.h2}>Found no payments.</h2>;
  }

  if (Error) {
    return (
      <section>
        <p>{Error}</p>
      </section>
    );
  }

  return (
    <div className={classes.global}>
      <div className={classes.general}>
        <h1>Payment history</h1>
      </div>
      <div className={classes.payments}>
        <ul className={classes.payments__list}>
          {loadedPayments.map((payments) => (
            <Payment
              key={payments.payment_id}
              payment_id={payments.payment_id}
              date={payments.date}
              amount={payments.amount}
            />
          ))}
        </ul>
      </div>
    </div>
  );
};

export default Payments;
