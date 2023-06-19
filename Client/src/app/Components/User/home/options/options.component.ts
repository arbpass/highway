import { Component, Input, OnInit } from '@angular/core';
import { UserService } from 'src/app/Shared/user.service';

@Component({
  selector: 'app-options',
  templateUrl: './options.component.html',
  styleUrls: ['./options.component.css']
})
export class OptionsComponent implements OnInit{
  constructor(public service: UserService) { }
  @Input() fromCity = '';
  @Input() toCity = '';
  @Input() date = '';
  @Input() allOptions = '';
  distance: any = 0;

  ngOnInit(): void {
    this.distanceCal();
  }


  distanceCal()
  {
    this.service.getDistance(this.fromCity, this.toCity).subscribe(
      res => {
        console.log(res);
        this.distance = res;
      },
      err => {
        console.log(err);
      }
    )
  }

  returnArrival(route: string)
  {
    const arrival = JSON.parse(route);
    return arrival[this.fromCity].split('-')[0];
  }

  returnDeparture(route: string)
  {
    const arrival = JSON.parse(route);
    return arrival[this.fromCity].split('-')[1];
  }
}
