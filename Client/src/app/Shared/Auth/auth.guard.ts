import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) { };

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    // console.log(state.url);
    let isLoggedIn = this.authService.isAuthenticated();
    if (isLoggedIn) {
      if(state.url == '/login' || state.url == '/register') this.router.navigate(['/']);
      else return true;
    } else {
      if(state.url == '/login' || state.url == '/register') return true;
      else this.router.navigate(['/login']);
    }
  }


}
