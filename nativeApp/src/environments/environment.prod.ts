import { WebStorageStateStore, CordovaPopupNavigator, UserManagerSettings } from 'oidc-client';

export const environment = {
  production: true  
};

export const oidcGrantTypes = {
  authorizationCode: 'code',
  implicit: 'id_token token'
}

export const clientSetting: UserManagerSettings = {
  authority: 'https://192.168.0.102:5001/',
  client_id: 'ionic-native',
  client_secret: 'secret',
  popup_redirect_uri: 'https://ionic-hats.com/auth-callback',
  post_logout_redirect_uri: 'https://ionic-hats.com/',
  response_type: oidcGrantTypes.authorizationCode,
  scope: 'openid profile email colo.netcore.api',
  filterProtocolClaims: true,
  loadUserInfo: true,
  userStore: new WebStorageStateStore({ store: window.localStorage }),
  popupNavigator: new CordovaPopupNavigator()
};

export const httpEndpoint: string = 'https://192.168.0.102:5006/';