# TrainStationAssistant
The purpose of the application is to improve the management of the railway station and to help disabled people travel by trains efficiently. It is a convenient tool supporting a train station in arranging a schedule of help for people with disabilities using public transport.

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)
* [Screenshots](#examples)

## General info
This application communicates with Oracle DB. It was made in **January 2021**.

## Technologies
* C#
* OracleDB
* Dapper (Object-Relational Mapping)

## Setup
Clone this repository using git bash:
```
https://github.com/bartosztkowalski/TrainStationAssistant.git
```
It`s preferred to open in Visual Studio 2019.

To connect with database you must fill ConnectionString in ```App.config``` (all 'xxx' parts of string).
It is located in ./station-app folder. 

```
<add name="OracleDB" connectionString="Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=xxx)(HOST=xxx)(PORT=xxx))(CONNECT_DATA=(SERVICE_NAME=xxx)));User Id=xxx;Password=xxx;" providerName="Oracle.ManagedDataAccess.Client"/>
```

## Screenshots
![Main menu](./examples/00.png)
![Timetable](./examples/01.png)
![Statistics](./examples/02.png)
![Help schedule](./examples/03.png)