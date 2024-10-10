# live-pricing-tool
Demo project for live pricing tool for interview task

## Task
* Develop a web-based application for creating interactive dashboards with drag-and-drop modules.
* Current task to be finished is creating a live pricing tool.
* Create back-end and front-end part.

## Development plan
The approach is to create two different apps for back-end for front-end part.

### Back-end
* Back-end app will be Asp .Net application. It is suitable for backend development of large scale applications
  
* Creating project structure steps
  * Create test project
  * Create auth service
  * Create service layer for accessing database
  * Create application services layer for returning results to controllers
  * Create Asp .Net controllers for Web Socket endpoints

N.B. For simplicity different projects in solution have inner references, 
dependency injection must be applied to decouple projects in the solution!

### Front-end
* Front-end will be Vue.js app that will use WebSockets to query server and show charts with returned data.

* Creating project structure steps
   * Create new vue project with vite
   * Delete not necessary files
   * Add View and component for Prices
   * Tests

## Dependencies
### Back-end dependencies
* run on .Net 8
* dev dependencies
  * .Net 8
### Front-end dependencies
* run on browser
* dev dependencies
  * node.js
  * vue.js
  * ...

## Installation
### Back-end installation
* ...
### Front-end installacion
* ...

## Contact
Stefan Chernev
schernev@gmail.com
