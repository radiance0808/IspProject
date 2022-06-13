import React, { Fragment, useState, useContext, useEffect } from "react";
import Balance from "../Balance/Balance";
import Tariffs from "../Tariffs/Tariffs";
import Services from "../Services/Services";
import Controls from "../Controls/Controls";
import Notifications from "../Notifications/Notifications";
import Equipment from "../Equipment/Equipment";
import Payments from "../PaymentHistory/Payments";
import ServicesContext from "../../../store/ServicesContext";
import UserContext from "../../../store/UserContext";


const Profile = () => {
  const servicesCtx = useContext(ServicesContext);
  const userCtx = useContext(UserContext);

  const [payments, setPayments] = useState(userCtx.paymentHistory);
  const [tariffs, setTariffs] = useState();
  const [services, setServices] = useState(servicesCtx.services);
  const [isLoading, setIsLoading] = useState(true);
  const [Error, setError] = useState();


  useEffect(()=>{
    const fetchTariffs = async () =>{
      const response = await fetch('https://localhost:7012/api/Package');
      if (!response.ok) {
        throw new Error('Something went wrong!');
      }
      const responseData = await response.json();

      const loadedTariffs = [];
      for (const key in responseData) {
        loadedTariffs.push({
          id: key,
          tariff_id: responseData[key].tariff_id,
          name: responseData[key].name,
          price: responseData[key].price,
        });
      }

      setTariffs(loadedTariffs);
      setIsLoading(false);
    }
    fetchTariffs().catch((error) => {
      setIsLoading(false);
      setError(Error.message);
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
      <Balance />
      {isLoading && <p>Loading...</p>}
      {!isLoading && <Tariffs tariffs={tariffs} />}
      <Services services={services} />
      <Controls />
      <Notifications />
      <Equipment />
      <Payments payments={payments} />
    </Fragment>
  );
};

export default Profile;
