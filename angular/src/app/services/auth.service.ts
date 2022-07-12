import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private router: Router) { }
  public isLoggedIn:boolean = false;
  checkIfLoggedIn(): boolean
  {
    return this.isLoggedIn;
  }

  navigateToLogin()
  {
    this.router.navigate(['/login']);
  }
}
