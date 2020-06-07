import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AngularFireStorage } from '@angular/fire/storage';

import {MatCalendar} from '@angular/material/datepicker';
import {DateAdapter, MAT_DATE_FORMATS, MatDateFormats} from '@angular/material/core';

import { finalize } from 'rxjs/operators';

import { MyValidators  } from '../../../utils/validators';

import { PatientsService } from '../../../core/services/patients/patients.service';
import { AppointmentsService } from '../../../core/services/appointments/appointments.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-form-product',
  templateUrl: './form-patient.component.html',
  styleUrls: ['./form-patient.component.scss']
})
export class FormPatientComponent implements OnInit {

  form: FormGroup;
  image$: Observable<any>;
  ID;
  constructor(
    private formBuilder: FormBuilder,
    private patientsService: PatientsService,
    private appointmentsService: AppointmentsService,
    private router: Router,
    private storage: AngularFireStorage
  ) {
    this.buildForm();
   }

  ngOnInit(): void {
    this.FecthAppointments();
   }


  saveProduct(event: Event) {
    event.preventDefault();
    if (this.form.valid) {
      const product = this.form.value;
      this.patientsService.createpatient(product)
      .subscribe((newPatient) => {
      console.log(newPatient);
      this.router.navigate(['./admin/patients']);
      });
    }
    console.log(this.form.value);
  }


  private buildForm() {
    this.form = this.formBuilder.group({
     id: ['', [Validators.required]],
     PatientId: ['', [Validators.required]],
     AppointmentType: ['', [Validators.required]],
     datepicker: [''],
     description: ['', [Validators.required]]
    });
  }

  get proceField() {
    return this.form.get('price');
  }

  FecthAppointments() {
    this.appointmentsService.getAllAppointments()
    .subscribe(appointments => {
      const ID = appointments.length;
      this.ID = ID + 1;
    });
  }
}
