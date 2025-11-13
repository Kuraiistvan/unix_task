import { isFakeMousedownFromScreenReader } from '@angular/cdk/a11y';
import { HttpErrorResponse, HttpInterceptorFn, HttpRequest, HttpResourceFn, HttpResponse } from '@angular/common/http';
import { inject } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);
  
  return next(req).pipe(
    catchError((err: HttpErrorResponse) => {
      switch(err.status){
        case 400:
          if(err.error.errors){
            const modelStatErrors = [];
            for (const key in err.error.errors){
              if(err.error.errors[key]){
                modelStatErrors.push(err.error.errors[key]);
              }
            }
            throw modelStatErrors.flat();
          } else {
            alert(err.error.title || err.error);
          }
        break;
        case 401:
          alert(err.error.title || err.error);
          break;
          case 404:
            router.navigateByUrl('/not-found');
            break;
          case 500:
            const navigationExtras: NavigationExtras = {state:{error: err.error}
            }
            router.navigateByUrl('/server-error', navigationExtras);
            break;
        default: throwError(() => err);
      }

      return throwError(() => err);
    })
  );
};
