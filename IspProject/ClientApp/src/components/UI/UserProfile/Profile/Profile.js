import React, { useState, useContext, useEffect } from "react";
import Balance from "../Balance/Balance";
import Tariffs from "../Tariffs/Tariffs";
import Services from "../Services/Services";
import Controls from "../Controls/Controls";
import Notifications from "../Notifications/Notifications";
import Equipment from "../Equipment/Equipment";
import UserContext from "../../../store/UserContext";
import AuthContext from "../../../store/AuthContext";

import classes from './Profile.module.css';

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

const Profile = () => {
  const userCtx = useContext(UserContext);
  const authCtx = useContext(AuthContext);

  function isConnected(name) {
    if (!name) {
      return;
    }
    if (name === userCtx.plan) {
      return true;
    } else {
      return false;
    }
  }

  const [tariffs, setTariffs] = useState();
  const [services, setServices] = useState();
  const [equipment, setEquipment] = useState();
  const [isLoading, setIsLoading] = useState(true);
  const [Error, setError] = useState();
  const [isError, setIsError] = useState(false);

  useEffect(() => {
    const fetchAdditionalServices = async () => {
      const response = await fetch(
        "https://localhost:7012/api/AdditionalService"
      );
      if (!response.ok) {
        setIsError(true);
        throw new Error("Something went wrong!");
      }
      const responseData = await response.json();

      const loadedAdditionalServices = [];
      for (const key in responseData) {
        loadedAdditionalServices.push({
          id: key,
          idAdditionalService: responseData[key].idAdditionalService,
          additionalService: responseData[key].additionalService,
          price: responseData[key].additionalPrice,
        });
      }

      setServices(loadedAdditionalServices);
    };
    fetchAdditionalServices().catch((error) => {
      setIsLoading(false);
      setIsError(true);
      setError(error.message);
    });
  }, []);
  useEffect(() => {
    const fetchEquipment = async () => {
      const response = await fetch("https://localhost:7012/api/Equipment");
      if (!response.ok) {
        setIsError(true);
        throw new Error("Something went wrong!");
      }
      const responseData = await response.json();

      const loadedEquipment = [];
      for (const key in responseData) {
        loadedEquipment.push({
          id: key,
          idEquipment: responseData[key].idEquipment,
          routerName: responseData[key].routerName,
          description: responseData[key].description,
        });
      }
      setEquipment(loadedEquipment);
    };
    fetchEquipment().catch((error) => {
      setIsLoading(false);
      setIsError(true);
      setError(error.message);
    });
  }, []);
  useEffect(() => {
    const fetchUserData = async () => {
      let url = "https://localhost:7012/api/account/getinfo";
      const response = await fetch(url, {
        method: "GET",
        headers: new Headers({
          Authorization: "Bearer " + authCtx.token,
        }),
      });
      if (!response.ok) {
        setIsError(true);
        throw new Error("Something went wrong!");
      }
      const responseData = await response.json();
      userCtx.loadData(
        responseData.balance,
        responseData.notificationType,
        responseData.equipment,
        responseData.package,
        responseData.isActive
      );
    };
    fetchUserData().catch((error) => {
      setIsLoading(false);
      setIsError(true);
      setError(error.message);
    });
  }, []);

  useEffect(() => {
    const fetchTariffs = async () => {
      const response = await fetch("https://localhost:7012/api/Package");
      if (!response.ok) {
        setIsError(true);
        throw new Error("Something went wrong!");
      }
      const responseData = await response.json();

      const loadedTariffs = [];
      for (const key in responseData) {
        loadedTariffs.push({
          id: key,
          idPackage: responseData[key].idPackage,
          name: responseData[key].nameOfPackage,
          price: responseData[key].price,
          speed: removeFirstWord(responseData[key].nameOfPackage),
          isConnected: isConnected(responseData[key].nameOfPackage),
        });
      }

      setTariffs(loadedTariffs);
      setIsLoading(false);
    };
    fetchTariffs().catch((error) => {
      setIsLoading(false);
      setIsError(true);
      setError(error.message);
    });
  }, []);

  if (Error && isError) {
    return (
      <section>
        <b>
          The server is unavailable now. Please try reloading the page or try
          again later.
        </b>
      </section>
    );
  }

  return (
    <div className={classes.loading}>
      {isLoading && <p>Loading...</p>}
      {!isLoading && <Balance />}
      {!isLoading && <Tariffs tariffs={tariffs} />}
      {!isLoading && <Services services={services} />}
      {!isLoading && <Controls />}
      {!isLoading && <Notifications />}
      {!isLoading && <Equipment equipment={equipment} />}
    </div>
  );
};

export default Profile;
