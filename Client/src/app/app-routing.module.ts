import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Components/Auth/login/login.component';
import { RegisterComponent } from './Components/Auth/register/register.component';
import { HomeComponent } from './Components/User/home/home.component';
import { AboutComponent } from './Components/User/about/about.component';
import { AuthGuard } from './Shared/Auth/auth.guard';

const routes: Routes = [
  { path: 'login', component: LoginComponent, canActivate:[AuthGuard]},
  { path: 'register', component: RegisterComponent, canActivate:[AuthGuard]},
  { path: '', component: HomeComponent, canActivate:[AuthGuard]},
  { path: 'about', component: AboutComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
