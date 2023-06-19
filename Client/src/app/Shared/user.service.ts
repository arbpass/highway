import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from './Models/user.model';
import { City } from './Models/city.model';
import { Options } from './Models/options.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private router: Router) { }
  readonly baseUrl = 'https://localhost:5000/api/';


  //Methods
  postRegisterUser(data: User): Observable<User> {
    return this.http.post<User>(this.baseUrl + "Auth/register", data);
  }

  postLoginUser(data: User): Observable<User> {
    return this.http.post<User>(this.baseUrl + "Auth/login", data);
  }

  getCities(): Observable<City[]> {
    let ls = localStorage.getItem('_token');
    let token = JSON.parse(ls).token;

    let header = new HttpHeaders({
      'Authorization': 'Bearer ' + token,
    });

    return this.http.get<City[]>(this.baseUrl + "Home", { headers: header });
  }

  postOptions(data: Options): Observable<Options[]> {
    let ls = localStorage.getItem('_token');
    let token = JSON.parse(ls).token;

    let header = new HttpHeaders({
      'Authorization': 'Bearer ' + token,
    });

    return this.http.post<Options[]>(this.baseUrl + "Home/options", data, { headers: header });
  }

  getDistance(city1, city2): Observable<number> {
    let ls = localStorage.getItem('_token');
    let token = JSON.parse(ls).token;

    let header = new HttpHeaders({
      'Authorization': 'Bearer ' + token,
    });

    return this.http.get<number>(this.baseUrl + `Home/distance/${city1}/${city2}`, { headers: header });
  }
}
