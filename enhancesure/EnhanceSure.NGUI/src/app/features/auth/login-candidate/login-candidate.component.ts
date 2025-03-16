import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';

@Component({
  standalone : true,
  selector: 'app-login-candidate',
  imports: [ReactiveFormsModule, CommonModule, RouterLink],
  templateUrl: './login-candidate.component.html',
  styleUrl: './login-candidate.component.scss'
})
export class LoginCandidateComponent {
    loginForm!: FormGroup;
    showPassword = false;

    constructor(private fb: FormBuilder)
    {
      this.loginForm = this.fb.group({
        userName: ['', Validators.required],
        password: ['', Validators.required]
      });
    }

    togglePasswordVisibility(): void {
      this.showPassword = !this.showPassword;
    }

    onLogin(): void {}
}
