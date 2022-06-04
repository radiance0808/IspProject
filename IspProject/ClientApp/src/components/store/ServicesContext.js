import React from "react";

const ServicesContext = React.createContext({
    services: [ {
        service_id: "1",
        additionalService: "Static IP",
        additionalServicePrice: 70
      },
      {
        service_id: "2",
        additionalService: "Parental Control",
        additionalServicePrice: 30
      },
      {
        service_id: "3",
        additionalService: "IPTV",
        additionalServicePrice: 20
      },],
      
});

export default ServicesContext;
