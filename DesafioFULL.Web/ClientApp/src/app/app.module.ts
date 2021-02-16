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
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { LoginComponent } from './usuario/login/login.component';
import { GuardaRotas } from './autorizacao/guarda.rotas';
import { UsuarioServico } from './servicos/usuario/usuario.servico';
import { CadastroUsuarioComponent } from './usuario/cadastro/cadastro.usuario.component';
import { ListagemClienteComponent } from './cliente/listagem/listagem.cliente.component';
import { CadastroClienteComponent } from './cliente/cadastro/cadastro.cliente.component';
import { ClienteServico } from './servicos/cliente/cliente.servico';


 
@NgModule({
  declarations: [
    CPFPipe,
    FoneMaskPipe,
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    CadastroUsuarioComponent,
    ListagemClienteComponent,
    CadastroClienteComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'login', component: LoginComponent },
      { path: 'cadastro-usuario', component: CadastroUsuarioComponent },
      { path: 'clientes', component: ListagemClienteComponent, /*canActivate: [GuardaRotas] */},
      { path: 'cadastro-cliente', component: CadastroClienteComponent/*, canActivate: [GuardaRotas]*/ },
    ])
  ],
  providers: [UsuarioServico, ClienteServico],
  bootstrap: [AppComponent]
})
export class AppModule { }
