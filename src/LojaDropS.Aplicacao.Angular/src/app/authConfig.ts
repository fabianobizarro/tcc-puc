import { AuthConfig } from "angular-oauth2-oidc";
import { environment } from "../environments/environment";

export const authConfig: AuthConfig = {
    issuer: environment.authority,
    requireHttps: true,
    redirectUri: 'http://localhost:4200/#/login-callback?',
    postLogoutRedirectUri: 'http://localhost:4200/#/',
    clientId: 'lojadrops.marketplace',
    scope: "api.vendas:full openid profile email roles",
    oidc: true,
    clearHashAfterLogin: true,
}