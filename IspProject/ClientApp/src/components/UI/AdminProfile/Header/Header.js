import React from "react";

import classes from "./Header.module.css";

const Header = () => {
    return(
        <div className={classes.header__content}>
            <div className={classes.header__adminpanel__container}>
                <div className={classes.header__adminpanel__content}>
                    <a>Admin Panel</a>
                </div>
            </div>
        </div>
    )
}

export default Header;