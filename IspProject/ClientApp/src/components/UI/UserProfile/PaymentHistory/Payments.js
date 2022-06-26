import React, { useState, useEffect, useContext } from "react";
import AuthContext from "../../../store/AuthContext";
import UserContext, { UserContextProvider } from "../../../store/UserContext";
import Payment from "./Payment";
import classes from "./Payments.module.css";

const Payments = (props) => {

  if (props.isLoading) {
    return (
      <section>
        <p>Loading...</p>
      </section>
    );
  }


  

  return (
    <div className={classes.global}>
      <div className={classes.general}>
        <h1>Payment History</h1>
      </div>
      <div className={classes.payments}>
        <ul className={classes.payments__list}>
          {props.payments.length === 0 && <h2 className={classes.h2}>Found no payments.</h2>}
          {props.payments && props.payments.map((payment) => (
              <Payment
                key={payment.id}
                idPayment={payment.idPayment}
                date={payment.date}
                amount={payment.amount}
              />
            ))}
        </ul>
      </div>
    </div>
  );
};

export default Payments;
