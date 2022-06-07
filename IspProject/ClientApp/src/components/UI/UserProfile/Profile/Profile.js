import React, { Fragment, useState, useContext } from "react";
import Balance from "../Balance/Balance";
import Tariffs from "../Tariffs/Tariffs";
import Services from "../Services/Services";
import Controls from "../Controls/Controls";
import Notifications from "../Notifications/Notifications";
import Equipment from "../Equipment/Equipment";
import Payments from "../PaymentHistory/Payments";
import TariffContext from "../../../store/TariffContext";
import ServicesContext from "../../../store/ServicesContext";
import UserContext from "../../../store/UserContext";

const DUMMY_PAYMENTS = [
  {
    payment_id: "123",
    date: new Date(2022, 5, 2),
    amount: 50.0,
  },
  { payment_id: "234", date: new Date(2022, 6, 3), amount: 30.0 },

  { payment_id: "423", date: new Date(2022, 6, 3), amount: 30.0 },
  { payment_id: "456", date: new Date(2022, 6, 3), amount: 30.0 },
  { payment_id: "345", date: new Date(2022, 7, 4), amount: 20.0 },
];

const Profile = () => {
  const tariffCtx = useContext(TariffContext);
  const servicesCtx = useContext(ServicesContext);
  const userCtx = useContext(UserContext);

  const [payments, setPayments] = useState(userCtx.paymentHistory);
  const [tariffs, setTariffs] = useState(tariffCtx.tariffs);
  const [services, setServices] = useState(servicesCtx.services);

  return (
    <Fragment>
      <Balance />
      <Tariffs tariffs={tariffs} />
      <Services services={services} />
      <Controls />
      <Notifications />
      <Equipment />
      <Payments payments={payments} />
    </Fragment>
  );
};

export default Profile;
