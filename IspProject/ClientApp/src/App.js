import React, { useContext } from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import { Fragment } from "react/cjs/react.development";
import "./App.css";
import AdminPage from "./components/pages/AdminPage";
import HomePage from "./components/pages/HomePage";
import LoginPage from "./components/pages/LoginPage";
import UserPage from "./components/pages/UserPage";
import AuthContext from "./components/store/AuthContext";
import { UserContextProvider } from "./components/store/UserContext";
import AdminPackages from "./components/UI/AdminProfile/AdminPackages/AdminPackages";
import CreateAccount from "./components/UI/AdminProfile/CreateAccount/CreateAccount";

import Layout from "./components/UI/Helpers/Layout/Layout";
import PageGuard from "./components/UI/HomePageUI/PageGuard/PageGuard";
import PaymentList from "./components/UI/UserProfile/PaymentHistory/PaymentList";
import Statistics from "./components/UI/UserProfile/Statistics/Statistics";
import Support from "./components/UI/UserProfile/Support/Support";
import Topup from "./components/UI/UserProfile/TopUp/Topup";

function App() {
  const authCtx = useContext(AuthContext);

  return (
    <Fragment>
      <Switch>
        {authCtx.isLogged && authCtx.UserIsAdmin && (
          <Route path="/admin" exact>
            <AdminPage />
          </Route>
        )}
        {authCtx.isLogged && authCtx.UserIsAdmin && (
          <Route path="/admin/packages" exact>
            <AdminPackages />
          </Route>
        )}
        {authCtx.isLogged && authCtx.UserIsAdmin && (
          <Route path="/admin/createAccount" exact>
            <CreateAccount />
          </Route>
        )}

        <Layout>
          <Route path="/" exact>
            <HomePage />
          </Route>
          {!authCtx.isLogged && (
            <Route path="/login">
              <LoginPage />
            </Route>
          )}
          <UserContextProvider>
            <Route path="/profile" exact>
              {!authCtx.isLogged && <Redirect to="/login" />}
              {authCtx.isLogged && authCtx.UserIsClient && <UserPage />}
              {authCtx.isLogged && !authCtx.UserIsClient && <PageGuard />}
            </Route>
            <Route path="/profile/statistics" exact>
              {!authCtx.isLogged && <Redirect to="/login" />}
              {authCtx.isLogged && authCtx.UserIsClient && <Statistics />}
              {authCtx.isLogged && !authCtx.UserIsClient && <PageGuard />}
            </Route>
            <Route path="/profile/topup" exact>
              {!authCtx.isLogged && <Redirect to="/login" />}
              {authCtx.isLogged && authCtx.UserIsClient && <Topup />}
              {authCtx.isLogged && !authCtx.UserIsClient && <PageGuard />}
            </Route>
            <Route path="/profile/support" exact>
              {!authCtx.isLogged && <Redirect to="/login" />}
              {authCtx.isLogged && authCtx.UserIsClient && <Support />}
              {authCtx.isLogged && !authCtx.UserIsClient && <PageGuard />}
            </Route>
            <Route path="/profile/payments" exact>
              {!authCtx.isLogged && <Redirect to="/login" />}
              {authCtx.isLogged && authCtx.UserIsClient && <PaymentList />}
              {authCtx.isLogged && !authCtx.UserIsClient && <PageGuard />}
            </Route>
          </UserContextProvider>
          <Route path="*">
            <Redirect to="/" />
          </Route>
        </Layout>
      </Switch>
    </Fragment>
  );
}

export default App;
