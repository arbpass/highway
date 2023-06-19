import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { City } from 'src/app/Shared/Models/city.model';
import { UserService } from 'src/app/Shared/user.service';
import { formatDate } from '@angular/common';
import { Options } from 'src/app/Shared/Models/options.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  constructor(public service: UserService, private router: Router, private fb: FormBuilder) { }

  fromCity = ""; toCity = ""; date = formatDate(new Date(), 'yyyy-MM-dd', 'en');
  allCities: any;
  results: any;

  ngOnInit(): void {
    this.options();
    try {
      this.service.getCities().subscribe(
        res => {
          this.allCities = res['cities'] as City[];
          console.log(this.allCities);
        },
        err => {
          // console.log(err);
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
