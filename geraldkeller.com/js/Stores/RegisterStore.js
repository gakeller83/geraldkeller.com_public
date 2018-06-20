'use strict';

var EventEmitter = require('events').EventEmitter;
var HttpController = require('../Controllers/HttpController');
var ActionConstants = require('../Actions/ActionConstants');
var Actions = require('../Actions/Actions');
var AppDispatcher = require('../AppDispatcher');
var _ = require('underscore');

var resume = '';

var RegisterStore = _.extend({}, EventEmitter.prototype, {

  emitChange: function () {
    this.emit('change');
  },

  addChangeListener: function (callback) {
    this.on('change', callback);
  },

  removeChangeListener: function (callback) {
    this.removeListener('change', callback);
  },

  registerUser: function (user) {
    var postPackage = {
      callbackAction: ActionConstants.ACTION_REGISTER_USER_COMPLETE, data: user
    }
    HttpController.post('/api/User/create', postPackage);
  },
  registerUserComplete: function (response) {
    var output = JSON.parse(response);
    var j = 1;
  }
});

AppDispatcher.register(function (payload) {
  var action = payload.action;

  switch (action) {
    case ActionConstants.ACTION_REGISTER_USER:
      RegisterStore.registerUser(payload.data)
      break;
    case ActionConstants.ACTION_REGISTER_USER_COMPLETE:
      RegisterStore.registerUserComplete(payload.data)
    default:
      return true;
  };
  return true;
})

module.exports = RegisterStore;