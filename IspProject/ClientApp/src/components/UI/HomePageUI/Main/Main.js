import React, { Fragment, useState, useContext, useEffect } from "react";
import classes from "./Main.module.css";
import star from "../../../../gallery/star.svg";
import chat from "../../../../gallery/chat.svg";
import man from "../../../../gallery/man.svg";
import Form from "../Form/Form";
import Tariffs from "../Plans/Tariffs";
import axios from "axios";


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

const Main = () => {


  const [packages, setPackages] = useState();
  const [typeOfHouses, setTypeOfHouses] = useState();
  const [isLoading, setIsLoading] = useState(true);
  const [Error, setError] = useState();

  // useEffect(() => {
    const fetchTariffs = async () => {
      const response = await fetch("https://localhost:7012/api/Package");
      if (!response.ok) {
        throw new Error("Something went wrong!");
      }
      const responseData = await response.json();

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
  // }, []);

  // useEffect(() => {
    const fetchTypeOfHouses = async () => {
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
      setIsLoading(false);
    };
    fetchTypeOfHouses().catch((error) => {
      setIsLoading(false);
      setError(error.message);
    });
  // }, []);


  if (Error) {
    return (
      <section className={classes.error}>
        <p>Seems that server is down. Try reloading page or try again later.</p>
      </section>
    );
  }

  return (
    
    <Fragment>
      <section className={classes.starting} href="#main" id="main">
        <h1>We connect people around Poland</h1>
        <h2>
          Everything that you dreamed of can be brought to life exactly at the
          moment when you decide to win.
        </h2>
        <button>Connect now!</button>
      </section>
      <section className={classes.about} href="#about" id="about">
        <h1>Why choose us?</h1>
        <a>
          We work hard every day to make life of our clients better and happier
        </a>
        <div className={classes.about_icons}>
          <div className={classes.about_icons__row}>
            <div className={classes.about_icons__row__valign}>
              <div className={classes.about_icons__row__valign__img}>
                <img src={star} />
              </div>
            </div>
            <div className={classes.about_textwrapper}>
              <h2>High quality</h2>
              <a>
                We are a leading firm in providing quality and value to our
                customers. Each member of our team has at least 5 years of legal
                experience.
              </a>
            </div>
          </div>
          <div className={classes.about_icons__row}>
            <div className={classes.about_icons__row__valign}>
              <div className={classes.about_icons__row__valign__img}>
                <img src={chat} />
              </div>
            </div>
            <div className={classes.about_textwrapper}>
              <h2>Good Support</h2>
              <a>
                Our managers are always ready to answer your questions. You can
                call us at the weekends and at night. You can also visit our
                office for a personal consultation.
              </a>
            </div>
          </div>
          <div className={classes.about_icons__row}>
            <div className={classes.about_icons__row__valign}>
              <div className={classes.about_icons__row__valign__img}>
                <img src={man} />
              </div>
            </div>
            <div className={classes.about_textwrapper}>
              <h2>Individual Approach</h2>
              <a>
                Our company works according to the principle of individual
                approach to every client. This method allows us to achieve
                success in problems of all levels.
              </a>
            </div>
          </div>
        </div>
      </section>
      <section className={classes.plans} href="#plans" id="plans">

        {!isLoading && <Tariffs tariffs={packages} />}
        {isLoading && <p>Please wait...</p>}
      </section>

      {!isLoading && <Form tariffs={packages} typeOfHouses={typeOfHouses} />}
    </Fragment>
  );
};
export default Main;
