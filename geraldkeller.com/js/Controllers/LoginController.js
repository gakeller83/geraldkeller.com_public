'use strict';

var React = require('react');

var Login = require('../Components/Login');

class LoginController extends React.Component {
  state = { userName: '', password: '' };

  render() {
    return (
      React.createElement(Login, {
        userName: this.state.userName, password: this.state.password,
        handleUserNameChange: this.handleUserNameChange, handlePasswordChange: this.handlePasswordChange
      })
    )
  }

  handleUserNameChange = (value) => {
    this.setState({ userName: value });
  };

  handlePasswordChange = (value) => {
    this.setState({ password: value });
  };
}

module.exports = LoginController;