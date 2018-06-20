var HtmlToReactParser = require('html-to-react').Parser;

var HtmlToReactTransform = {
  transform: function (html) {
    var htmlToReactParser = new HtmlToReactParser();
    var reactElement = htmlToReactParser.parse(html);
    return reactElement;
  }
}

module.exports = HtmlToReactTransform;