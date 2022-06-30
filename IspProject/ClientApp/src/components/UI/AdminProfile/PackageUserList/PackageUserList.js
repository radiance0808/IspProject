import React, { useContext, useEffect, useState } from "react";
import AuthContext from "../../../store/AuthContext";
import Users from "../AdminPackages/Users";

const PackageUserList = (props) => {
  const [isShown, setIsShown] = useState();
  const [isLoading, setIsLoading] = useState();

  const [users, setUsers] = useState([]);

  const authCtx = useContext(AuthContext);
  const [Error, setError] = useState();
  const loadedUsers = [];

  useEffect(() => {
    const fetchUserData = async () => {
      setIsLoading(true);
      let url =
        "https://localhost:7012/api/account/searchaccountsbypackage?idPackage=" +
        props.idPackage;
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

      for (const key in responseData) {
        loadedUsers.push({
          id: responseData[key].idAccount,
          idAccount: responseData[key].idAccount,
          firstName: responseData[key].firstName,
          lastName: responseData[key].lastName,
          packageName: responseData[key].packageName,
        });
      }
      setUsers(loadedUsers);
      setIsLoading(false);
    };
    fetchUserData().catch((error) => {
      setError(error.message);
    });
  }, []);

  return <Users users={users} isLoading={isLoading} />;
};

export default PackageUserList;
