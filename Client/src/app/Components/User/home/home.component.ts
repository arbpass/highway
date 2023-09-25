import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { City } from 'src/app/Shared/Models/city.model';
import { UserService } from 'src/app/Shared/user.service';
import { formatDate } from '@angular/common';
import { Options } from 'src/app/Shared/Models/options.model';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  constructor(public service: UserService, private router: Router, private fb: FormBuilder) { }

  fromCity = ""; toCity = ""; date = formatDate(new Date(), 'yyyy-MM-dd', 'en');
  currentDate = formatDate(new Date(), 'yyyy-MM-dd', 'en');
  allCities: any;
  results: any;
  username: any;

  ngOnInit(): void {
    this.options();
    try {
      this.service.getCities().subscribe(
        res => {
          this.allCities = res['cities'] as City[];
          this.username = res['userName'];
          console.log(res);
        },
        err => {
          // console.log(err);
          localStorage.clear();
          this.router.navigateByUrl('/login');
          Swal.fire({
            icon: 'error',
            title: 'Gotch you!',
            text: 'You are logged out because your session is expired!',
            position: 'top'
          })
        }
      );
    } catch (error) {
      // console.log(error);
    }
  }

  optionsForm: FormGroup;

  options() {
    this.optionsForm = this.fb.group({
      City1: [''],
      City2: [''],
      Date: [''],
    })
  }

  onSubmit() {
    this.service.postOptions(this.optionsForm.value).subscribe(
      res => {
        this.results = res as Options[];
        console.log(this.results);
      },
      err => {
        console.log(err);
      }
    )
  }

  exchangeCity() {
    var temp = this.fromCity;
    this.fromCity = this.toCity;
    this.toCity = temp;
  }

  scroll(el: HTMLElement) {
    el.scrollIntoView();
  }
}
