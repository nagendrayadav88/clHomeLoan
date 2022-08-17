import { Injectable } from '@angular/core';
import {
  Router,
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';

import { AuthService } from '../service/auth.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (this.authService.currentUserValue) {
      this.authService.currentUserValue.roles.forEach((role) => {
        const userRole = role;
        if (route.data.role && route.data.role.indexOf(userRole) === -1) {
          this.router.navigate(['/authentication/signin']);
          return false;
        }
        return true;
      });
      return true;
    }

    this.router.navigate(['/authentication/signin']);
    return false;
  }
}
