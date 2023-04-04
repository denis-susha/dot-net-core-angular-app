import { Injectable, Inject } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AppHttpInterceptor implements HttpInterceptor {
  apiUrl!: string;

  constructor(@Inject('BASE_URL') public baseUrl: string) {
    this.apiUrl = baseUrl;
  }

  handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      console.error(`Backend returned code ${error.status}, body was: `, error.error);
    }

    return throwError(() => new Error('Something bad happened. Please try again later.'));
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const request = req.clone({ url: this.baseUrl + req.url });

    return next.handle(request).pipe(catchError(this.handleError));
  }
}
