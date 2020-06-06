// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  url_api: 'http://localhost:62471/api',
  firebase: {
    apiKey: 'AIzaSyCKdEzY0EhnMbvz6xb0HNSEbLYY2v9TP8M',
    authDomain: 'makelup.firebaseapp.com',
    databaseURL: 'https://makelup.firebaseio.com',
    projectId: 'makelup',
    storageBucket: 'makelup.appspot.com',
    messagingSenderId: '258194245859',
    appId: '1:258194245859:web:6ede978eb50bbd0992ddd6'
  }
};
// URL PLATZI
// return this.http.get<Product[]>('https://platzi-store.herokuapp.com');
// URL Web API Local
// url_api: 'http://localhost:60175/api'
// URL Web API Azure
// url_api: 'https://webangularapicristhian.azurewebsites.net/api'

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
