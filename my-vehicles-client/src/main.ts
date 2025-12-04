import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { App } from './app/app';

bootstrapApplication(App, appConfig)
  .catch((err) => {
    // TODO: log and deal with errors properly. 
    // - show nice ui
    // - send to server using appinsights or something...
    console.error(err);
  });
