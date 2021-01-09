// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
import { Config } from '@abpdz/ng.core';

const baseUrl = '';

export const environment = {
  production: false,
  idleTime: 10 * 60 * 1000, // 10 minute
  hmr: true,
  application: {
    baseUrl,
    name: 'ngaspnetcore',
    logoUrl: '',
  },
  oAuthConfig: {
    skipIssuerCheck: true,
    issuer: window.location.origin,
    redirectUri: window.location.origin,
    clientId: 'IDS_CLIENT_App',
    clientSecret: '1q2w3e*',
    scope: "IDS_CLIENT openid profile",
    tokenUrl: '/connect/token',
    loginUrl: '/auth/login',
  },
  apis: {
    default: {
      url: '',
      rootNamespace: 'ngaspnetcore',
    },
  },
} as Config.Environment;

(window as any).ngEx = {
  invalidControls: (form: any) => {
    const ret: any = {};
    let retn = false;
    Object.keys(form.controls).forEach((k) => {
      if (form?.controls && form.controls[k]?.invalid) {
        retn = true;
        ret[k] = form.controls[k];
      }
    });
    return retn ? ret : null;
  },
  query: (com: any) => (window as any).ng.getComponent(document.querySelector(com)),
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
