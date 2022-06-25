import React, { useState, useContext, useEffect, useRef } from "react";
import classes from "./Form.module.css";
import useInput from "../../../hooks/use-input-form";
import ErrorHandlerModal from "../../Helpers/ErrorHandler/ErrorHandlerModal";
import { useHistory } from "react-router-dom";

const Form = (props) => {
  const [enteredPackage, setEnteredPackage] = useState();
  const [enteredPlanIsValid, setEnteredPlanIsValid] = useState(false);
  const [enteredTypeOfHouse, setEnteredTypeOfHouse] = useState();
  const [enteredHouseTypeIsValid, setEnteredHouseTypeIsValid] = useState(false);
  const [showErrorModal, setShowErrorModal] = useState(false);
  const [showSuccessModal, setShowSuccessModal] = useState(false);
  const [isLoading, setIsLoading] = useState(false);

  const [isPostDataError, setIsPostDataError] = useState(false);
  const history = useHistory();

  let formIsValid = false;

  const {
    value: enteredEmail,
    isValid: enteredEmailIsValid,
    hasError: emailHasError,
    valueChangeHandler: emailChangeHandler,
    inputBlurHandler: emailBlurHandler,
    reset: resetEmailInput,
  } = useInput((value) => value.trim().includes("@"));

  const {
    value: enteredName,
    isValid: enteredNameIsValid,
    hasError: nameHasError,
    valueChangeHandler: nameChangeHandler,
    inputBlurHandler: nameBlurHandler,
    reset: resetNameInput,
  } = useInput((value) => value.trim() !== "");

  const {
    value: enteredPhone,
    isValid: enteredPhoneIsValid,
    hasError: phoneHasError,
    valueChangeHandler: phoneChangeHandler,
    inputBlurHandler: phoneBlurHandler,
    reset: resetPhoneInput,
  } = useInput(
    (value) => value.trim() !== "" && value.trim().match("[0-9]*") !== "false"
  );

  const {
    value: enteredAddress,
    isValid: enteredAddressIsValid,
    hasError: addressHasError,
    valueChangeHandler: addressChangeHandler,
    inputBlurHandler: addressBlurHandler,
    reset: resetAddressInput,
  } = useInput((value) => value.trim() !== "");

  if (
    enteredEmailIsValid &&
    enteredNameIsValid &&
    enteredPhoneIsValid &&
    enteredAddressIsValid &&
    enteredPlanIsValid &&
    enteredHouseTypeIsValid
  ) {
    formIsValid = true;
  }

  const errorHandler = () => {
    setShowErrorModal(false);
  };

  const successHandler = () => {
    setShowSuccessModal(false);
    window.location.reload();
  };

  const formSubmitHandler = (event) => {
    event.preventDefault();
    if (!formIsValid) {
      setShowErrorModal(true);
      return;
    }

    if (formIsValid) {
      let url = "https://localhost:7012/api/PotentialClient"
      fetch(url, {
        method: "POST",
        body: JSON.stringify({
          name: enteredName,
          phoneNumber: enteredPhone,
          address: enteredAddress,
          email: enteredEmail,
          idPackage: enteredPackage,
          idTypeOfHouse: enteredTypeOfHouse
        }),
        headers: {
          "Content-Type": "application/json",
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
          setShowSuccessModal(true);
        })
        .catch((err) => {
          alert(err.message);
        });
    }
    return;
  };

  
  const planChangeHandler = (event) => {
    setEnteredPackage(event.target.value);
    setEnteredPlanIsValid(true);
  };
  const houseTypeChangeHandler = (event) => {
    setEnteredTypeOfHouse(event.target.value);
    setEnteredHouseTypeIsValid(true);
  };
  const resetAllInputs = () => {
    resetNameInput();
    resetEmailInput();
    resetAddressInput();
    resetPhoneInput();
  };

  return (
    <div className={classes.user__form} href="#request" id="request">
      {showErrorModal && (
        <ErrorHandlerModal
          data="Please check whether you have entered all the information!"
          onConfirm={errorHandler}
        />
      )}
      {showSuccessModal && (
        <ErrorHandlerModal
          data="The data has been sent successfully!"
          onConfirm={successHandler}
        />
      )}
      {isPostDataError && (
        <ErrorHandlerModal
          data="The data has been sent successfully!"
          onConfirm={errorHandler}
        />
      )}
      <div className={classes.form__text}>
        <h1>Would you like to connect?</h1>
        <h3>
          If so, then enter information below and we will try to help you.
        </h3>
      </div>
      <form onSubmit={formSubmitHandler} className={classes.general__rorm}>
        <div className={classes.form__inputs}>
          <div className={classes.form__input__group}>
            <b>Email</b>
            <input
              type="text"
              autoComplete="email"
              name="email"
              id="email"
              placeholder="Your email"
              value={enteredEmail}
              onChange={emailChangeHandler}
              onBlur={emailBlurHandler}
            />
            {emailHasError && <p>Please provide correct email.</p>}
          </div>
          <div className={classes.form__input__group}>
            <b>Name</b>
            <input
              type="text"
              autoComplete="name"
              name="name"
              id="name"
              placeholder="Your name"
              value={enteredName}
              onChange={nameChangeHandler}
              onBlur={nameBlurHandler}
            />
            {nameHasError && <p>Please provide correct name.</p>}
          </div>
          <div className={classes.form__input__group}>
            <b>Phone</b>
            <input
              type="tel"
              autoComplete="tel"
              name="Phone"
              id="phone"
              placeholder="Your phone"
              pattern="[0-9]*"
              value={enteredPhone}
              onChange={phoneChangeHandler}
              onBlur={phoneBlurHandler}
            />
            {phoneHasError && <p>Please provide correct phone number.</p>}
          </div>
          {props.typeOfHouses &&
            props.typeOfHouses.map((typeOfHouse) => (
              <div
                className={classes.form__radio}
                key={typeOfHouse.idTypeOfHouse}
              >
                <input
                  id={typeOfHouse.idTypeOfHouse}
                  type="radio"
                  name="typeOfHouse"
                  value={typeOfHouse.idTypeOfHouse}
                  onChange={houseTypeChangeHandler}
                />
                <label htmlFor={typeOfHouse.typeOfHouse}>
                  {typeOfHouse.typeOfHouse}
                </label>
              </div>
            ))}
          <div className={classes.form__input__group}>
            <b>Address</b>
            <input
              type="text"
              autoComplete="Address"
              name="address"
              id="address"
              placeholder="Your address"
              value={enteredAddress}
              onChange={addressChangeHandler}
              onBlur={addressBlurHandler}
            />
            {addressHasError && <p>Please provide correct address.</p>}
          </div>
        </div>

        {props.tariffs &&
          props.tariffs.map((tariff) => (
            <div className={classes.form__radio} key={tariff.tariff_id}>
              <input
                id={tariff.nameOfPackage}
                type="radio"
                name="package"
                value={tariff.tariff_id}
                onChange={planChangeHandler}
              />
              <label htmlFor={tariff.nameOfPackage}>
                {tariff.nameOfPackage}
              </label>
            </div>
          ))}
        <div className={classes.form__submit}>
          <button onClick={formSubmitHandler}>Submit</button>
        </div>
        {isLoading && <p>Loading...</p>}
      </form>
    </div>
  );
};

export default Form;
