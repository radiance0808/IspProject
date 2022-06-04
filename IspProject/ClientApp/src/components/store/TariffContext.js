import React from "react";

const TariffContext = React.createContext({
    tariffs: [{
        tariff_id: "1",
        name: "Standard 100",
        price: 30.0,
      },
      {
        tariff_id: "2",
        name: "Pro 200",
        price: 60.0,
      },
      {
        tariff_id: "3",
        name: "Enterprise 500",
        price: 100.0,
      },],
});

export default TariffContext;
