# BankingApp
Backend for Banking application with Command Query Responsibility Segregation (SQRS) Pattern.

The Application is divided into Core, Infrastructure, Application, and API projects.

`CORE` project contains entities and abstraction.

`INFRASTRUCTURE` project contains DbSets for each entity.

`APPLICATION` project contains business logic.

`API project` contains controllers that interact with the other projects with Mediatr.

# REST API

API endpoints are described below.

# UserController

## Create a new User
### Request
`POST user/create-user`

    curl -i -H 'Accept: application/json' -d 'firstName=John&lastName=Doe&iin=750514501045&birthDate=2022-04-08T14:53:11.995Z&gender=male&phoneNumber=87772679089&password=root' http://localhost:5000/user/create-user

### Response

    HTTP/1.1 201 Created
    Date: Thu, 24 Feb 2011 12:36:30 GMT
    Status: 201 Created
    Connection: close
    Content-Type: application/json
    Location: /thing/1
    Content-Length: 36

    {"id":1,"firstName":"John","lastName":"Doe"}
