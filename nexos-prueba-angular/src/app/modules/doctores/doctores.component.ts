import { Component, OnInit } from '@angular/core';
import { Doctores } from 'src/app/shared/services/doctores/doctores.model';
import { DoctoresService } from 'src/app/shared/services/doctores/doctores.service';

@Component({
  selector: 'app-doctores',
  templateUrl: './doctores.component.html',
  styleUrls: ['./doctores.component.scss']
})
export class DoctoresComponent implements OnInit {

  constructor(private doctorService : DoctoresService) { }
  doctoresList : Doctores[];
  ngOnInit(): void {
    this.doctorService.getDoctores().subscribe((res:any) => {
      this.doctoresList = res;
    })
  }

}
