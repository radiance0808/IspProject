import React, { useEffect, useState } from "react";
import Header from "../Header/Header";
import Tariffs from "../Packages/Tariffs";

import classes from "./AdminPackages.module.css";

const AdminPackages = () => {
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
      setIsLoading(false);
    };
    fetchTariffs().catch((error) => {
      setIsLoading(false);
      setError(error.message);
    });
  }, []);

  return (
    <div className={classes.container}>
        <Header/>
      {!isLoading && <Tariffs tariffs={packages} />}
    </div>
  );
};

export default AdminPackages;
