import React from "react";

import classes from "./Payment.module.css";

const Payment = (props) => {

  const date = new Date(props.date);

  return (
    <li className={classes.list__item}>
      <div className={classes.payment__item}>
        <div className={classes.payment__item__number} key={props.id}>
          <h4>Payment #{props.idPayment}</h4>
        </div>
        <div className={classes.payment__item__data} key={props.id}>
            <b>{date.toLocaleDateString("en-US")}{" "}{date.toLocaleTimeString("en-US")}</b>
            <p>+{props.amount}zl</p>
        </div>

      </div>
    </li>
  );
};

export default Payment;
