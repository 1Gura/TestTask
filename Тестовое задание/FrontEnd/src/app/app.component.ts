import { Component } from '@angular/core';
import {HttpService} from './http.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  providers: [HttpService]
})
export class AppComponent {
  title = 'my-app1';

  protected aFormGroup: FormGroup;

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit() {

  }

}
