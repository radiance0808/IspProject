import React from "react";

import classes from "./PreWrittenScript.module.css";

const PreWrittenScript = () => {
  return (
    <React.Fragment>
      <div className={classes.container}>
        <h1>Pre-written script</h1>
        <div className={classes.wrapper}>
          <div className={classes.container__columns}>
            <div className={classes.inputs}>
              <div className={classes.input}>ClientID</div>
              <div className={classes.input__title}>
                Enter ClientID in order to run the script for the client
              </div>
              <div className={classes.input__form}>
                <input
                  type="text"
                  name="ClientID"
                  placeholder="2348765"
                ></input>
              </div>
              
            </div>
            <div className={classes.inputs}>
              <div className={classes.input}>ClientID</div>
              <div className={classes.input__title}>
                Enter ClientID in order to run the script for the client
              </div>
              <div className={classes.input__form}>
                <select
                  type="text"
                  name="ClientID"
                  placeholder="2348765"
                >
                    <option>Disable internet connection</option>
                </select>
              </div>
              
            </div>
            <div className={classes.submit}>
                <button>Submit</button>
            </div>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default PreWrittenScript;
