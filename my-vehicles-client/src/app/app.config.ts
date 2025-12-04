import { ApplicationConfig, provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';


import { routes } from './app.routes';
import { provideDefaultClient } from '../api/providers';
import { environment } from '../environments/environment';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes),
     provideHttpClient(),
     provideDefaultClient({
      basePath: environment.apiBaseUrl,
    })
  ]
};
