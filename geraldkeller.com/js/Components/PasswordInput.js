'use strict';

var PropTypes = require('prop-types');
var React = require('react');

class PasswordInput extends React.Component {
  static propTypes = {
    labelText: PropTypes.string,
    placeholderText: PropTypes.string,
    onChange: PropTypes.func,
    value: PropTypes.string,
    hasError: PropTypes.bool,
    errorText: PropTypes.string
  };

  render() {
    return (
      React.createElement('div', { className: 'form-group' + (this.props.hasError ? ' has-error' : '')},
        React.createElement('label', { className: 'control-label' }, this.props.labelText),
        React.createElement('div', { className: 'col-sm-12 col-xs-12 col-md-12 col-lg-12 input-group' },
          React.createElement('input', { type: 'password', id: 'textinput', className: 'form-control', placeholder: this.props.placeholderText, onChange: this.props.onChange, value: this.props.value }), this.renderErrorText()
        )
        ))
  }

  renderErrorText = () => {
    return this.props.hasError ? (React.createElement('div', {},
        React.createElement('h6', {style: {color: '#a94442'}}, this.props.errorText))) : null
  };
}

module.exports = PasswordInput;