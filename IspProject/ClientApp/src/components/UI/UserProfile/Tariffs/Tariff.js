import React, { useContext, useEffect, useState } from "react";

import classes from "./Tariff.module.css";

import UserContext from "../../../store/UserContext";


const Tariff = (props) => {

  const userCtx = useContext(UserContext);




  return (
    <div className={classes.card}>
      <h1>{props.name}</h1>
      <p className={classes.price}>{props.price} zl/month</p>
      <b>{props.speed} MBit/s</b>

      <p>
        <button
        disabled={props.isConnected}
          onClick={() => {
            //TODO send connection request to administrator with userID and service that user would like to connect
          }}
        >
          Change
        </button>
      </p>
    </div>
  );
};

export default Tariff;
