'use strict';
var React = require('react');

class Home extends React.Component {
  static displayName = 'Home';

  render() {
    return (
      React.createElement('div', {}, 'this is a home screen')
    );
  }
}

module.exports = Home;