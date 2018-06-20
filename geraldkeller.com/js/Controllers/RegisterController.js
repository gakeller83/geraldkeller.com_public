'use strict';

var React = require('react');

var Register = require('../Components/Register');

var RegisterStore = require('../Stores/RegisterStore');

var Actions = require('../Actions/Actions');

class RegisterController extends React.Component {
  state = {
    email: '', emailValid: false,
    userName: '', usernameValid: false,
    password: '', passwordValid: true, passwordErrorText: 'Password must be at least 6 characters',
    passwordConfirm: '', passwordAndConfirmMatch: true, passwordConfirmErrorText: 'Both password fields must match',
    createButtonDisabled: true
  };

  render() {
    return (
      React.createElement(Register, {
        email: this.state.email,
        userName: this.state.userName,
        password: this.state.password,
        passwordConfirm: this.state.passwordConfirm,
        handleEmailChange: this.handleEmailChange,
        handleUserNameChange: this.handleUserNameChange,
        handlePasswordChange: this.handlePasswordChange,
        handlePasswordConfirmChange: this.handlePasswordConfirmChange,
        handleRegister: this.handleRegister,
        passwordAndConfirmMatch: this.state.passwordAndConfirmMatch,
        passwordConfirmErrorText: this.state.passwordConfirmErrorText,
        passwordErrorText: this.state.passwordErrorText,
        passwordValid: this.state.passwordValid,
        createButtonDisabled: this.state.createButtonDisabled
      })
    )
  }

  handleEmailChange = (value) => {
    this.setState({
      email: value,
      emailValid: (value.length > 0),
      createButtonDisabled: (!this.state.passwordAndConfirmMatch) || (!this.state.usernameValid) || (!this.state.usernameValid) || (value.length == 0)
    });
  };

  handleUserNameChange = (value) => {
    this.setState({
      userName: value,
      usernameValid: (value.length > 0),
      createButtonDisabled: (!this.state.passwordAndConfirmMatch) || (!this.state.passwordValid) || (!this.state.emailValid) || (value.length == 0)
    });
  };

  handlePasswordChange = (value) => {
    this.setState({
      password: value, passwordAndConfirmMatch: (this.state.passwordConfirm == value),
      passwordValid: (value.length >= 6),
      createButtonDisabled: (this.state.passwordConfirm != value) || (value.length < 6) || (!this.state.emailValid) || (!this.state.usernameValid)});
  };

  handlePasswordConfirmChange = (value) => {
    this.setState({
      passwordConfirm: value, passwordAndConfirmMatch: (this.state.password == value),
      createButtonDisabled: (this.state.password != value) || (this.state.password.length < 6) || (!this.state.emailValid) || (!this.state.usernameValid)
    });
  };

  handleRegister = () => {
    
    var user = {
      username: this.state.userName,
      password: this.state.password,
      email: this.state.email
    };
    Actions.registerUser(user);
  };
}

module.exports = RegisterController;
