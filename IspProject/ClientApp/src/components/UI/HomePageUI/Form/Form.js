import React, { useState, useContext } from "react";
import classes from "./Form.module.css";
import useInput from "../../../hooks/use-input-form";
import ErrorHandlerModal from "../../Helpers/ErrorHandler/ErrorHandlerModal";

const Form = (props) => {
  const [enteredPlan, setEnteredPlan] = useState(null);
  const [enteredPlanIsValid, setEnteredPlanIsValid] = useState(false);
  const [enteredHouseType, setEnteredHouseType] = useState(null);
  const [enteredHouseTypeIsValid, setEnteredHouseTypeIsValid] = useState(false);
  const [showErrorModal, setShowErrorModal] = useState(false);
  const [showSuccessModal, setShowSuccessModal] = useState(false);
  const [housesLoaded, setHousesLoaded] = useState(true);
  const [packagesLoaded, setPackagesLoaded] = useState(true);
  const [isPostDataError, setIsPostDataError] = useState(false);

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
  if(!props.tariffs){
    setPackagesLoaded(false);
  }
  if(!props.typeOfHouses){
    setHousesLoaded(false);
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
    }

    if (formIsValid) {
      const axios = require('axios');
      axios.post('https://localhost:7012/api/adress', {
        address: {enteredAddress},
        idTypeOfHouse: {enteredHouseType}
      })
      .then(function (response) {
        
      })
      .catch(function (error) {
        setIsPostDataError(true);
        return;
      });
      axios.post('https://localhost:7012/api/adress', {
        address: {enteredAddress},
        idTypeOfHouse: {enteredHouseType}
      })
      .then(function (response) {
        
      })
      .catch(function (error) {
        setIsPostDataError(true);
        return;
      });
      resetAllInputs();
      setShowSuccessModal(true);
    }

    return;
  };

  const planChangeHandler = (event) => {
    setEnteredPlan(event.target.value);
    setEnteredPlanIsValid(true);
  };
  const houseTypeChangeHandler = (event) => {
    setEnteredHouseType(event.target.value);
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
        onConfirm={successHandler}
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
            <div className={classes.form__radio} key={typeOfHouse.idTypeOfHouse}>
              <input
                id={typeOfHouse.typeOfHouse}
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
          {!housesLoaded && <p>Seems there is a problem from our side. Please try again</p>}
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
                value={tariff.nameOfPackage}
                onChange={planChangeHandler}
              />
              <label htmlFor={tariff.nameOfPackage} >
                {tariff.nameOfPackage}
              </label>
            </div>
          ))}
          {!packagesLoaded && <p>Seems there is a problem from our side. Please try again</p>}

        <div className={classes.form__submit}>
          <button onClick={formSubmitHandler}>Submit</button>
        </div>
      </form>
    </div>
  );
};

export default Form;
