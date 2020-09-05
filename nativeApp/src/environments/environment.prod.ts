import { WebStorageStateStore, CordovaPopupNavigator, UserManagerSettings } from 'oidc-client';

export const environment = {
  production: true  
};

export const oidcGrantTypes = {
  authorizationCode: 'code',
  implicit: 'id_token token'
}

export const clientSetting: UserManagerSettings = {
  authority: 'https://webapplication20200905205313.azurewebsites.net/',
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

export const httpEndpoint: string = 'https://webapi20200905211353.azurewebsites.net/';