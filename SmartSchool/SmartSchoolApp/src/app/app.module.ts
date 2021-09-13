import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import {NgxPaginationModule} from 'ngx-pagination'; // <-- import the module
import { AlunosComponent } from './components/alunos/alunos.component';
import { ProfessoresComponent } from './components/professores/professores.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { NavComponent } from './components/shared/nav/nav.component';
import { TitleComponent } from './components/shared/title/title.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProfessoresAlunosComponent } from './components/alunos/professores-alunos/professores-alunos.component';
import { AlunosProfessoresComponent } from './components/professores/alunos-professores/alunos-professores.component';
import { ProfessorDetalheComponent } from './components/professores/professor-detalhe/professor-detalhe.component';

@NgModule({
  declarations: [
    AppComponent,
    AlunosComponent,
    AlunosProfessoresComponent,
    ProfessorDetalheComponent,
    ProfessoresComponent,
    ProfessoresAlunosComponent,
    PerfilComponent,
    NavComponent,
    TitleComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    NgxSpinnerModule,
    NgxPaginationModule,
    ToastrModule.forRoot({
      timeOut: 3500,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true,
      closeButton: true
    }),
    BsDropdownModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
