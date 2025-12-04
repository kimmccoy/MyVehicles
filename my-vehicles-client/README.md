# my-vehicles-client

A simple demo of an Angular V21 client app running in an ASP.Net Core MVC web app using Web Api

It demonstrates
 - Deploping Angular SPA from a ASP.Net core website
 - Using Web Api to exchange data with the client app.
 - Cookie based authentication of the website and the Angular app
 - SignalR data exchange between the client and server

 It isn't hardened or optimised for production use.

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

Build as normal before production. This outputs to wwwroot/dist in the asp.net app:
```
ng build
```
-------------------------------------------




This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 21.0.1.

## Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## Code scaffolding

Angular CLI includes powerful code scaffolding tools. To generate a new component, run:

```bash
ng generate component component-name
```

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

## Building

To build the project run:

```bash
ng build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Running unit tests

To execute unit tests with the [Vitest](https://vitest.dev/) test runner, use the following command:

```bash
ng test
```

## Running end-to-end tests

For end-to-end (e2e) testing, run:

```bash
ng e2e
```

Angular CLI does not come with an end-to-end testing framework by default. You can choose one that suits your needs.

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.
