# live-pricing-tool
Demo project for live pricing tool for interview task

## Task
* Develop a web-based application for creating interactive dashboards with drag-and-drop modules.
* Current task to be finished is creating a live pricing tool.
* Create back-end and front-end part.

## Development plan
The approach involves creating two separate applications: one for the back-end and one for the front-end. Communication between them will be handled via a Web API, while the live pricing tool will use WebSockets for real-time updates.

### Back-end
* Back-end app will be developed using ASP.NET. This framework is well suited for backend development of large scale applications. It is high performant and offers numerous built-in components, third party tools and support for API generation, authorization and authentication, which can reduce development time.
  
* Creating project structure steps
  * Create test project
  * Create auth service
  * Create service layer for accessing database
  * Create application services layer for returning results to controllers
  * Create Asp .Net controllers for Web Socket endpoints

### Front-end
* Front-end will be Vue.js app that will use WebSockets to query server and show charts with returned data.

* Creating project structure steps
   * Create new vue project with vite
   * Delete not necessary files
   * Add View and component for Prices
   * Tests

## Project descriptions

### Back-end
* ASP.NET Solution projects:
  * Web server (Server.WS)
      * Program.cs - all needed setup and configuration to run the app, declaring some middlewares and injecting services
      * Controllers for WebSocket endpoint (PricesWSController) and for API endpoints (AuthController, ApiController).
  * Unit tests (Server.Tests)
      * Class for unit testing PriceTickerService
  * Application services layer (Server.Services)
      * Service for getting real time rates from provider. It this example the provider class is the database layer. (PriceTickerService)
  * Data Layer (Server.Data)
      * Data access layer, that gets data from database. This is pre-filled list with some example prices.
      * Model - database model classes
      * DTO - some models using for transfering objects

### Front-end


## Dependencies
### Back-end dependencies
* run on .Net 8
* dev dependencies
  * .Net 8
  * Nuget packages
    * Microsoft.AspNetCode.Authentication.JWTBearer
    * Microsoft.IdentityModel.JsonWebTokens
    * xunit
    * xunit.runner.visualstudio
    * Moq
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
