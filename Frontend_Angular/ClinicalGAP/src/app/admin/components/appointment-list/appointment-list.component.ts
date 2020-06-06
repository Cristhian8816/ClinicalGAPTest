import { Component, OnInit } from '@angular/core';

import { AppointmentsService } from '../../../core/services/appointments/appointments.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './appointment-list.component.html',
  styleUrls: ['./appointment-list.component.scss']
})
export class AppointmentListComponent implements OnInit {

  appointments = [];
  displayedColumns: string[] = ['AppointmentId', 'PatientId', 'AppointmentType', 'Date'];

  constructor(
    private appointmentServices: AppointmentsService
  ) { }

  ngOnInit(): void {
    this.fetchAppointments();
  }

  fetchAppointments() {
    this.appointmentServices.getAllAppointments()
    .subscribe(appointments => {
      this.appointments = appointments;
    });
  }
  deleteAppointment(id: string) {
    this.appointmentServices.deleteAppointment(id)
    .subscribe(rta => {
      this.fetchAppointments();
    });
  }

}
