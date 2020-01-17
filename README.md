# _Eau Claire's Salon_

#### _Version 01/17/2020_

#### By _**Nina Potrebich**_

## Description

_An MVC web application to help her manage her employees (stylists) and their clients._

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

* .NET
* MySqlServer

### Installing

1. Clone this repository:
```
$ git clone url-of-this-repo
```
2. Start MySql server by using command:
```
mysql start
```
3. Access MySql by executing the command:
```
mysql -uroot -pepicodus
```
4. Create required for project databases using MySql and next commands
```
CREATE DATABASE nina_potrebich;
USE nina_potrebich;
CREATE TABLE `nina_potrebich`.`stylists` (
  `StylistId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) NOT NULL,
  `Description` VARCHAR(255) NULL,
  PRIMARY KEY (`StylistId`));

CREATE TABLE `nina_potrebich`.`clients` (
  `ClientId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) NOT NULL,
  `Description` VARCHAR(255) NULL,
  `StylistId` INT NOT NULL,
  PRIMARY KEY (`ClientId`));

CREATE TABLE `nina_potrebich`.`appointments` (
  `AppointmentId` INT NOT NULL AUTO_INCREMENT,
  `ClientId` INT NOT NULL,
  `StylistId` INT NOT NULL,
  `Description` VARCHAR(255) NULL,
  `Time` DATETIME NOT NULL,
  PRIMARY KEY (`AppointmentId`));

```
5. Using console of your choice build and run program in Project directory:
```
dotnet run
```

## Specifications:
* As the salon owner, you is able to see a list of all stylists.
* As the salon owner, you is able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
* As the salon owner, you is able to add new stylists to our system when they are hired.
* As the salon owner, you is able to add new clients to a specific stylist. You are not be able to add a client if no stylists have been added.
* As the salon owner, you are able search for a stylist by name and get a list of all results.
* As the salon owner, you are able to search for a client by name and get a list of all results.
* Add a feature for adding an appointment to a client.
<!-- * Add a feature for adding an appointment to a stylist. Add a check to make sure the stylist does not have any conflicting appointments.
* Add a feature for keeping track of how much each stylist was paid for each appointment. -->

## Technologies Used

_C#, .NET, CSS, ASP.NET Core MVC, Entity Framework Core, HTML, Bootstrap_

### License

*_Copyright (c) 2020 **Nina Potrebich**_*