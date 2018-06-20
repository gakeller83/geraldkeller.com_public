'use strict';

var PropTypes = require('prop-types');
var React = require('react');

var Textbox = require('./Textbox');
var PasswordInput = require('./PasswordInput');

class Register extends React.Component {
  static displayName = 'Register';

  static propTypes = {
    email: PropTypes.string,
    userName: PropTypes.string,
    password: PropTypes.string,
    passwordConfirm: PropTypes.string,
    handleEmailChange: PropTypes.func,
    handleUserNameChange: PropTypes.func,
    handlePasswordChange: PropTypes.func,
    handlePasswordConfirmChange: PropTypes.func,
    handleRegister: PropTypes.func,
    passwordAndConfirmMatch: PropTypes.bool,
    passwordValid: PropTypes.bool,
    passwordErrorText: PropTypes.string,
    passwordConfirmErrorText: PropTypes.string,
    createButtonDisabled: PropTypes.bool
  };

  render() {
    return (
      React.createElement('div', { className: 'col-xs-10 col-xs-offset-1 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 col-lg-4 col-lg-offset-4' },
        React.createElement('div', { className: 'panel panel-default col-xs-12 div-gradient' },
          React.createElement('div', { className: 'panel-body col-xs-12' },
            React.createElement('h3', { }, 'Create new account'),
            React.createElement('div', {className: 'form'},
              React.createElement(Textbox, { placeholderText: '', labelText: 'Email', onChange: this.handleEmailChange, value: this.props.email }),
              React.createElement(Textbox, { placeholderText: '', labelText: 'Username', onChange: this.handleUsernameChange, value: this.props.userName }),            
              React.createElement(PasswordInput, {
                placeholderText: 'minimum 6 characters', labelText: 'Password', onChange: this.handlePasswordChange, value: this.props.password,
                hasError: !this.props.passwordValid,errorText: this.props.passwordErrorText
              }),
              React.createElement(PasswordInput, {
                placeholderText: 'minimum 6 characters', labelText: 'Confirm password', onChange: this.handlePasswordConfirmChange,
                value: this.props.passwordConfirm, hasError: !this.props.passwordAndConfirmMatch, errorText: this.props.passwordConfirmErrorText
              }),
              React.createElement('div', { className: 'spacer-10' }),
              React.createElement('button', { className: 'btn btn-default pull-right', onClick: this.handleRegister, disabled:this.props.createButtonDisabled}, 'Create')
            )
          )
        )
      )
    );
  }

  handleEmailChange = (input) => {
    this.props.handleEmailChange(input.target.value);
  };

  handleUsernameChange = (input) => {
    this.props.handleUserNameChange(input.target.value);
  };

  handlePasswordChange = (input) => {
    this.props.handlePasswordChange(input.target.value);
  };

  handlePasswordConfirmChange = (input) => {
    this.props.handlePasswordConfirmChange(input.target.value);
  };

  handleRegister = () => {
    this.props.handleRegister();
  };
}

module.exports = Register;