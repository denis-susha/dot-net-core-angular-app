# DotNetCoreAngularApp
**The demonstration .NET Core API + Angular application**
The application contains two steps of the user registration process.

## What does the app use?
.NET 7\
Angular 15\
Entity Framework Core 7\
Database migrations\
Angular material UI\
PostgreSQL\
NUnit\
Swagger

## How to run the app?
### 1. Pre-Run
Make sure you have installed:
1. .NET 7.0
2. Node.js v16.14.0+
3. PostgreSQL server with credentials `Username=postgres;Password=1234` or change the connection string in `appsettings.json`.
### 2. Run
Open the solution in Visual Studio and just press `Ctrl+F5`!
The integrated SPA proxy will help to automatically build and serve the angular part.
The database will be created automatically by migrations and some intial data will be seeded.

## How to use?
The browser page will be opened automatically on run the app.\
Application URL: `https://localhost:44414`\
API URLs: `https://localhost:7161, http://localhost:5244`\
Swagger: `https://localhost:7161/swagger/index.html`
