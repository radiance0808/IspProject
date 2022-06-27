import React from "react";

import classes from "./Tariff.module.css";


const Tariff = (props) => {

  return (
    <div className={classes.card}>
      <h1>{props.name}</h1>
      <p className={classes.price}>{props.price} zl/month</p>
      <b>{props.speed} MBit/s</b>
      <p>
        <button
        disabled={props.isConnected}
          onClick={() => {
            console.log(props.idPackage)
          }}
        >
          Change
        </button>
      </p>
    </div>
  );
};

export default Tariff;
