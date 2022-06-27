import React from "react";
import Tariff from "./Tariff";

import classes from "./Tariffs.module.css";

const Tariffs = (props) => {
  return (
    <div>
      <section className={classes.plans} href="#plans" id="plans">
        <h1>Would you like to change your plan?</h1>
      </section>
      <ul className={classes.product__cards}>
        {console.log(props.tariffs)}
      {props.tariffs && props.tariffs.map((tariffs) => (
            <Tariff
              key={tariffs.id}
              idPackage={tariffs.idPackage}
              name={tariffs.name}
              price={tariffs.price}
              speed={tariffs.speed}
              isConnected={tariffs.isConnected}
            />
          ))}
          </ul>
    </div>
  );
};

export default Tariffs;
