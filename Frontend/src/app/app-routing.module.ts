import { TreinoComponent } from './treino/treino.component';
import { TreinadorComponent } from './treinador/treinador.component';
import { ContaComponent } from './conta-aluno/conta.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { SobreComponent } from './sobre/sobre.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';


const routes: Routes = [
  { path: "", component: HomeComponent},
  {path: "home", component: HomeComponent},
  {path: "treino", component: TreinoComponent},
  {path: "treinador", component: TreinadorComponent},
  {path: "conta-aluno", component: ContaComponent},
  {path: "cadastro", component: CadastroComponent},
  {path: "sobre", component: SobreComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
