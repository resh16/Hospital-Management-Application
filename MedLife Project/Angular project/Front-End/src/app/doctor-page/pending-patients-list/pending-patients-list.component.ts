import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ApiService } from 'src/app/shared/Services/api.service';
import { UpdateStatusComponent } from '../update-status/update-status.component';

@Component({
  selector: 'app-pending-patients-list',
  templateUrl: './pending-patients-list.component.html',
  styleUrls: ['./pending-patients-list.component.css']
})
export class PendingPatientsListComponent implements OnInit {

  constructor(public service:ApiService,public dialog : MatDialog) { }

  PendingPatients:any[];

  ngOnInit(): void {
    this.service.ListPendingPatientsDetails().subscribe(res => {
      this.PendingPatients = res;
    })
  }

  openDialog(Id:number){
    console.log(Id);
    const dialogRef = this.dialog.open(UpdateStatusComponent,{data:{id:Id}
    });

    dialogRef.afterClosed().subscribe(result => {
    debugger
    console.log('Dialog box closed');
    });
  }

}
