import React, { Fragment } from "react";
import Header from "../Header/Header";

import classes from "./CreateAccount.module.css";

const CreateAccount = () => {
  return (
    <Fragment>
      <Header />
      <div className={classes.general}>
        <div className={classes.container}>
          <div className={classes.col}>
            <div className={classes.form}>
              <div className={classes.inputs}>
                <div className={classes.input__group}>
                    <div className={classes.description}>
                        First Name
                    </div>
                    <div className={classes.input__field}>
                        <input type="text" name="First name"></input>
                    </div>
                </div>
                <div className={classes.input__group}>
                    <div className={classes.description}>
                        First Name
                    </div>
                    <div className={classes.input__field}>
                        <input type="text" name="First name"></input>
                    </div>
                </div>
                <div className={classes.input__group}>
                    <div className={classes.description}>
                        First Name
                    </div>
                    <div className={classes.input__field}>
                        <input type="text" name="First name"></input>
                    </div>
                </div>
                <div className={classes.input__group}>
                    <div className={classes.description}>
                        First Name
                    </div>
                    <div className={classes.input__field}>
                        <input type="text" name="First name"></input>
                    </div>
                </div>
                <div className={classes.input__group}>
                    <div className={classes.description}>
                        First Name
                    </div>
                    <div className={classes.input__field}>
                        <input type="text" name="First name"></input>
                    </div>
                </div>
                <div className={classes.input__group}>
                    <div className={classes.description}>
                        First Name
                    </div>
                    <div className={classes.input__field}>
                        <input type="text" name="First name"></input>
                    </div>
                </div>
                
              </div>
            </div>
          </div>
        </div>
      </div>
    </Fragment>
  );
};

export default CreateAccount;
