import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from "@angular/forms";
import { OAuthModule } from "angular-oauth2-oidc";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './paginas/home/home.component';
import { ProdutosComponent } from './paginas/produtos/produtos.component';
import { SpinnerComponent } from './componentes/spinner/spinner.component';
import { LoginComponent } from './paginas/login/login.component';
import { MinhaContaComponent } from './paginas/minha-conta/minha-conta.component';
import { LoginCallbackComponent } from './paginas/login-callback/login-callback.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProdutosComponent,
    SpinnerComponent,
    LoginComponent,
    MinhaContaComponent,
    LoginCallbackComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    OAuthModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
