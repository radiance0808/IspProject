import React from "react";

import classes from "./Tariff.module.css";

function removeFirstWord(str) {
  const indexOfSpace = str.indexOf(" ");

  if (indexOfSpace === -1) {
    return "";
  }

  return str.substring(indexOfSpace + 1);
}

const Tariff = (props) => {
  return (
    <div className={classes.card}>
      <h1>{props.nameOfPackage}</h1>
      <p className={classes.price}>{props.price} zl/month</p>
      <b className={classes.speed}>{props.nameOfPackage} MBit/s</b>

      <p>
        <button
          onClick={() => {
            //TODO send connection request to administrator with userID and service that user would like to connect
          }}
        >
          Connect
        </button>
      </p>
    </div>
  );
};

export default Tariff;
