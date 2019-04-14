import { Component, OnInit } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { authConfig } from 'src/app/authConfig';

@Component({
  selector: 'app-minha-conta',
  templateUrl: './minha-conta.component.html',
  styleUrls: ['./minha-conta.component.css']
})
export class MinhaContaComponent implements OnInit {

  user: any = {};
  constructor(private oauth: OAuthService) { }

  async ngOnInit() {
    
    if (!this.oauth.userinfoEndpoint){
      this.oauth.configure(authConfig);
      await this.oauth.loadDiscoveryDocument();
    }
    this.user = await this.oauth.loadUserProfile();
  }

  get usuario() {
    return this.user;
  }



}
