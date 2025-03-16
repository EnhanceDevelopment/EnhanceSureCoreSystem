import { Route } from '@angular/router';
import { LandingComponent } from './features/landing/landing.component';
import { LoginOptionsComponent } from './features/auth/login-options/login-options.component';

export const routes: Route[] = [
  { path: '', component: LandingComponent },
  {
    path: 'login-options',
    component: LoginOptionsComponent 
  },
  { 
    path: 'login-interviewer', 
    loadComponent: () => 
      import('./features/auth/login-interviewer/login-interviewer.component')
        .then(x => x.LoginInterviewerComponent)
  },
  { 
    path: 'login-candidate', 
    loadComponent: () => 
      import('./features/auth/login-candidate/login-candidate.component')
        .then(x => x.LoginCandidateComponent)
  },
  { path: '**', redirectTo: '' },
];
