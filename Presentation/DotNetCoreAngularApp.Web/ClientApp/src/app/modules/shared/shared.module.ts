import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppHttpInterceptor } from 'src/app/extensions/interceptors/http.interceptor';

@NgModule({
  imports: [],
  declarations: [],
  exports: [],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AppHttpInterceptor,
      multi: true,
    },
  ],
})
export class SharedModule {}
