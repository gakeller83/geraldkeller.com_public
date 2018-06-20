var ActionConstants = require('./ActionConstants')
var AppDispatcher = require('../AppDispatcher');

var Actions = {
  login: function (data) {
    AppDispatcher.handleAction(ActionConstants.ACTION_LOGIN,data);
  },

  registerUser: function (data) {
    AppDispatcher.handleAction(ActionConstants.ACTION_REGISTER_USER, data);
  },

  getResume: function () {
    AppDispatcher.handleAction(ActionConstants.ACTION_GETRESUME, {});
  },

  resumeReceived: function () {
    AppDispatcher.handleAction(ActionConstants.ACTION_RESUMERECEIVED, {});
  }

};

module.exports = Actions;
