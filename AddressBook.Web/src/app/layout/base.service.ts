import { Injectable } from '@angular/core';
import { throwError as observableThrowError, BehaviorSubject, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BaseService {
  private baseUri = environment.api;
  constructor(private http: HttpClient) { }

  insert<T>(entity: any, url: string): Observable<T> {
    return this.http.post<T>(`${this.baseUri}${url}`, entity)
      .pipe(catchError(this.errorHandler));
  }

  update<T>(entity: any, id: string, url: string): Observable<T> {
    return this.http.put<T>(`${this.baseUri}${url}/${id}`, entity)
      .pipe(catchError(this.errorHandler));
  }

  delete(id: string, url: string): Observable<boolean> {
    return this.http.delete<boolean>(`${this.baseUri}${url}/${id}`)
      .pipe(catchError(this.errorHandler));
  }

  getAll<T>(url: string): Observable<Array<T>> {
    return this.http.get<Array<T>>(`${this.baseUri}${url}`)
      .pipe(catchError(this.errorHandler));
  }

  errorHandler(error: HttpErrorResponse) {
    return observableThrowError(error || 'Server Error');
  }
}
