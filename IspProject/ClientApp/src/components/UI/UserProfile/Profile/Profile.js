import React, { Fragment, useState, useContext, useEffect } from "react";
import Balance from "../Balance/Balance";
import Tariffs from "../Tariffs/Tariffs";
import Services from "../Services/Services";
import Controls from "../Controls/Controls";
import Notifications from "../Notifications/Notifications";
import Equipment from "../Equipment/Equipment";
import Payments from "../PaymentHistory/Payments";
import UserContext from "../../../store/UserContext";
import AuthContext from "../../../store/AuthContext";

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

  function isConnected(name){
    if(!name){
      return;
    }
    if(name === userCtx.plan){
      return true;
    }else{
      return false;
    }
  }

  const [payments, setPayments] = useState();
  const [tariffs, setTariffs] = useState();
  const [services, setServices] = useState();
  const [equipment, setEquipment] = useState();
  const [isLoading, setIsLoading] = useState(true);
  const [Error, setError] = useState();

  
  useEffect(() => {
    const fetchAdditionalServices = async () => {
      const response = await fetch(
        "https://localhost:7012/api/AdditionalService"
      );
      if (!response.ok) {
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
      setError(error.message);
    });
  }, []);
  useEffect(() => {
    const fetchEquipment = async () => {
      const response = await fetch("https://localhost:7012/api/Equipment");
      if (!response.ok) {
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
      setError(error.message);
    });
  }, []);
  

  useEffect(() => {
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
          tariff_id: responseData[key].tariff_id,
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
      setError(error.message);
    });
  }, []);

  if (Error) {
    return (
      <section>
        <p>{Error}</p>
      </section>
    );
  }

  return (
    <Fragment>
      {!isLoading && <Balance />}
      {isLoading && <p>Loading...</p>}
      {!isLoading && <Tariffs tariffs={tariffs} />}
      {!isLoading && <Services services={services} />}
      <Controls />
      <Notifications />
      <Equipment equipment={equipment} />
    </Fragment>
  );
};

export default Profile;
