'use strict';
var AppDispatcher = require('../AppDispatcher');

var HttpController = {
  post: function (url, postPackage) {
    fetch(url, {
      method: 'POST',
      headers: {
        'Accept': 'application/json, text/javascript',
        'Content-type': 'application/json; charset=UTF-8'
      },
      body: JSON.stringify(postPackage.data)
    }).then(function (response) {
      AppDispatcher.handleAction(postPackage.callbackAction, response)
    }).catch(function (err) {
      AppDispatcher.handleAction(postPackage.callbackAction, err)
    })
  },

  get: function (url, callback) {
    fetch(url, { method: 'GET', headers: { 'Accept': 'application/json', 'Content-Type': 'application/json' } })
      .then((response) => response.json())
      .then(function (data) { callback(data) });
  }
}

      

module.exports = HttpController;