# MyVehicles

A simple demo of an Angular V21 client app running in an ASP.Net Core MVC web app using Web Api

It demonstrates
 - Deploping Angular SPA from a ASP.Net core website
 - Using Web Api to exchange data with the client app.
 - Cookie based authentication of the website and the Angular app
 - SignalR data exchange between the client and server

 It isn't hardened or optimised for production use.

 Tests
  - oh dear. There are no UI tests. 

 API documentation is available at https://localhost:7069/scalar
  - this will require logging in via the normal cookie based login to 
  get api calls to work.
  - scalar won't show you the auth cookie. But login and it will be sent.
  - api docs dont have nice comments yet.

In Development, this app requires login on the server as cookie authentication is used.
- Start the ASP.Net core app and navigate to https://localhost:7069
- Login as b.ross@example.com and any password
- Go back to the Angular app at https://localhost:4200 after starting it with ng serve as normal.

In production, the Angular app is copied to the ASP.Net MVC app and deployed from wwwroot/dist
- Start the ASP.Net core app and navigate to https://localhost:7069
- Login as b.ross@example.com and any password
- The app will redirect you to the Angular page.