import React from "react";

import classes from "./PageGuard.module.css";

const PageGuard = (props) => {

    return (
        <div className={classes.wrapper}>
            <h1>You are not allowed to enter this page.</h1>
        </div>

    )
}

export default PageGuard;