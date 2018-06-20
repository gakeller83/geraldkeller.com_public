'use strict';
var React = require('react')

class Navbar extends React.Component {
  static displayName = "Navbar";

  render() {
    return (
      React.createElement('div',{},
        React.createElement("nav", { className: "navbar navbar-default navbar-gradient" },
          React.createElement("div", { className: "container-fluid" },
            /* Brand and toggle get grouped for better mobile display */
            React.createElement("div", { className: "navbar-header" },
              React.createElement("button", { type: "button", className: "navbar-toggle collapsed", "data-toggle": "collapse", "data-target": "#navbar-collapse-1", "aria-expanded": "false" },
                React.createElement("span", { className: "sr-only" }, "Toggle navigation"),
                React.createElement("span", { className: "icon-bar" }),
                React.createElement("span", { className: "icon-bar" }),
                React.createElement("span", { className: "icon-bar" })
              ),
              React.createElement("a", { className: "navbar-brand", href: "/home" }, "GeraldKeller.com")
            ),
      /* Collect the nav links, forms, and other content for toggling */
            React.createElement("div", { className: "collapse navbar-collapse", id: "navbar-collapse-1" },
              React.createElement("ul", { className: "nav navbar-nav" },
                React.createElement("li", null, React.createElement("a", { href: "/resume" }, "Resume ")),
                React.createElement("li", null, React.createElement("a", { href: "#" }, "Code Samples ")),
                React.createElement("li", null, React.createElement("a", { href: "#" }, "Contact ")),
                React.createElement("hr", { className: 'no-margin'})
              ),  
              React.createElement("ul", { className: "nav navbar-nav navbar-right" },      
                React.createElement("li", null,
                  React.createElement("a", { href: "/login"}, "Sign in / Register")
                )
              )
            )//.navbar-collapse
          )//container-fluid
        ),//nav
      this.props.children)
    )
  }

  NavigateToLogin = () => {
    
  };
}

module.exports = Navbar