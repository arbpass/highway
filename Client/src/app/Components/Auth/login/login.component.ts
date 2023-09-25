import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Shared/Auth/auth.service';
import { UserService } from 'src/app/Shared/user.service';
import jwt_decode from "jwt-decode";
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(private fb: FormBuilder, public service: UserService, public auth: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.login();
  }


  loginForm: FormGroup;

  login() {
    this.loginForm = this.fb.group({
      Username: [''],
      Password: [''],
    })
  }

  onSubmit() {
    this.service.postLoginUser(this.loginForm.value).subscribe(
      res => {
        // console.log(res);
        localStorage.setItem('_token', JSON.stringify(res));
        var decodedHeader = jwt_decode(res['token']);
        if (decodedHeader['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] == "User") {
          this.router.navigateByUrl('/');
          Swal.fire({
            icon: 'success',
            title: 'Hey there!',
            text: 'You are Logged In successfully!',
            position: 'top'
          })
        }

      },
      err => {
        console.log(err);
      }
    )
  }
}
