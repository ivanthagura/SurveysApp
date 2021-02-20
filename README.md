# SurveysApp

Application for users to access and fill out surveys

This application consists of 5 projects: 1. API 2. client-app 3. Core 4. Infrastructure 5. Tests

client-app is the front end facing component built in React.
API, Core and Infrastructure projects are .Net Core based projects
API project is WebApi project
Infrastructure and Core projects are Class Libraries
Development database uses SQLlite and can be plugged with any Relation Databases

Requirements to run the project:
.Net Core 3.1 or higher
Node 8 or higher
Dotnet tools -> dotnet ef 5.0.3 or higher

To run the project:

In development mode:

Run the api first ->
cd Api
dotnet watch run (First call will create the SQLlite db from migrations and seed data)

Run the front end app ->
cd..
cd client-app
npm install (install all packages)
npm start

In production mode:
run "npm run build" inside client-app to publish the front end project inside the wwwroot of API project
running API project now will run the published client app in the browser

Test project consists of unit tests on the DBContext by creating a mock database with dummy data.

Assets folder
Consists of the following:

1. Postman collection of API endpoint calls
2. Systems Architecture
3. SQL Design

API project runs on 'https://localhost:5001/' and http://localhost:5000/
client-app runs on 'http://localhost:3000/'
