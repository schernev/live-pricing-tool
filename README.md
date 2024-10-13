# live-pricing-tool
Demo project for a live pricing tool as part of interview task


## 1. Task
* Develop a web-based application for creating interactive dashboards with drag-and-drop modules.
* Current milestone to be finished is creating a live pricing tool.
* Design and implement back-end and front-end.
* Add docker images for demo.

## 2. Development plan
The approach involves creating two separate applications: one for the back-end and one for the front-end. Communication between them will be handled via a Web API, while the live pricing tool will use WebSockets for real-time updates.

### Back-end
* Back-end app will be developed using ASP.NET. This framework is well suited for backend development of large scale applications. It is high performant and offers numerous built-in components, third party tools and support for API generation, authorization and authentication, which can reduce development time.
  
*  Steps
  * Create project structure
  * Set up a test project
  * Develop authentication service
  * Implement service layer for database access
  * Create application services layer to return results to controllers
  * Develop ASP.NET controllers for WebSocket endpoints

### Front-end
* Front-end will be Vue.js app that will use WebSockets to query server and show charts with returned data. Vue.js is simple and easy to use and very performant javascript framework and is sutable for creating client browser projects.

* Steps
   * Create a new Vue project with vite
   * Add view, component and tests for Home page
   * Add views components for Login and Prices pages

### Containers
* Each project will have its own docker file, which includes scripts for dowloading source code from the repository, building it within the container and starting the container
* A Docker compose file will automate the process of running both app images

 
## 3. Project descriptions

### Back-end
* ASP.NET Solution projects:
  * Web server (Server.WS)
      * Program.cs - contains setup and configuration to run the app, including middleware declarations and injecting services
      * Controllers for WebSocket endpoint (PricesWSController) and for API endpoints (AuthController, ApiController).
  * Unit tests (Server.Tests)
      * Class for unit testing PriceTickerService
  * Application services layer (Server.Services)
      * Service for getting real time rates from provider. It this example the provider class is the database layer. (PriceTickerService)
  * Data Layer (Server.Data)
      * Data access layer, that gets data from database. This is pre-filled list with some example prices.
      * Model and DTO classes for database and object transfer models

### Front-end
* Vue.js application, generated with Vite build tool, using node.js for build app
  * configuration files are in root project folder
  * router subfolder - js router
  * vuews subfolder - vue main view components
  * components subfolder - vue components for Login, PricesDisplay and UserInfo

## 4. Dependencies

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
    * 
### Front-end dependencies
* run on browser
* dev dependencies
  * node.js
  * vue.js
  * npm packages for build project
    * axios
    * vue
    * vue-router
  * npm packages for development
    * @eslint/js
    * @vitejs/plugin-vue
    * @vitest/eslint-plugin
    * @vue/test-utils
    * eslint
    * eslint-plugin-vue
    * jsdom
    * vite
    * vitest


## 5. Installation with Docker Containers

### Prerequisites
  * Docker (ensure that active option is to run linux containers)
  * Docker-compose (make sure that Docker Compose is installed)
    
### Install & run composed containers
  * Navigate to the directory containing docker-compose.yaml file (source root folder)
  * Run the following command:
    ```
    docker-compose up --build
    ```
    
### Individually install the front-end or back-end container as needed.
Note: This step is unnecessary if composed containers were executed in the previous step with Docker compose!
  * Install Back-end App
    * Navigate to the PricingToolServer subfolder
    * Run the command:
      ```
      docker build -f Dockerfile -t serverapp
      ```
      * To run with full debug info and no cache, add parameters:
        ```
        docker build -f Dockerfile -t serverapp . --progress=plain --no-cache
        ```
  * Install Front-end app
    * navigate to subfolder PricingToolClient
    * run command:
      ```
      docker build -f Dockerfile -t clientapp
      ```
      * To run with full debug info and no cache, add parameters:
        ```
        docker build -f Dockerfile -t clientapp . --progress=plain --no-cache
        ```
