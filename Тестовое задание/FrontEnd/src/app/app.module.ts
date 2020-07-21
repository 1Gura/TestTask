import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {NgForm} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormComponent } from './form/form.component';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { TestComponent } from './test/test.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {TextMaskModule} from 'angular2-text-mask';
import {HttpClientModule} from '@angular/common/http';
import { ResultComponent } from './result/result.component';
import {BotDetectCaptchaModule} from 'angular-captcha';
import {NgxCaptchaModule} from 'ngx-captcha';

@NgModule({
  declarations: [
    AppComponent,
    FormComponent,
    TestComponent,
    ResultComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    TextMaskModule,
    HttpClientModule,
    BotDetectCaptchaModule,
    NgxCaptchaModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
