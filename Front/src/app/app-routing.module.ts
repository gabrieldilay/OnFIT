import { SobreComponent } from './sobre/sobre.component';
import { MeusTreinosComponent } from './meus-treinos/meus-treinos.component';
import { PerfilAlunoComponent } from './perfil-aluno/perfil-aluno.component';
import { BuscarProfessorComponent } from './buscar-professor/buscar-professor.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {path: "", component: HomeComponent},
  {path: "home", component: HomeComponent},
  {path: "buscar-professor", component: BuscarProfessorComponent},
  {path: "meu-perfil", component: PerfilAlunoComponent},
  {path: "meus-treinos", component: MeusTreinosComponent},
  {path: "sobre", component: SobreComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
