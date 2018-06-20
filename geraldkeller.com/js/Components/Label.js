'use strict';

var PropTypes = require('prop-types');
var React = require('react');

class Label extends React.Component {
  static propTypes = {
    labelText: PropTypes.string
  };

  render() {
    return (
      React.createElement('div', { className: 'col-xs-12' },
        React.createElement('h5', {}, this.props.labelText)
        )
    );
  }
}

module.exports = Label;