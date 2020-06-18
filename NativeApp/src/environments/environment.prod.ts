import { WebStorageStateStore, CordovaPopupNavigator, UserManagerSettings } from 'oidc-client';

export const environment = {
  production: true  
};

export const clientSetting: UserManagerSettings = {
  authority: 'https://192.168.0.102:5001/',
  client_id: 'ionic',
  client_secret: 'secret',
  popup_redirect_uri: 'https://ionic-hats.com/auth-callback',
  post_logout_redirect_uri: 'https://ionic-hats.com/',
  response_type: "code",
  scope: 'openid profile',
  filterProtocolClaims: true,
  loadUserInfo: true,
  userStore: new WebStorageStateStore({ store: window.localStorage }),
  popupNavigator: new CordovaPopupNavigator()
};

export const httpEndpoint: string = 'https://localhost:5006/';
