# _Eau Claire's Salon_

#### _Version 01/17/2020_

#### By _**Nina Potrebich**_

## Description

_An MVC web application to help her manage her employees (stylists) and their clients._

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

* .NET

### Installing

1. Clone this repository:
```
$ git clone url-of-this-repo
```
2. Using console of your choice build and run program in Project directory:
```
dotnet run
```
3. For Unit testing run tests in Project.Tests repository:
```
dotnet test
``` 


CREATE DATABASE nina_potrebich;
USE nina_potrebich;
CREATE TABLE `nina_potrebich`.`stylists` (
  `StylistId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) NULL,
  `Description` VARCHAR(255) NULL,
  PRIMARY KEY (`StylistId`));

CREATE TABLE `nina_potrebich`.`clients` (
  `ClientId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) NULL,
  `Description` VARCHAR(255) NULL,
  `StylistId` INT NULL,
  PRIMARY KEY (`ClientId`));





## Specifications:
* As the salon owner, I need to be able to see a list of all stylists.
* As the salon owner, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
* As the salon owner, I need to add new stylists to our system when they are hired.
* As the salon owner, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added.

If you complete all objectives with time to spare, consider adding the following features (make sure to add tests when necessary):

* Include a form where employees may search for a stylist by name. Display a list of all results.
* Include a form where employees may also search for a client by name. Display a list of all results.
* Add a feature for adding an appointment to a client.
* Add a feature for adding an appointment to a stylist. Add a check to make sure the stylist does not have any conflicting appointments.
* Add a feature for keeping track of how much each stylist was paid for each appointment.
* Add styling to your page.

## Technologies Used

_C#, .NET, CSS, ASP.NET Core MVC, Entity Framework Core, HTML, Bootstrap_

### License

*_Copyright (c) 2020 **Nina Potrebich**_*