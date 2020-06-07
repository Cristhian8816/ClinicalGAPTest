import { Component, OnInit } from '@angular/core';

import { PatientsService } from '../../../core/services/patients/patients.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.scss']
})
export class PatientListComponent implements OnInit {

  products = [];
  displayedColumns: string[] = ['Patientid', 'Name', 'Phone NUmber', 'Address', 'actions'];

  constructor(
    private patientServices: PatientsService
  ) { }

  ngOnInit(): void {
    this.fetchProducts();
  }

  fetchProducts() {
    this.patientServices.getAllPatients()
    .subscribe(products => {
      this.products = products;
    });
  }
  deleteProduct(id: string) {
    this.patientServices.deletepatient(id)
    .subscribe(rta => {
      this.fetchProducts();
    });
  }

}
