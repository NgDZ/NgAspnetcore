// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.

(window as any).ngEx = {
  invalidControls: (form) => {
    const ret = {};
    let retn = false;
    Object.keys(form.controls).forEach((k) => {
      if (form?.controls && form.controls[k]?.invalid) {
        retn = true;
        ret[k] = form.controls[k];
      }
    });
    return retn ? ret : null;
  },
  query: (com) => (window as any).ng.getComponent(document.querySelector(com)),
  component: (com) => (window as any).ng.getComponent(document.querySelector(com)),
};
