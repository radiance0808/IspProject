import React from "react";
import { useState, useContext } from "react/cjs/react.development";
import UserContext from "../../../store/UserContext";

import classes from "./Topup.module.css";

const Topup = () => {
  const userCtx = useContext(UserContext);

  const [balance, setBalance] = useState(userCtx.balance);
  const [topup, setTopup] = useState();

  const paymentSubmitHandler = (event) => {
    event.preventDefault();
    setBalance(balance + topup);
    console.log(userCtx.balance);
  };

  return (
    <div className={classes.general}>
      <div className={classes.wrapper}>
        <h1>Top Up Balance</h1>
        <form>
          <div className={classes.form__input__group}>
            <b>Amount</b>
            <input
              type="number"
              name="Amount"
              id="amount"
              placeholder="Enter amount"
              pattern="[0-9]*"
              value={topup}
            />
            <button onClick={paymentSubmitHandler}>Pay</button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default Topup;
