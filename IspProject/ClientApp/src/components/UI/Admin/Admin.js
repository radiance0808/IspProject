import React, { Fragment } from "react";

import Header from "../AdminProfile/Header/Header";
import PreWrittenScript from "../AdminProfile/PrewrittenScript/PreWrittenScript";
import Controls from "../AdminProfile/Controls/Controls";

import classes from "./Admin.module.css";
const Admin = () => {


  return (
    <div className={classes.container}>
      <Header/>
      <Controls/>
      <PreWrittenScript/>
    </div>
  )
}

export default Admin;