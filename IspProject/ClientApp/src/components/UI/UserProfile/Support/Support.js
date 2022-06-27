import React, { useState } from "react";
import useInput from "../../../hooks/use-input-form";
import ErrorHandlerModal from "../../Helpers/ErrorHandler/ErrorHandlerModal";

import classes from "./Support.module.css";

const Support = () => {
  const [formIsValid, setFormIsValid] = useState(false);
  const [showErrorModal, setShowErrorModal] = useState(false);
  const [showSuccessModal, setShowSuccessModal] = useState(false);
  const {
    value: enteredTopic,
    isValid: enteredTopicIsValid,
    hasError: topicHasError,
    valueChangeHandler: topicChangeHandler,
    inputBlurHandler: topicBlurHandler,
    reset: resetAddressInput,
  } = useInput((value) => value.trim() !== "");

  const {
    value: enteredMessage,
    isValid: enteredMessageIsValid,
    hasError: messageHasError,
    valueChangeHandler: messageChangeHandler,
    inputBlurHandler: messageBlurHandler,
    reset: resetMessageInput,
  } = useInput((value) => value.trim() !== "");

  const ticketSubmitHandler = (event) => {
    event.preventDefault();
    if(enteredTopicIsValid && enteredMessageIsValid){
        setFormIsValid(true);
    }

    if (!formIsValid) {
      setShowErrorModal(true);
    }

    if (formIsValid) {
      resetAllInputs();
      setShowSuccessModal(true);
    }

  };
  const errorHandler = () => {
    setShowErrorModal(false);
  };

  const successHandler = () => {
    setShowSuccessModal(false);
    window.location.reload();
  };

  const resetAllInputs = () =>{
    resetAddressInput();
    resetMessageInput();
  }
  return (
    <div className={classes.wrapper}>
        {showErrorModal && (
        <ErrorHandlerModal
          data="Please check whether you have entered all the information!"
          onConfirm={errorHandler}
        />
      )}
      {showSuccessModal && (
        <ErrorHandlerModal
          data="The data has been sent successfully!"
          onConfirm={successHandler}
        />
      )}
      <div className={classes.text}>
        <h1>Create support ticket</h1>
      </div>
      <form onSubmit={ticketSubmitHandler} className={classes.general__rorm}>
        <div className={classes.form__inputs}>
          <div className={classes.form__input__group}>
            <b>Topic</b>
            <input
              type="text"
              name="topic"
              id="email"
              placeholder="Enter subject that you have problem with"
              value={enteredTopic}
              onChange={topicChangeHandler}
              onBlur={topicBlurHandler}
            />
            {topicHasError && <p>Please enter a subject of the problem.</p>}
          </div>
          <div className={classes.form__input__group__message}>
            <b>Message</b>
            <textarea
              type="text"
              name="message"
              id="name"
              placeholder="Please try to describe everything in details"
              value={enteredMessage}
              onChange={messageChangeHandler}
              onBlur={messageBlurHandler}
            />
            {messageHasError && <p>Please enter a message with the problem.</p>}
          </div>
          <div className={classes.form__submit}>
            <button type="submit" onClick={ticketSubmitHandler}>Submit</button>
          </div>
        </div>
      </form>
    </div>
  );
};

export default Support;
