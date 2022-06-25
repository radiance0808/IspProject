import React from "react";
import { useState, useContext } from "react/cjs/react.development";
import UserContext from "../../../store/UserContext";
import AuthContext from "../../../store/AuthContext";

import classes from "./Topup.module.css";
import { useHistory } from "react-router-dom";

const Topup = () => {
  const userCtx = useContext(UserContext);
  const authCtx = useContext(AuthContext);
  const history = useHistory();


  const [topup, setTopup] = useState(0);
  const [isLoading, setIsLoading] = useState(false);


  const paymentSubmitHandler = (event) => {
    event.preventDefault();
    console.log(userCtx.balance);
    setIsLoading(true);

    let url = 'https://localhost:7012/api/payment'
    fetch(url, {
      method: "POST",
      body: JSON.stringify({
        amount: topup,
      }),
      headers: {
        "Content-Type": "application/json",
        Authorization: "Bearer " + authCtx.token,
      },
    })
      .then((res) => {
        setIsLoading(false);
        if (res.ok) {
          return res.json();
        } else {
          return res.json().then((data) => {
            let errorMessage = "Authentication failed!";
            // if (data && data.error && data.error.message) {
            //   errorMessage = data.error.message;
            // }

            throw new Error(errorMessage);
          });
        }
      })
      .then((data) => {
        history.replace("/profile");
      })
      .catch((err) => {
        alert(err.message);
      });
  };

  const changeValueHandler = (event) => {
    event.preventDefault();
    setTopup(event.target.value);
  }

  return (
    <div className={classes.general}>
      <div className={classes.wrapper}>
        <h1>Top Up Balance</h1>
        <form>
          <div className={classes.form__input__group}>
            <b>Amount</b>
            <input
              type="number"
              name="Amount"
              id="amount"
              placeholder="Enter amount"
              pattern="[0-9]*"
              value={topup}
              onChange={changeValueHandler}
            />
            <button onClick={paymentSubmitHandler}>Pay</button>
              {isLoading && <p>Loading...</p>}
          </div>
        </form>
      </div>
    </div>
  );
};

export default Topup;
