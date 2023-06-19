import { Component } from '@angular/core';
import { AuthService } from './Shared/Auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'highway';
  constructor(public auth: AuthService, private router: Router) { }
  logoutShow= false;

  toggleLogout() {
    this.logoutShow = this.logoutShow == true ? false : true;
  }

  onLogout() {
    localStorage.clear();
    this.logoutShow= false;
    this.router.navigateByUrl('/login');
  }
}
