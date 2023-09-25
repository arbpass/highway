import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { City } from 'src/app/Shared/Models/city.model';
import { Seats } from 'src/app/Shared/Models/seats.model';
import { UserService } from 'src/app/Shared/user.service';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit{
  constructor(public route: ActivatedRoute, public service: UserService) { }
  seatsSelected: string[] = [];
  seatsInfo: Seats[] = [];
  fare = this.route.snapshot.params['fare'];

  ngOnInit(): void {
    this.service.getSeatsInfo(this.route.snapshot.params['bus'], this.route.snapshot.params['company'], this.route.snapshot.params['date']).subscribe(
      res=> {
        console.log(res);
        if(res['seatsInfo'][0]) this.seatsInfo = res['seatsInfo'][0] as Seats[];
      }
    )
  }

  async addSeat(seatNo: string)
  {
    let index = await this.seatsSelected.findIndex(x => x == seatNo);

    if(index === -1) {
      this.seatsSelected.push(seatNo);
      document.getElementById(seatNo).classList.add('bg-lime-600');
    }
    else {
      this.seatsSelected.splice(index, 1);
      document.getElementById(seatNo).classList.remove('bg-lime-600');
    }
  }

  bookFunction()
  {
    let data= {
      "busName": this.route.snapshot.params['bus'],
      "busCompany": this.route.snapshot.params['company'],
      "seatNo": JSON.stringify(this.seatsSelected),
      "date": this.route.snapshot.paramMap.get('date')
    };

    this.service.postBook(data).subscribe(
      res=> {
        console.log(res);
        this.ngOnInit();
        this.bookTrip();
        this.seatsSelected = [];
      },
      err=> {
        console.log(err);
      }
    )
  }


  bookTrip()
  {
    let data= {
      BusName: this.route.snapshot.params['bus'],
      BusCompany: this.route.snapshot.params['company'],
      Seats: JSON.stringify(this.seatsSelected),
      From: this.route.snapshot.paramMap.get('fromCity'),
      To: this.route.snapshot.paramMap.get('toCity'),
      Date: this.route.snapshot.paramMap.get('date'),
      Price: this.fare * this.seatsSelected.length,
      UserId: "",
      Username: ""
    };

    this.service.postTrip(data).subscribe(
      res=> {
        console.log(res);
      },
      err=> {
        console.log(err);
      }
    )
  }

}
