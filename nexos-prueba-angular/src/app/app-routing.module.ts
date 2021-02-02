import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path:'pacientes',
    loadChildren: () => import('./modules/pacientes/pacientes.module').then(m => m.PacientesModule)
  },
  {
    path:'doctores',
    loadChildren: () => import('./modules/doctores/doctores.module').then(m => m.DoctoresModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
