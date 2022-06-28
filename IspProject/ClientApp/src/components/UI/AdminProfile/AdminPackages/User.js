import React from "react";

import classes from "./User.module.css";

const User = (props) => {

  return (
    <li className={classes.list__item}>
      <div className={classes.user__item}>
        <div className={classes.user__item__number} key={props.id}>
          <h4>User #{props.idAccount}</h4>
        </div>
        <div className={classes.user__item__data} key={props.id}>
            <p>{props.firstName} {props.lastName}</p>
            <p>{props.packageName}</p>
        </div>

      </div>
    </li>
  );
};

export default User;
