import React from "react";

import classes from "./Equipment.module.css";

const Equipment = (props) => {
  return (
    <div className={classes.container}>
      <div className={classes.wrapper}>
        <form className={classes.form}>
          <h4>Choose internet equipment</h4>
          <a>
            Please choose from the list the equipment that will be capable of
            your needs.
          </a>
          <br />
          <select>
          {props.equipment && props.equipment.map((equipment) => (
            <option key={equipment.id} value={equipment.routerName}>
              {equipment.routerName}
            </option>
          ))}
          </select>
          <button type="submit">Confirm</button>
        </form>
      </div>
    </div>
  );
};
export default Equipment;
