import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-captcha',
  templateUrl: './captcha.component.html',
  styleUrls: ['./captcha.component.scss']
})
export class CaptchaComponent implements OnInit {
  private captchaComponent: any;

  constructor() { }

  ngOnInit(): void {
    this.captchaComponent.captchaEndpoint =
      'https://localhost:44319/api/contacts/simple-captcha-endpoint.ashx';
  }
}
