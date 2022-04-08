# BankingApp
Backend for Banking application with Command Query Responsibility Segregation (SQRS) Pattern.

The Application is divided into Core, Infrastructure, Application, and API projects.

`CORE` project contains entities and abstraction.

`INFRASTRUCTURE` project contains DbSets for each entity.

`APPLICATION` project contains business logic.

`API project` contains controllers that interact with the other projects with Mediatr.
