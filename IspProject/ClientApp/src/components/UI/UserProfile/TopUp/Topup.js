import React from "react";

import classes from "./Topup.module.css";

const Topup = () => {
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
            />
            <button>Pay</button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default Topup;
