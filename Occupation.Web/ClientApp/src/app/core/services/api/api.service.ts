import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";

import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";

import { environment } from "../../../../environments/environment";

@Injectable()
export class ApiService {
  constructor(private http: HttpClient) {}
  httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json" }),
    Accept: "application/json",
  };

  public get = (
    path: string,
    params: HttpParams = new HttpParams()
  ): Observable<any> =>
    this.http
      .get(`${environment.api}${path}`, { params })
      .pipe(catchError((e) => throwError(e)));

  public getFile = (path: string): Observable<any> =>
    this.http
      .get(`${environment.api}${path}`, { responseType: "blob" })
      .pipe(catchError((e) => throwError(e)));

  public put = (path: string, body: Object = {}): Observable<any> =>
    this.http
      .put(`${environment.api}${path}`, JSON.stringify(body))
      .pipe(catchError((e) => throwError(e)));

  public post = (path: string, body: Object = {}): Observable<any> =>
    this.http
      .post(`${environment.api}${path}`, JSON.stringify(body), this.httpOptions)
      .pipe(catchError((e) => throwError(e)));
}
