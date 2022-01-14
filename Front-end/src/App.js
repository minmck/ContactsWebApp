import React from "react";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Redirect
} from "react-router-dom";

import Home from "./components/Home/HomeView";
import Login from "./components/Login/LoginView";
import Registration from "./components/Registration/RegistrationView";

function App() {
  return (
    <Router>
      <Switch>
        <Route exact path="/"><Redirect to="/login" /></Route>
        <Route exact path="/login"><Login /></Route>
        <Route exact path="/register"><Registration /></Route>
        <Route exact path="/home"><Home /></Route>
      </Switch>
    </Router>
  );
}

export default App;
