'use strict';

var PropTypes = require('prop-types');
var React = require('react');

var Textbox = require('./Textbox');
var PasswordInput = require('./PasswordInput');

class Login extends React.Component {
  static displayName = 'Login';

  static propTypes = {
    userName: PropTypes.string,
    password: PropTypes.string,
    handleUserNameChange: PropTypes.func,
    handlePasswordChange: PropTypes.func
  };

  render() {
    return (
      React.createElement('div', { className: 'col-xs-10 col-xs-offset-1 col-sm-5 col-sm-offset-4 col-md-4 col-md-offset-4 col-lg-3 col-lg-offset-4' },
        React.createElement('div', { className: 'panel panel-default col-xs-12 div-gradient' },
          React.createElement('div', { className: 'panel-body col-xs-12' },
            React.createElement('h3', {}, 'Sign in'),
            React.createElement('div', {className: 'form'},
              React.createElement(Textbox, {placeholderText: '', labelText: 'Username', onChange: this.handleUsernameChange, value: this.props.userName}),
              React.createElement(PasswordInput, { placeholderText: '', labelText: 'Password', onChange: this.handlePasswordChange, value: this.props.password }),
              React.createElement('div', {className: 'spacer-10'}),
              React.createElement('button', { className: 'btn btn-default pull-right' }, 'Sign in'),
              React.createElement('div', { className: 'spacer-10' }),
              React.createElement('a', {href:'/register'}, 'Create new account')
            )
          )
        )
      )       
    );                      
  }

  handleUsernameChange = (input) => {
    this.props.handleUserNameChange(input.target.value);
  };

  handlePasswordChange = (input) => {
    this.props.handlePasswordChange(input.target.value);
};
}

module.exports = Login;