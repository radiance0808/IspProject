import React, { useContext } from "react";
import classes from "./Balance.module.css";

import UserContext from "../../../store/UserContext";

const Balance = (props) => {
  const userCtx = useContext(UserContext);

  return (
    <div className={classes.container}>
      <div className={classes.container__value}>{userCtx.balance} zl</div>
      <div className={classes.container__label}>Your balance</div>
    </div>
  );
};

export default Balance;
