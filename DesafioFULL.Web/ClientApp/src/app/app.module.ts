import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { CPFPipe } from './Pipe/cpf.pipe';
import { FoneMaskPipe } from './Pipe/foneMask.pipe';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { GuardaRotas } from './autorizacao/guarda.rotas';
import { LoginComponent } from './usuario/login/login.component';
import { UsuarioServico } from './servicos/usuario/usuario.servico';
import { ListagemClienteComponent } from './cliente/listagem/listagem.cliente.component';
import { CadastroUsuarioComponent } from './usuario/cadastro/cadastro.usuario.component';
import { ClienteServico } from './servicos/cliente/cliente.servico';
import { CadastroClienteComponent } from './cliente/cadastro/cadastro.cliente.component';
import { ListagemTituloComponent } from './titulo/listagem/listagem.titulo.component';
import { TituloServico } from './servicos/titulo/titulo.servico';


 
@NgModule({
  declarations: [
    CPFPipe,
    FoneMaskPipe,
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    CadastroUsuarioComponent,
    ListagemClienteComponent,
    CadastroClienteComponent,
    ListagemClienteComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'cadastro-usuario', component: CadastroUsuarioComponent },
      { path: 'cliente', component: ListagemClienteComponent/*, canActivate: [GuardaRotas] */},
      { path: 'cadastro-cliente', component: CadastroClienteComponent/*, canActivate: [GuardaRotas]*/ },
      { path: 'titulo', component: ListagemTituloComponent/*, canActivate: [GuardaRotas] */ },
      //{ path: 'cadastro-titulo', component: CadastroTituloComponent/*, canActivate: [GuardaRotas]*/ },
    ])
  ],
  providers: [UsuarioServico, ClienteServico, TituloServico],
  bootstrap: [AppComponent]
})
export class AppModule { }
