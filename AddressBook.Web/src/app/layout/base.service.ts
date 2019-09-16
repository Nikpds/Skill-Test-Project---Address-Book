import { Injectable } from '@angular/core';
import { throwError as observableThrowError, BehaviorSubject, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { User, Address } from '../model';

@Injectable({
  providedIn: 'root'
})
export class BaseService {
  private baseUri = environment.api;

  private contractsSubject$ = new BehaviorSubject<Array<User>>([]);
  contacts$ = this.contractsSubject$.asObservable();
  get contacts(): Array<User> { return this.contractsSubject$.getValue(); }

  set contacts(value: Array<User>) { this.contractsSubject$.next(value); }

  constructor(private http: HttpClient) { }

  addAddressToUser(add: Address) {
    const i = this.contacts.findIndex(x => x.id === add.userId);
    if (i > -1) {
      this.contacts[i].addresses.unshift(add);
      this.contacts = this.contacts;
    }
  }
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
