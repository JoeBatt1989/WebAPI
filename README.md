# Project Title

Simple web services project which can be used to practice automated testing against.

## Description

.Net Core 3.1 services which cover 3 controllers.
* Address
* Car
* Client

Each controller supports GET, POST, PUT, DELETE

Client is 1 to many Addresses <br />
Client is 1 to many Cars

The services can be ran using IIS Express or Docker and swagger documentation can be found at http://localhost:{port}/swagger. API or performance tests can be executed against the running services.

## Getting Started

### Dependencies

* Docker

OR

* .Net Core 3.1 SDK
* IIS Express enabled (https://www.jetbrains.com/help/rider/Running_IISExpress.html)

### Running the Services

**Docker**
* docker build -t webapi .
* docker run -d -p 44387:80 --name myservices webapi

**IIS Express**
* Open solution in Visual Studio
* Select IIS Express

## Authors

Joe Batt