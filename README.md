# BankingApp
Backend for Banking application with Command Query Responsibility Segregation (SQRS) Pattern.

The Application is divided into Core, Infrastructure, Application, and API projects.

`CORE` project contains entities and interfaces.

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
    Date: Thu, 08 April 2022 12:36:30 GMT
    Status: 201 Created
    Connection: close
    Content-Type: application/json
    Location: /user/1

    {"id":1,"firstName":"John","lastName":"Doe", role="Пользователь"}

## Create a new Employee
### Request
`POST user/create-employee`

    curl -i -H 'Accept: application/json' -d 'firstName=John&lastName=Doe&iin=750514501045&birthDate=2022-04-08T14:53:11.995Z&gender=male&phoneNumber=87772679089&password=root&role=Администратор' http://localhost:5000/user/create-employee

### Response

    HTTP/1.1 201 Created
    Date: Thu, 08 April 2022 12:36:30 GMT
    Status: 201 Created
    Connection: close
    Content-Type: application/json
    Location: /user/2

    {"id":2,"firstName":"John","lastName":"Doe", role="Администратор"}
    
    
## Login
### Request
`POST user/login`

    curl -X POST "https://localhost:44324/api/v1/User/login" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "{\"telephone\":\"87073467072\",\"password\":\"admin\"}"

### Response

     access-control-allow-origin: * 
     content-type: application/json; charset=utf-8 
     date: Fri08 Apr 2022 15:02:14 GMT 
     server: Microsoft-IIS/10.0 
     x-powered-by: ASP.NET 
     
    {"id":2,"firstName":"John","lastName":"Doe", role="Администратор"}
    
    
## Add user photo and save in binary
### Request
`POST user/add-user-photo`

    curl -X POST "https://localhost:44324/api/v1/User/add-user-photo" -H  "accept: */*" -H  "Content-Type: multipart/form-data" -F "UserId=1" -F "UserPhoto=@userImage.png;type=image/png"

### Response

     access-control-allow-origin: * 
     content-type: application/json; charset=utf-8 
     date: Fri08 Apr 2022 15:08:53 GMT 
     server: Microsoft-IIS/10.0 
     x-powered-by: ASP.NET 
     
    {"message" : 'Photo is saved!"}
    
# AccountController

## Create new Account
### Request
`POST account/create-account`

    curl -X POST "https://localhost:44324/api/v1/Account/create-account" -H  "accept: */*" -H  "Content-Type: "application/json" -F "UserId=1" -F "AccountType=Депозит"

### Response

     access-control-allow-origin: * 
     content-type: application/json; charset=utf-8 
     date: Fri08 Apr 2022 15:08:53 GMT 
     server: Microsoft-IIS/10.0 
     x-powered-by: ASP.NET 
     
    {"message" : 'Account was created!"}
    
    
## Activate an Account
### Request
`POST account/activate-account`

    curl -X POST "https://localhost:44324/api/v1/Account/activate-account" -H  "accept: */*" -H  "Content-Type: "application/json" -F "UserId=1" -F "AccountType=Депозит" -F "Password=userPassword"

### Response

     access-control-allow-origin: * 
     content-type: application/json; charset=utf-8 
     date: Fri08 Apr 2022 15:08:53 GMT 
     server: Microsoft-IIS/10.0 
     x-powered-by: ASP.NET 
     
    {"message" : 'Account was activated!"}
    
## Deactivate an Account
### Request
`POST account/deactivate-account`

    curl -X POST "https://localhost:44324/api/v1/Account/deactivate-account" -H  "accept: */*" -H  "Content-Type: "application/json" -F "UserId=1" -F "AccountType=Депозит" -F "Password=userPassword"

### Response

     access-control-allow-origin: * 
     content-type: application/json; charset=utf-8 
     date: Fri08 Apr 2022 15:08:53 GMT 
     server: Microsoft-IIS/10.0 
     x-powered-by: ASP.NET 
     
    {"message" : 'Account was deactivated!"}

## Block an Account
### Request
`POST account/block-account`

    curl -X POST "https://localhost:44324/api/v1/Account/block-account" -H  "accept: */*" -H  "Content-Type: "application/json" -F "UserId=1" -F "AccountType=Депозит" -F "Password=adminPassword"

### Response

     access-control-allow-origin: * 
     content-type: application/json; charset=utf-8 
     date: Fri08 Apr 2022 15:08:53 GMT 
     server: Microsoft-IIS/10.0 
     x-powered-by: ASP.NET 
     
    {"message" : 'Account was blocked by admin!"}
    
## Unblock an Account
### Request
`POST account/unblock-account`

    curl -X POST "https://localhost:44324/api/v1/Account/unblock-account" -H  "accept: */*" -H  "Content-Type: "application/json" -F "UserId=1" -F "AccountType=Депозит" -F "Password=adminPassword"

### Response

     access-control-allow-origin: * 
     content-type: application/json; charset=utf-8 
     date: Fri08 Apr 2022 15:08:53 GMT 
     server: Microsoft-IIS/10.0 
     x-powered-by: ASP.NET 
     
    {"message" : 'Account was unblocked by admin!"}


