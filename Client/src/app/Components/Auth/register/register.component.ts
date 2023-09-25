import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/Shared/user.service';
import jwt_decode from "jwt-decode";
import { AuthService } from 'src/app/Shared/Auth/auth.service';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  constructor(private fb: FormBuilder, public service: UserService, public auth: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.register();
  }

  registerForm: FormGroup;

  register() {
    this.registerForm = this.fb.group({
      Username: ['', Validators.required],
      Email: ['', Validators.required],
      Phone: ['', Validators.required],
      Password: ['', Validators.required],
    })
  }

  onSubmit() {
    this.service.postRegisterUser(this.registerForm.value).subscribe(
      res => {
        console.log(res);
        Swal.fire({
          icon: 'success',
          title: 'Welcome to community!',
          text: 'You are Registered successfully!',
          position: 'top',
          footer: 'Now go to&nbsp;<a href="/login" class="text-green-600 font-bold">Login</a>&nbsp;page!'
        })
      },
      err => {
        console.log(err);
      }
    )
  }
}
