#ClinicalGAP

The Backend of this project its an APi that gives the information of patients and appointments of a ClinicalGAP, in the file UsersContext.cs
you can find the model to the DATABASE using Entity framework as a ORM, there you can configurate two conecxions strings one for your
local machine and the other for SmarterASP server when de database is hosted. 
The backend has cors enable where I filter to give the data just for the Especific URL.

The Frontend is developed with Angular.js and here we can find a main page with information about ClinicalGAP and an admin module, where 
you have to login to get in this module... for this you have two options:
1) login with the next credentials: user: cristhian.julian@hotmail.com password: 123456
2) put manually in the url: http://localhost:4200/register/login and here you can register your email and password, after that you can go to 
login with this credentials.
The FE has the autentication service with google firebase.

In the admin module, you have 3 diferents screens:
1)'Created appointment': this screen has a form where you can created an aapointment for a especific patient and put de type of appointment
and date.... one particular patient just can have one appointment for day. When you created the appointment the system gonna redirect you 
to  'appointments screen'
2) 'appointments screen': here you can find all aapointments for all patients, and has a button to cancel de appointment but this only 
occurs if de appointment' date is longer than one day from the moment that you are watching this screen.
3) 'patients screen': here you can find the information of al patients in the clinical GAP.

finally you have the button 'logout' to gotout of the admin module.
---------------------------------------------------------------------------------------------------------------------------------------
