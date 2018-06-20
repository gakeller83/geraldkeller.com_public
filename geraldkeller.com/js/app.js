'use strict';
global.jQuery = require('jquery');
var React = require('react');
var ReactDom = require('react-dom');
var Routes = require('./Router.js');
var Bootstrap = require('bootstrap');

ReactDom.render(
  React.createElement(Routes, {}), document.getElementById('content')
  );

