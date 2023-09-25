import { Injectable } from '@angular/core';
import jwt_decode from "jwt-decode";


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor() { }
  isLoggedIn: boolean = false;

  tokenCheck() {
    try {
      const token = JSON.parse(localStorage.getItem('_token'));
      const decodedHeader = jwt_decode(token['token']);
      this.isLoggedIn = decodedHeader['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] == "User" ? true : false;
    } catch (error) {
      localStorage.clear();
      this.isLoggedIn= false;
    }
  }



  isAuthenticated() {
    this.tokenCheck();
    return this.isLoggedIn;
  }
}
