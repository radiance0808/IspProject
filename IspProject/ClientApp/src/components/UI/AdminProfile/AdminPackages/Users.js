import React from "react";

import User from "./User";
import classes from "./Users.module.css";

const Users = (props) => {
    

  if (props.isLoading) {
    return (
      <section>
        <p>Loading...</p>
      </section>
    );
  }


  

  return (
    <div className={classes.global}>
      <div className={classes.general}>
        <h1>Users</h1>
      </div>
      <div className={classes.users}>
        <ul className={classes.users__list}>
          {props.users.length === 0 && <h2 className={classes.h2}>Found no users.</h2>}
          {props.users && props.users.map((user) => (
              <User
                key={user.idAccount}
                idAccount={user.idAccount}
                firstName={user.firstName}
                lastName={user.lastName}
                packageName={user.packageName}
              />
            ))}
        </ul>
      </div>
      {}
    </div>
  );
};

export default Users;
