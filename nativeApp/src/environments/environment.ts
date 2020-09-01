// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
import { UserManagerSettings, WebStorageStateStore } from 'oidc-client';

export const environment = {
  production: false
};

export const oidcGrantTypes = {
  authorizationCode: 'code',
  implicit: 'id_token token'
}

export const clientSetting: UserManagerSettings = {
  authority: 'http://192.168.0.102/RC/',
  client_id: 'webapp',
  client_secret: 'secret',
  popup_redirect_uri: 'http://localhost:8100/auth-callback',
  post_logout_redirect_uri: 'http://localhost:8100/',
  response_type: oidcGrantTypes.authorizationCode,
  scope: 'openid profile email offline_access colo.netcore.api',
  filterProtocolClaims: true,
  loadUserInfo: true,
  userStore: new WebStorageStateStore({ store: window.localStorage })
};

export const httpEndpoint: string = 'https://localhost:5006/';

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
