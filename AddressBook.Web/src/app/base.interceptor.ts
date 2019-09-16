import { Injectable, Injector } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, finalize, map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class BaseInterceptor implements HttpInterceptor {
  constructor() { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      map(event => {
        return event;
      }),
      catchError(error => {
        const err = (typeof error.error) === 'string' ? error.error :
          'Something went wrong while trying to communicate with the server.';
        return throwError(err);
      }),
      finalize(() => {
      })
    );
  }
}

export let BaseInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: BaseInterceptor,
  multi: true
};

