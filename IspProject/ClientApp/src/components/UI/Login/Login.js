import React, { useRef, useContext, useState} from "react";
import { useHistory } from "react-router-dom";
import classes from "./Login.module.css";
import AuthContext from "../../store/AuthContext";
import ErrorHandlerModal from "../Helpers/ErrorHandler/ErrorHandlerModal";

const Login = () => {
  const history = useHistory();
  const loginInputRef = useRef();
  const passwordInputRef = useRef();

  const authCtx = useContext(AuthContext);

  const [isLoading, setIsLoading] = useState(false);

  const [isError, setIsError] = useState(false);

  const [error, setError] = useState();

  const errorHandler = () => {
    setIsLoading(false);
    setIsError(false);
  };

  const submitLoginHandler = (event) => {
    event.preventDefault();
    const enteredLogin = loginInputRef.current.value;
    const enteredPassword = passwordInputRef.current.value;


    setIsLoading(true);

    //let url = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyBoLdVRZ5gvoLjhuhyTfvesjujjiNmQx7w";
    let url = "https://localhost:7012/api/Auth/Login";


    fetch(url, {
      method: "POST",
      body: JSON.stringify({
        login: enteredLogin,
        password: enteredPassword,
      }),
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((res) => {
        setIsLoading(false);
        if (res.ok) {
          return res.json();
        } else {
          return res.json().then((data) => {
            setError("The server is not responding now. Please try again later.");
            setIsError(true);
          });
        }
      })
      .then((data) => {
        const expirationTime = new Date(
          new Date().getTime() + +data.expiresIn * 1000
        );
        authCtx.login(data.token, expirationTime.toISOString(), data.role);
        if(data.role === "Admin"){
          history.replace("/admin");
        }
        else if(data.role === "Client"){
          history.replace("/profile")
        }
        else{

          history.replace("/");
        }

      })
      .catch((err) => {
        if(err.message === "Failed to fetch"){
          setError("The server is currently unavailable. Please try again later.")
        } 
            setIsError(true);
      });
  };


  return (
    <React.Fragment>
      {isError && (
        <ErrorHandlerModal
          data={error}
          onConfirm={errorHandler}
        />
      )}
      <div className={classes.login__container}>
        <div className={classes.login__form}>
          <h1>Authorization</h1>
          <form>
            <div className={classes.login__form__wrap}>
              <div className={classes.login__item}>
                <h4>Email</h4>
                <input
                  name="login"
                  placeholder="email@example.com"
                  type="text"
                  ref={loginInputRef}
                  required
                ></input>
              </div>
              <div className={classes.login__item}>
                <h4>Password</h4>
                <input
                  name="password"
                  placeholder="password"
                  type="password"
                  ref={passwordInputRef}
                  required
                ></input>
              </div>
              {isLoading && <p>Loading...</p>}
              <button onClick={submitLoginHandler}>Enter</button>
            </div>
          </form>
        </div>
      </div>
    </React.Fragment>
  );
};
export default Login;
