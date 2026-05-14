import { ApplicationConfig, provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';

// 1. Import animations (required for PrimeNG dialogs and alerts)
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
// 2. Import PrimeNG provider and the specific theme you want
import { providePrimeNG } from 'primeng/config';
import Lara from '@primeuix/themes/lara';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes),

    // Enable animations
    provideAnimationsAsync(),
    
    // Configure PrimeNG with the new theme system
    providePrimeNG({
      theme: {
        preset: Lara,
        options: {
          darkModeSelector: 'none' // Prevents switching to dark mode unexpectedly
        }
      }
    })
  ]
};
