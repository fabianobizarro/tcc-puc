import { Component, OnInit } from '@angular/core';
import { OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc';
import { authConfig } from 'src/app/authConfig';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private oauth: OAuthService) { }

  ngOnInit() {
    this.configureOAuth();
  }


  configureOAuth() {
    this.oauth.configure(authConfig);
    this.oauth.tokenValidationHandler = new JwksValidationHandler();
    this.oauth.loadDiscoveryDocument();
    this.oauth.initImplicitFlow();
  }

}
