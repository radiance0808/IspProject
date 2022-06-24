import React, { Fragment } from "react";

import classes from "./Admin.module.css";

import { useHistory } from "react-router-dom";
import { useRef, useState, useContext } from "react";
import ErrorHandlerModal from "../Helpers/ErrorHandler/ErrorHandlerModal";
import Header from "../AdminProfile/Header/Header";
import PreWrittenScript from "../AdminProfile/PrewrittenScript/PreWrittenScript";
const Admin = () => {


  return (
    <Fragment>
      <Header/>
      <PreWrittenScript/>
    </Fragment>
  )
}

export default Admin;