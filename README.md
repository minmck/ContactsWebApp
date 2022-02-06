# ContactsWebApp

A simple web application (React + .NET) where user can create an account, login and add, update and delete contacts.

.NET part was coded with best practices in mind, so it contains:
- Three layer architecture.
- Dependency injection.
- Repository pattern.
- Asynchronous code.
- DTOs to transfer data.
- Unit tests.

React.js part was created from separate and reusable components.

## Technologies
- React.
- ASP.NET Core API.
- Entity framework core.
- Microsoft SQL.
- User authentication with JWT token.
- Axios library for HTTP requests.

## Launch
To run the front-end part, open the solution with visual studio code, then run commands on a terminal:
```
$ npm install
$ npm start
```
To run the back-end part, first start MS SQL Server, then open the solution with visual studio and run the command on Package Manager Console to create a database:
```
PM> update-database
```
Start the project.
