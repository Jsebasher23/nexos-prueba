import { Component, OnInit } from '@angular/core';
import { Pacientes } from 'src/app/shared/services/pacientes/pacientes.model';
import { PacientesService } from 'src/app/shared/services/pacientes/pacientes.service';

@Component({
  selector: 'app-pacientes',
  templateUrl: './pacientes.component.html',
  styleUrls: ['./pacientes.component.scss']
})
export class PacientesComponent implements OnInit {

  constructor(private pacienteService: PacientesService) { }

  pacientesLsit : Pacientes[]=[];
  ngOnInit(): void {
    this.pacienteService.getPacientes().subscribe((res:any) => {
      this.pacientesLsit = res;
    })
  }



}
