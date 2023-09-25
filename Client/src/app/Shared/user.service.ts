import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from './Models/user.model';
import { City } from './Models/city.model';
import { Options } from './Models/options.model';
import { Book } from './Models/book.model';
import { Seats } from './Models/seats.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private router: Router) { }
  readonly baseUrl = 'https://localhost:5000/api/';


  //Methods
  //Auth
  postRegisterUser(data: User): Observable<User> {
    return this.http.post<User>(this.baseUrl + "Auth/register", data);
  }

  postLoginUser(data: User): Observable<User> {
    return this.http.post<User>(this.baseUrl + "Auth/login", data);
  }

  //Get cities info
  getCities(): Observable<City[]> {
    let ls = localStorage.getItem('_token');
    let token = JSON.parse(ls).token;

    let header = new HttpHeaders({
      'Authorization': 'Bearer ' + token,
    });

    return this.http.get<City[]>(this.baseUrl + "Home", { headers: header });
  }

  //Options of buses
  postOptions(data: Options): Observable<Options[]> {
    let ls = localStorage.getItem('_token');
    let token = JSON.parse(ls).token;

    let header = new HttpHeaders({
      'Authorization': 'Bearer ' + token,
    });

    return this.http.post<Options[]>(this.baseUrl + "Home/options", data, { headers: header });
  }

  //Gives distance b/w two cities
  getDistance(city1, city2): Observable<number> {
    let ls = localStorage.getItem('_token');
    let token = JSON.parse(ls).token;

    let header = new HttpHeaders({
      'Authorization': 'Bearer ' + token,
    });

    return this.http.get<number>(this.baseUrl + `Home/distance/${city1}/${city2}`, { headers: header });
  }

  //Gives info about seats
  getSeatsInfo(busName, busCompany, date): Observable<Seats[]> {
    let ls = localStorage.getItem('_token');
    let token = JSON.parse(ls).token;

    let header = new HttpHeaders({
      'Authorization': 'Bearer ' + token,
    });

    return this.http.get<Seats[]>(this.baseUrl + `Book/${busName}/${busCompany}/${date}`, { headers: header });
  }

  //Booking of seats
  postBook(data: any): Observable<Book> {
    let ls = localStorage.getItem('_token');
    let token = JSON.parse(ls).token;

    let header = new HttpHeaders({
      'Authorization': 'Bearer ' + token,
    });

    return this.http.post<Book>(this.baseUrl + "Book/Booking", data, { headers: header });
  }

  //Book trips
  postTrip(data: any): Observable<Book> {
    let ls = localStorage.getItem('_token');
    let token = JSON.parse(ls).token;

    let header = new HttpHeaders({
      'Authorization': 'Bearer ' + token,
    });

    return this.http.post<Book>(this.baseUrl + "Home/bookTrip", data, { headers: header });
  }

  //Get all trips
  getTrips(): Observable<any> {
    let ls = localStorage.getItem('_token');
    let token = JSON.parse(ls).token;

    let header = new HttpHeaders({
      'Authorization': 'Bearer ' + token,
    });

    return this.http.get<any>(this.baseUrl + 'Home/Trips', { headers: header });
  }

  //Delete trips
  deleteTrip(tripId: any): Observable<any> {
    let ls = localStorage.getItem('_token');
    let token = JSON.parse(ls).token;

    let header = new HttpHeaders({
      'Authorization': 'Bearer ' + token,
    });

    return this.http.post<any>(this.baseUrl + `Book/Cancel?tripId=${tripId}`, tripId,{ headers: header });
  }
}
