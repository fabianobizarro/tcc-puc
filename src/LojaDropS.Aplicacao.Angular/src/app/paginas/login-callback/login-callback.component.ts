import { Component, OnInit } from '@angular/core';
import { OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc';
import { Router } from '@angular/router';
import { authConfig } from 'src/app/authConfig';

@Component({
  selector: 'app-login-callback',
  templateUrl: './login-callback.component.html',
  styleUrls: ['./login-callback.component.css']
})
export class LoginCallbackComponent implements OnInit {

  constructor(
    private oauth: OAuthService,
    private router: Router) { }

  ngOnInit() {
    this.oauth.configure(authConfig);
    this.oauth.tokenValidationHandler = new JwksValidationHandler();
    this.oauth.loadDiscoveryDocumentAndTryLogin()
      .then(logged => {
        this.router.navigate(['/']);
      });
  }

}
