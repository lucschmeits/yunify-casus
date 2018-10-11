import { Component, OnInit } from '@angular/core';
import { OfficeService } from '../../services/office.service';
import { OfficeDetail } from '../../models/office-detail';

@Component({
  selector: 'app-office',
  templateUrl: './office.component.html',
  styleUrls: ['./office.component.css']
})
export class OfficeComponent implements OnInit {

  offices: OfficeDetail[] = [];

  constructor(private officeService: OfficeService) { }

  ngOnInit() {
    this.officeService.getOffices().subscribe(
      data => {
        this.offices = data;
      }
    );

    console.log(this.offices);
  }

  onSubmit(newOffice){
    this.officeService.addOffice(newOffice.value).subscribe(data => {
      console.log(data);
    });
  }

}
