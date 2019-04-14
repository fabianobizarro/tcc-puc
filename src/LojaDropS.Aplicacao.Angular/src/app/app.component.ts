import { Component } from '@angular/core';
import { OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc';
import { authConfig } from './authConfig';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'LojaDropSAplicacaoAngular';

  constructor(private oauth: OAuthService){

  }

  isAuthenticated(): boolean {
    return this.oauth.hasValidIdToken();
  }

  logout(){
    this.oauth.logOut(false);
  }

  
}
