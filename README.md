# ContactsWebApp

A simple web application (React.js + ASP.NET Core) where user can create an account, login and add, update and delete contacts.

.NET part was coded with best practices in mind, so it contains:
- Three layer architecture.
- Dependency injection.
- Repository pattern.
- DTOs to transfer data.

React.js part was created from separate and reusable components.

## Technologies
- .NET 5.
- Entity framework core.
- Microsoft SQL server.
- User authentication with JWT token.
- Axios for HTTP requests.

## Launch
To run the front-end part, open the solution with visual studio code, then run commands on a terminal:
```
$ npm install
$ npm start
```
To run the back-end part, first start MS SQL Server, then open the solution with visual studio and run this command on Package Manager Console to create a database:
```
PM> update-database
```
If you run the project now, everything should work.
