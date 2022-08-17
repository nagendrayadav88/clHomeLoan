import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user';
import { environment } from 'src/environments/environment';
import { Guid } from "guid-typescript";

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<User>(
      JSON.parse(localStorage.getItem('currentUser'))
    );
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  login(username: string, password: string) {
    return this.http
      .post<any>(`${environment.apiUrl}/api/Authenticate/login`, {
        username,
        password,
      })
      .pipe(
        map((user) => {
          // store user details and jwt token in local storage to keep user logged in between page refreshes

          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUserSubject.next(user);
          return user;
        })
      );
  }
  AllLoanDetails() {
    return this.http
      .get<any>(`${environment.loanapiUrl}/api/Mortgage/getall`)
      .pipe(
        map((loandetail) => {
          return loandetail;
        })
      );
  }
  GetLoanDetailsById(id:Guid) {
    return this.http
      .get<any>(`${environment.loanapiUrl}/api/Mortgage/getbyid?id=`+ id)
      .pipe(
        map((loandetail) => {
          return loandetail;
        })
      );
  }
  AddLoanAccount(formdata) {
    const headers = new HttpHeaders({'Content-Type':'application/json; charset=utf-8'});
    return this.http
      .post<any>(`${environment.loanapiUrl}/api/Mortgage/addloan`,formdata,{headers:headers})
      .pipe(
        map((data) => {
          return data;
        })
      );
  }
  updateLoanDetail(formdata, id, pid) {
    debugger
    const headers = new HttpHeaders({'Content-Type':'application/json; charset=utf-8'});
    formdata.id=id;
    return this.http
      .put<any>(`${environment.loanapiUrl}/api/Mortgage/updateloan`,formdata,{headers:headers})
      .pipe(
        map((data) => {
          return data;
        })
      );
  }
  deleteDetail(id) {
    debugger
    return this.http
      .delete<any>(`${environment.loanapiUrl}/api/Mortgage/deleteloan?id=` + id)
      .pipe(
        map((data) => {
          return data;
        })
      );
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
    return of({ success: false });
  }
}
