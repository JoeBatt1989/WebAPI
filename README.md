# Project Title

Simple web services project which can be used to practice automated testing against.

## Description

.Net Core 3.1 services which cover 3 controllers (Client, Car, Address). The services can be ran using IIS Express or Docker. API or performance tests can be executed against the running services.

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