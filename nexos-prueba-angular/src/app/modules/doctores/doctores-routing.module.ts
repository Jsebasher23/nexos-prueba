import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DoctoresComponent } from './doctores.component';

const routes: Routes = [
  {
    path:'',component:DoctoresComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DoctoresRoutingModule { }
