'use strict';

var EventEmitter = require('events').EventEmitter;
var HttpController = require('../Controllers/HttpController');
var ActionConstants = require('../Actions/ActionConstants');
var Actions = require('../Actions/Actions');
var AppDispatcher = require('../AppDispatcher');
var _ = require('underscore');
var HtmlToReactTransform = require('../Utils/HtmlToReactTransform');

var resume ='';

function getResume() {
  HttpController.get('/api/Resume/get', resumeReceived)
}

function resumeReceived(data) {
  resume = HtmlToReactTransform.transform(data.value);
  ResumeStore.emitChange()
}

var ResumeStore = _.extend({}, EventEmitter.prototype, {

  emitChange: function () {
    this.emit('change');
  },

  addChangeListener: function (callback) {
    this.on('change', callback);
  },

  removeChangeListener: function (callback) {
    this.removeListener('change', callback);
  },

  getResume: function() {
    return (resume ? resume : getResume());
  }

});

AppDispatcher.register(function(payload) {
  var action = payload.action;

  switch (action) {
    case Actions.GETRESUME:
      this.GetResume
      break;
    default:
      return true;
  };

  ResumeStore.emitChange();

  return true;
})

module.exports = ResumeStore;