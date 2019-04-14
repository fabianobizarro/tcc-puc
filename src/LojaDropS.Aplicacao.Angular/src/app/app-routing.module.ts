import { NgModule } from '@angular/core';
import { Routes, RouterModule, ExtraOptions } from '@angular/router';
import { HomeComponent } from './paginas/home/home.component';
import { ProdutosComponent } from './paginas/produtos/produtos.component';
import { MinhaContaComponent } from './paginas/minha-conta/minha-conta.component';
import { AuthGuard } from './guards/auth.guard';
import { LoginComponent } from './paginas/login/login.component';
import { LoginCallbackComponent } from './paginas/login-callback/login-callback.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full'
  },
  {
    path: 'produtos',
    component: ProdutosComponent,
    pathMatch: 'full'
  },
  {
    path: 'conta',
    component: MinhaContaComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'login-callback',
    component: LoginCallbackComponent
  }
];

const options: ExtraOptions = {
  useHash: true
};

@NgModule({
  imports: [RouterModule.forRoot(routes, options)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
