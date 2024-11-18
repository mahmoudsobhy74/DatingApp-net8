import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AccountService } from '../_services/account.service';

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {
  const accountSrvice = inject(AccountService);

  if(accountSrvice.currentUser())
  {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${accountSrvice.currentUser()?.token}`
      }
    })

  }
  return next(req);
};
