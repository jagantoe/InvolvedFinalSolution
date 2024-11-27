import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter, withComponentInputBinding } from '@angular/router';

import { provideHttpClient } from '@angular/common/http';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    // We configure the HttpClient so that we can inject it in our services & components
    provideHttpClient(),
    // We configure the router with the routes we created
    // We also enable ComponentInputBinding so we can bind route parameters to Component inputs
    provideRouter(routes, withComponentInputBinding()),
    // Configure animations from Angular Material
    provideAnimationsAsync()]
};
