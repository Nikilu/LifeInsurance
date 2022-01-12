# LifeInsurance
Life Insurance Test with Web and Microservice with API Gateway

## Tech Stack
* AutoMapper 
* NewtonsoftJson
* AutoFixture
* Shouldly
* xunit
* AutoMapper
* Ocelot
* Angular 12
* Bootstrap

## AngularUI - AspNetCore - Microservices - API Gateway

Angular front end AspNetCoreMicroservices with API Gateway.
Windows10 Machine
Visual Studio 2019  

Pull the repository LifeInsurance

Open Solution file AngularMicroservices.sln
In developer command navigate to path ~\AngularMicroservices\AngularWebUI\

Install node components globally by running command npm install -g @angular/cli

In Solution Explorer expand ClientApp project, find the package.json . Right click the file and Restore Packages
In developer command navigate to path ~\Occupation.Web\ClientApp\

# MicroService & API Gateway 

Rebuild Solution by right clicking on solution LifeInsurance.sln in Solution Explorer. Make sure solution Rebuild without any fail. It should Rebuild without any fail

In LifeInsurance solution property, Set Multiple Startup Projects. Select all projects to Start, Click Apply, Click Ok.

Press F5 to debug, you can rebuild solution just to make sure it builds without any fail.

## URLs:
Angular UI:
http://localhost:4200

Occupation Microservice:
http://localhost:62353/api/occupation

PremiumCalculation Microservice:
http://localhost:65037/api/premium

APIGateway:
https://localhost:44327 

## Unit testing
100% Test coverage

# ClientApp - UI
run command ng build 

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 12.2.14.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).



View Occupation Microservices - Working
View PremiumCalculation Microservices - Working
View APIGateway -  Working  
