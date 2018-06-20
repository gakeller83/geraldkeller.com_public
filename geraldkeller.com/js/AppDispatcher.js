var Dispatcher = require('./node_modules/flux').Dispatcher

var AppDispatcher = new Dispatcher();

AppDispatcher.handleAction = function (action, data) {
  this.dispatch({
    action: action,
    data: data
  });
}
module.exports = AppDispatcher;