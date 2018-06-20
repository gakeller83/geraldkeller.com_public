'use strict';

var PropTypes = require('prop-types');
var React = require('react');

class Resume extends React.Component {
  static displayName = 'Resume';

  static propTypes = {
    resume: PropTypes.node
  };

  render() {
    return (
      React.createElement('div', { className: 'col-xs-12 col-sm-12 col-md-10 col-md-offset-1 col-lg-6 col-lg-offset-3' },
        React.createElement('div', { className: 'panel panel-default' },
          React.createElement('div', { className: 'panel-body' },
              React.createElement('div', {}, this.props.resume)
          )
        )
      )
    );
  }
}

module.exports = Resume;