import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-navbar',
  imports: [RouterLink, CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent {
  constructor(private router: Router){}

  get isLoginPage() : boolean {
    const currentRoute = this.router.url;
    return (
      currentRoute === '/login-options' ||
      currentRoute === '/login-interviewer' ||
      currentRoute === '/login-candidate'
    ); 
  }
}
