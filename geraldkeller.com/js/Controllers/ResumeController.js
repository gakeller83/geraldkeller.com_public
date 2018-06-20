'use strict';

var React = require('react');
var Resume = require('../Components/Resume');
var HttpController = require('./HttpController');
var ResumeStore = require('../Stores/ResumeStore');

class ResumeController extends React.Component {
  state = {resume: ''};

  componentDidMount() {
    ResumeStore.addChangeListener(this.onChange);
    ResumeStore.getResume();
  }

  render() {
    return React.createElement(Resume, { resume: this.state.resume });
  }

  onChange = () => {
    this.setState({resume : ResumeStore.getResume()});
  };
}

module.exports = ResumeController;