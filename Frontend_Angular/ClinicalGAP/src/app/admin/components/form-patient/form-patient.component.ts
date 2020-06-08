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
  patientsNames = [];
  patientsIds = [];
  apointmentsTypes = ['Neurologia', 'Medicina general', 'Pediatria', 'Odontologia' ]; 
  form: FormGroup;
  ID;
  PatientName;
  appointmentDate: Date;
  patientNameSelected;
  appointmentTypeSelected;
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
    this.FecthAppointmentsID();
    this.FecthPatients();
   }


  saveProduct(event: Event) {
    event.preventDefault();
    if (this.form.valid) {
      let index = 0;
      let selectedPatientID = 0;
      this.patientsNames.forEach(patientName => {
        if(patientName === this.patientNameSelected[0])
        {
          selectedPatientID = this.patientsIds[index];
        }
        index++;
      });
      const a = { 'AppointmentId': this.ID,
                  'Date': this.appointmentDate,
                  'AppointmentType': this.appointmentTypeSelected[0],
                  'PatientID': selectedPatientID};

      this.appointmentsService.createAppointment(a)
      .subscribe((newappointment) => {
      console.log(newappointment);
      this.router.navigate(['./admin/appointments']);
      });
    }
    console.log(this.form.value);
  }

  private buildForm() {
    this.form = this.formBuilder.group({
     PatientId: ['', [Validators.required]],
     appointmentType: ['', [Validators.required]],
     Date: ['', [Validators.required]]
    });
  }

  FecthAppointmentsID() {
    this.appointmentsService.getAllAppointments()
    .subscribe(appointments => {
      const ID = appointments.length;
      this.ID = ID + 1;
    });
  }

  FecthPatients() {
    this.patientsService.getAllPatients()
    .subscribe(patients => {
      this.patientsNames = this.findPatientsName(patients);
    });
  }

  findPatientsName(patients) {
    patients.forEach(patient => {
      this.patientsNames.push(patient.Name);
      this.patientsIds.push(patient.PatientId);
    });
    return this.patientsNames;
  }
}
