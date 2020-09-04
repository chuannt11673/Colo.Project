import { WebStorageStateStore, CordovaPopupNavigator, UserManagerSettings } from 'oidc-client';

export const environment = {
  production: true  
};

export const oidcGrantTypes = {
  authorizationCode: 'code',
  implicit: 'id_token token'
}

export const clientSetting: UserManagerSettings = {
  authority: 'http://192.168.0.102/RC/',
  client_id: 'mobile',
  client_secret: 'secret',
  popup_redirect_uri: 'https://ionic-hats.com/auth-callback',
  post_logout_redirect_uri: 'https://ionic-hats.com/',
  response_type: oidcGrantTypes.authorizationCode,
  scope: 'openid profile email offline_access colo.netcore.api',
  filterProtocolClaims: true,
  loadUserInfo: true,
  userStore: new WebStorageStateStore({ store: window.localStorage }),
  popupNavigator: new CordovaPopupNavigator()
};

export const httpEndpoint: string = 'http://192.168.0.102/Api/';