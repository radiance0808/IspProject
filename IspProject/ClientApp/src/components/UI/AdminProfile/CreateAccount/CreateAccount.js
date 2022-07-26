import React, { Fragment, useState, useEffect } from "react";
import useInput from "../../../hooks/use-input-form";
import ErrorHandlerModal from "../../Helpers/ErrorHandler/ErrorHandlerModal";
import Header from "../Header/Header";

import classes from "./CreateAccount.module.css";

const CreateAccount = () => {
  const [enteredPackage, setEnteredPackage] = useState();
  const [enteredTypeOfHouse, setEnteredTypeOfHouse] = useState();
  const [enteredEquipment, setEnteredEquipment] = useState();
  const [enteredNotifications, setEnteredNotifications] = useState();

  const [enteredPackageIsValid, setEnteredPackageIsValid] = useState();
  const [enteredHouseTypeIsValid, setEnteredHouseTypeIsValid] = useState();
  const [enteredEquipmentIsValid, setEnteredEquipmentIsValid] = useState();
  const [enteredNotificaionsIsValid, setEnteredNotificationsIsValid] =
    useState();

  const [apartamentNumberIsVisible, setApartamentNumberIsVisible] = useState();

  const [formIsValid, setFormIsValid] = useState();
  const [showErrorModal, setShowErrorModal] = useState(false);
  const [showSuccessModal, setShowSuccessModal] = useState(false);

  const {
    value: enteredFirstName,
    isValid: enteredFirstNameIsValid,
    hasError: firstNameHasError,
    valueChangeHandler: firstNameChangeHandler,
    inputBlurHandler: firstNameBlurHandler,
    reset: resetFirstNameInput,
  } = useInput((value) => value.trim() !== "");

  const {
    value: enteredLastName,
    isValid: enteredLastNameIsValid,
    hasError: lastNameHasError,
    valueChangeHandler: lastNameChangeHandler,
    inputBlurHandler: lastNameBlurHandler,
    reset: resetLastNameInput,
  } = useInput((value) => value.trim() !== "");

  const {
    value: enteredLogin,
    isValid: enteredLoginIsValid,
    hasError: loginHasError,
    valueChangeHandler: loginChangeHandler,
    inputBlurHandler: loginBlurHandler,
    reset: resetLoginInput,
  } = useInput((value) => value.trim() !== "" && !value.length < 2);

  const {
    value: enteredPassword,
    isValid: enteredPasswordIsValid,
    hasError: passwordHasError,
    valueChangeHandler: passwordChangeHandler,
    inputBlurHandler: passwordBlurHandler,
    reset: resetPasswordInput,
  } = useInput((value) => value.trim() !== "" && value.trim().length > 8);

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
    value: enteredEmail,
    isValid: enteredEmailIsValid,
    hasError: emailHasError,
    valueChangeHandler: emailChangeHandler,
    inputBlurHandler: emailBlurHandler,
    reset: resetEmailInput,
  } = useInput((value) => value.trim().includes("@"));

  const {
    value: enteredPassportId,
    isValid: enteredPassportIdIsValid,
    hasError: passportIdHasError,
    valueChangeHandler: passportIdChangeHandler,
    inputBlurHandler: passportIdBlurHandler,
    reset: resetPassportIdInput,
  } = useInput((value) => value.trim() !== "");

  const {
    value: enteredCity,
    isValid: enteredCityIsValid,
    hasError: cityHasError,
    valueChangeHandler: cityChangeHandler,
    inputBlurHandler: cityBlurHandler,
    reset: resetCityInput,
  } = useInput((value) => value.trim() !== "" && !value.trim().length < 2);
  const {
    value: enteredStreet,
    isValid: enteredStreetIsValid,
    hasError: streetHasError,
    valueChangeHandler: streetChangeHandler,
    inputBlurHandler: streetBlurHandler,
    reset: resetStreetInput,
  } = useInput((value) => value.trim() !== "" && !value.trim().length < 2);

  const {
    value: enteredHouseNumber,
    isValid: enteredHouseNumberIsValid,
    hasError: houseNumberHasError,
    valueChangeHandler: houseNumberChangeHandler,
    inputBlurHandler: houseNumberBlurHandler,
    reset: resetHouseNumberInput,
  } = useInput((value) => value.trim() !== "" && !value.trim().length < 2);

  const {
    value: enteredApartamentNumber,
    isValid: enteredApartamentNumberIsValid,
    hasError: apartamentNumberHasError,
    valueChangeHandler: apartamentNumberChangeHandler,
    inputBlurHandler: apartamentNumberBlurHandler,
    reset: resetApartamentNumberInput,
  } = useInput((value) => value.trim() !== "" || value.trim() == 0);

  function removeFirstWord(str) {
    if (!str) {
      return;
    }
    const indexOfSpace = str.indexOf(" ");

    if (indexOfSpace === -1) {
      return "";
    }

    return str.substring(indexOfSpace + 1);
  }

  const [isLoading, setIsLoading] = useState(true);

  const [packages, setPackages] = useState();
  const [typeOfHouses, setTypeOfHouses] = useState();
  const [equipment, setEquipment] = useState();
  const [notifications, setNotifications] = useState();
  const [error, setError] = useState();
  useEffect(() => {
    const fetchTariffs = async () => {
      setIsLoading(true);
      const response = await fetch("https://localhost:7012/api/Package");
      if (!response.ok) {
        throw new Error("Something went wrong!");
      }
      const responseData = await response.json();
      if (!responseData) {
        return;
      }

      const loadedTariffs = [];
      for (const key in responseData) {
        loadedTariffs.push({
          id: key,
          tariff_id: responseData[key].idPackage,
          nameOfPackage: responseData[key].nameOfPackage,
          price: responseData[key].price,
          speed: removeFirstWord(responseData[key].nameOfPackage),
        });
      }
      setPackages(loadedTariffs);
    };
    fetchTariffs().catch((error) => {
      setIsLoading(false);
      setError(error.message);
    });
  }, []);
  useEffect(() => {
    const fetchTypeOfHouses = async () => {
      setIsLoading(true);
      const response = await fetch("https://localhost:7012/api/TypeOfHouse");
      if (!response.ok) {
        throw new Error("Something went wrong!");
      }
      const responseData = await response.json();
      const loadedTypesOfHouse = [];
      for (const key in responseData) {
        loadedTypesOfHouse.push({
          id: key,
          idTypeOfHouse: responseData[key].idTypeOfHouse,
          typeOfHouse: responseData[key].typeOfHouse,
        });
      }

      setTypeOfHouses(loadedTypesOfHouse);
    };
    fetchTypeOfHouses().catch((error) => {
      setIsLoading(false);
      setError(error.message);
      console.log(error.message);
    });
  }, []);

  useEffect(() => {
    const fetchEquipment = async () => {
      setIsLoading(true);
      const response = await fetch("https://localhost:7012/api/Equipment");
      if (!response.ok) {
        throw new Error("Something went wrong!");
      }
      const responseData = await response.json();
      const loadedEquipment = [];
      for (const key in responseData) {
        loadedEquipment.push({
          id: key,
          idEquipment: responseData[key].idEqupment,
          routerName: responseData[key].routerName,
        });
      }

      setEquipment(loadedEquipment);
      setIsLoading(false);
    };
    fetchEquipment().catch((error) => {
      setIsLoading(false);
      setError(error.message);
      console.log(error.message);
    });
  }, []);
  useEffect(() => {
    const fetchNotificationTypes = async () => {
      setIsLoading(true);
      const response = await fetch(
        "https://localhost:7012/api/account/getnotificationtypes"
      );
      if (!response.ok) {
        throw new Error("Something went wrong!");
      }
      const responseData = await response.json();
      const loadedNofitications = [];
      let i = 0;
      for (const key in responseData) {
        loadedNofitications.push({
          id: i,
          idNotification: i,
          notificationType: responseData[i],
        });
        i++;
      }
      setNotifications(loadedNofitications);
      setIsLoading(false);
    };
    fetchNotificationTypes().catch((error) => {
      setIsLoading(false);
      setError(error.message);
      console.log(error.message);
    });
  }, []);
  const planChangeHandler = (event) => {
    setEnteredPackage(event.target.value);
    setEnteredPackageIsValid(true);
  };
  const houseTypeChangeHandler = (event) => {
    if (event.target.value) {
      setEnteredTypeOfHouse(event.target.value);
      console.log(event.target.value);
      setEnteredHouseTypeIsValid(true);
    }

    if (event.target.value === "3") {
      setApartamentNumberIsVisible(false);
    } else {
      setApartamentNumberIsVisible(true);
    }
  };
  const equipmentChangeHandler = (event) => {
    setEnteredEquipment(event.target.value);
    setEnteredEquipmentIsValid(true);
  };
  const notificationsChangeHandler = (event) => {
    setEnteredNotifications(event.target.value);
    setEnteredNotificationsIsValid(true);
  };
  const formSubmitHandler = (event) => {
    event.preventDefault();

    if (
      enteredFirstNameIsValid &&
      enteredLastNameIsValid &&
      enteredLoginIsValid &&
      enteredPasswordIsValid &&
      enteredPhoneIsValid &&
      enteredEmailIsValid &&
      enteredPassportIdIsValid &&
      enteredPackageIsValid &&
      enteredCityIsValid &&
      enteredStreetIsValid &&
      enteredHouseNumberIsValid &&
      enteredApartamentNumberIsValid &&
      enteredHouseTypeIsValid &&
      enteredEquipmentIsValid &&
      enteredNotificaionsIsValid
    ) {
      setFormIsValid(true);
      console.log(enteredFirstName);
      console.log(enteredLastName);
      console.log(enteredLogin);
      console.log(enteredPassword);
      console.log(enteredPhone);
      console.log(enteredEmail);
      console.log(enteredPassportId);
      console.log(enteredPackage);
      console.log(enteredCity);
      console.log(enteredStreet);
      console.log(enteredHouseNumber);
      console.log(enteredApartamentNumber);
      console.log(enteredTypeOfHouse);
      console.log(enteredEquipment);
      console.log(enteredNotifications);

      if (formIsValid) {
        let url = "https://localhost:7012/api/account";
        fetch(url, {
          method: "POST",
          body: JSON.stringify({
            firstName: enteredFirstName,
            lastName: enteredLastName,
            login: enteredLogin,
            password: enteredPassword,
            phoneNumber: enteredPhone,
            emailAddress: enteredEmail,
            passportId: enteredPassportId,
            idPackage: enteredPackage,
            city: enteredCity,
            street: enteredStreet,
            houseNumber: enteredHouseNumber,
            apartmentNumber: enteredApartamentNumber,
            idTypeOfHouse: enteredTypeOfHouse,
            idEquipment: enteredEquipment,
            NotificationType: enteredNotifications,
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
                console.log(errorMessage);
                throw new Error(errorMessage);
               
              });
            }
          })
          .then((data) => {
            setShowSuccessModal(true);
          })
          .catch((err) => {
            console.log(err.message);
            setShowErrorModal(true);
          });
      }
    } else {
      setFormIsValid(false);
      setShowErrorModal(true);
    }
  };

  const errorHandler = () => {
    setShowErrorModal(false);
  };

  const successHandler = () => {
    setShowSuccessModal(false);
    window.location.reload();
  };

  return (
    <Fragment>
      {showErrorModal && (
        <ErrorHandlerModal
          data="Please check whether you have entered all the information!"
          onConfirm={errorHandler}
        />
      )}
      {showSuccessModal && (
        <ErrorHandlerModal
          data="The user has been created!"
          onConfirm={successHandler}
        />
      )}
      <Header />
      <form onSubmit={formSubmitHandler} className={classes.general__form}>
        <div className={classes.form__inputs}>
          <div className={classes.form__input__group}>
            <b>First Name</b>
            <input
              type="text"
              autoComplete="given-name"
              name="firstName"
              id="firstName"
              placeholder="First name of client"
              value={enteredFirstName}
              onChange={firstNameChangeHandler}
              onBlur={firstNameBlurHandler}
            />
            {firstNameHasError && (
              <p>Please provide correct first name of the client.</p>
            )}
          </div>
          <div className={classes.form__input__group}>
            <b>Last Name</b>
            <input
              type="text"
              autoComplete="family-name"
              name="lastName"
              id="lastName"
              placeholder="Last name of client"
              value={enteredLastName}
              onChange={lastNameChangeHandler}
              onBlur={lastNameBlurHandler}
            />
            {lastNameHasError && (
              <p>Please provide correct last name of the client.</p>
            )}
          </div>
          <div className={classes.form__input__group}>
            <b>Login</b>
            <input
              type="login"
              autoComplete="username"
              name="Login"
              id="login"
              placeholder="Login of client"
              value={enteredLogin}
              onChange={loginChangeHandler}
              onBlur={loginBlurHandler}
            />
            {loginHasError && <p>Please provide correct phone number.</p>}
          </div>
          <div className={classes.form__input__group}>
            <b>Password</b>
            <input
              type="password"
              autoComplete="new-password"
              name="Password"
              id="password"
              placeholder="Password of client"
              value={enteredPassword}
              onChange={passwordChangeHandler}
              onBlur={passwordBlurHandler}
            />
            {passwordHasError && <p>Please provide correct password.</p>}
          </div>
          <div className={classes.form__input__group}>
            <b>Phone</b>
            <input
              type="tel"
              autoComplete="tel"
              name="Phone"
              id="phone"
              placeholder="Phone of client"
              pattern="[0-9]*"
              value={enteredPhone}
              onChange={phoneChangeHandler}
              onBlur={phoneBlurHandler}
            />
            {phoneHasError && <p>Please provide correct phone number.</p>}
          </div>
          <div className={classes.form__input__group}>
            <b>E-Mail</b>
            <input
              type="email"
              autoComplete="email"
              name="Email"
              id="email"
              placeholder="Email of client"
              value={enteredEmail}
              onChange={emailChangeHandler}
              onBlur={emailBlurHandler}
            />
            {phoneHasError && <p>Please provide correct email.</p>}
          </div>
          <div className={classes.form__input__group}>
            <b>Passport ID</b>
            <input
              type="text"
              name="PassportId"
              id="passportid"
              placeholder="Passport ID of client"
              value={enteredPassportId}
              onChange={passportIdChangeHandler}
              onBlur={passportIdBlurHandler}
            />
            {phoneHasError && <p>Please provide correct Passport ID.</p>}
          </div>
          {packages &&
            packages.map((tariff) => (
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
          <div className={classes.form__input__group}>
            <b>City</b>
            <input
              type="text"
              name="City"
              id="city"
              placeholder="City of client"
              value={enteredCity}
              onChange={cityChangeHandler}
              onBlur={cityBlurHandler}
            />
            {phoneHasError && <p>Please provide correct city.</p>}
          </div>
          <div className={classes.form__input__group}>
            <b>Street</b>
            <input
              type="text"
              name="Street"
              id="street"
              placeholder="Street of client"
              value={enteredStreet}
              onChange={streetChangeHandler}
              onBlur={streetBlurHandler}
            />
            {phoneHasError && <p>Please provide correct street.</p>}
          </div>
          <div className={classes.form__input__group}>
            <b>House number</b>
            <input
              type="text"
              name="House number"
              id="houseNumber"
              placeholder="House number of client"
              value={enteredHouseNumber}
              onChange={houseNumberChangeHandler}
              onBlur={houseNumberBlurHandler}
            />
            {phoneHasError && <p>Please provide correct house number.</p>}
          </div>
          {apartamentNumberIsVisible && (
            <div className={classes.form__input__group}>
              <b>Apartament Number</b>
              <input
                type="text"
                name="Apartament number"
                id="apartamentNumber"
                placeholder="Apartament number of client"
                value={enteredApartamentNumber}
                onChange={apartamentNumberChangeHandler}
                onBlur={apartamentNumberBlurHandler}
              />
              {phoneHasError && <p>Please provide correct apartamentNumber.</p>}
            </div>
          )}
          <b>Type of house</b>
          {typeOfHouses &&
            typeOfHouses.map((typeOfHouse) => (
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
          <b>Equipment</b>
          {equipment &&
            equipment.map((equipment) => (
              <div className={classes.form__radio} key={equipment.idEquipment}>
                <input
                  id={equipment.idEquipment}
                  type="radio"
                  name="Equipment"
                  value={equipment.idEquipment}
                  onChange={equipmentChangeHandler}
                />
                <label htmlFor={equipment.routerName}>
                  {equipment.routerName}
                </label>
              </div>
            ))}
          <b>Type of notifications</b>
          {notifications &&
            notifications.map((notifications) => (
              <div className={classes.form__radio} key={notifications.idNotification}>
                <input
                  id={notifications.idNotification}
                  type="radio"
                  name="Notifications"
                  value={notifications.idNotification}
                  onChange={notificationsChangeHandler}
                />
                <label htmlFor={notifications.notificationType}>{notifications.notificationType}</label>
              </div>
            ))}
        </div>
        <div className={classes.form__submit}>
          <button onClick={formSubmitHandler}>Submit</button>
        </div>
        {isLoading && <p>Loading...</p>}
      </form>
    </Fragment>
  );
};

export default CreateAccount;
