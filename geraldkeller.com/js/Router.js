'use strict';
var React = require('react');
var Router = require('react-router').Router;
var Route = require('react-router').Route;
var IndexRoute = require('react-router').IndexRoute;
var browserHistory = require('react-router').browserHistory;
var DefaultRoute = require('react-router').DefaultRoute;

var LoginController = require('./Controllers/LoginController');
var Home = require('./Components/Home');
var NavBar = require('./Components/NavBar');
var RegisterController = require('./Controllers/RegisterController');
var ResumeController = require('./Controllers/ResumeController');

class routes extends React.Component {
  static displayName = 'Routes';

  render() {
    return (
      React.createElement(Router, { history: browserHistory },          
        React.createElement(Route, {path: '/', component:  NavBar },
          React.createElement(IndexRoute, { component: Home }),
          React.createElement(Route, {path:'register', component: RegisterController}),
          React.createElement(Route, {path: 'home', component: Home}),
          React.createElement(Route, {path: 'login', component: LoginController }),
          React.createElement(Route, {path: 'resume', component: ResumeController}),
          React.createElement(Route, {path: '*', component: Home })
        )
      )
    );
  }
}

module.exports = routes;