import { ApplicationConfig, provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';

// Import animations and PrimeNG theme providers
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { providePrimeNG } from 'primeng/config';
import Lara from '@primeuix/themes/lara';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes),

    // Enable animations (Required for PrimeNG cards and buttons to look smooth)
    provideAnimationsAsync(),
    
    // Setup PrimeNG with the Modern Theme
    providePrimeNG({
      theme: {
        preset: Lara,
        options: {
          darkModeSelector: 'none' // Keep it light mode
        }
      }
    })
  ]
};
