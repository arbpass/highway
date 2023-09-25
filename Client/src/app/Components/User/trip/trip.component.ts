import { Component, OnInit } from '@angular/core';
import { Trips } from 'src/app/Shared/Models/trips.model';
import { UserService } from 'src/app/Shared/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-trip',
  templateUrl: './trip.component.html',
  styleUrls: ['./trip.component.css']
})
export class TripComponent implements OnInit {
  constructor(public service: UserService) { }
  trips: Trips[] = [];

  ngOnInit(): void {
    this.service.getTrips().subscribe(
      res => {
        this.trips = res['trips'] as Trips[];
        console.log(this.trips);
      },
      err => {
        console.log(err);
      }
    )
  }


  showSeats(data: string) {
    return JSON.parse(data);
  }

  deleteTrip(tripId: any) {
    Swal.fire({
      icon: 'warning',
      title: 'Hey there!',
      text: 'Are you sure to delete your trip!',
      position: 'center',
      showCancelButton: true
    }).then((result) => {
      if (result.value) {
        this.service.deleteTrip(tripId).subscribe(
          res => {
            console.log(res);
            this.ngOnInit();
          },
          err=> {
            console.log(err);
          }
        )
      }
    });
  }
}
