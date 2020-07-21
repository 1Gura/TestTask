import {Component, forwardRef, NgModule, OnInit, ViewEncapsulation} from '@angular/core';
import {FormBuilder, NgForm} from '@angular/forms';
import {User} from '../user';

import {
  FormControl,
  Validators,
  FormsModule,
  NgModel,
  ReactiveFormsModule,
  FormGroup,
  ControlValueAccessor,
  NG_VALUE_ACCESSOR,


} from '@angular/forms';
import {logger} from 'codelyzer/util/logger';
import {HttpClient} from '@angular/common/http';
import {HttpService} from '../http.service';
import {NgxCaptchaModule} from 'ngx-captcha';

export class Topic{
  id: number;
  textTopic: string;
}






@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers: [

  ]
})




export class FormComponent implements  OnInit {
  protected aFormGroup: FormGroup;
  private grecaptcha: any;

  constructor(private httpService: HttpService, private formBuilder: FormBuilder){}

  ngOnInit(){
    this.aFormGroup = this.formBuilder.group({
      recaptcha: ['', Validators.required]
    })
    this.httpService.getData().subscribe(data => this.topics = data);
  }






  // RC2KEY = '6Lc-MbMZAAAAAJi6qd9N36Zhy4FHT37h-kmi8fCK';
  // doSubmit = false;
  //
  // private reCaptchaExpired: any;
  //
  //
  // reCaptchaVerify(response) {
  //   if (response === this.grecaptcha.getResponse ()) {
  //     this.doSubmit = true;
  //   }
  // }
  //
  // reCaptchaCallback () {
  //   this.grecaptcha.render('id', {
  //     'sitekey': this.RC2KEY,
  //     'callback': this.reCaptchaVerify,
  //     'expired-callback': this.reCaptchaExpired
  //   });
  // }



  topics: Topic[]=[];

  user: User = new User();

  receivedUser: User;
  temp:User;

  done: boolean = false;





  hidden() {
    const a = document.querySelector('.form')
    const b = document.querySelector('.result-table')
    a.classList.add('hidden');
    b.classList.remove('hidden')
  }


  submit(user: User){

    let a = document.querySelector('#btn')
    a.addEventListener('click', function () {

    })
      // @ts-ignore
    if (!grecaptcha.getResponse()) {
      alert('Вы не заполнили поле "Я не робот"!');
      return false; // возвращаем false и предотвращаем отправку формы
    }
    // if (!this.grecaptcha.getResponse()) {
    //   alert('Вы не заполнили поле "Я не робот"!');
    //   return false; // возвращаем false и предотвращаем отправку формы
    // }
    // else {
    this.httpService.postData(user)
      .subscribe(
        (data: User) => {
          this.receivedUser = data;
          this.temp = this.receivedUser

          const name = document.querySelector('#name');
          name.textContent = this.receivedUser.name;

          this.httpService.postMessage(user, this.receivedUser)
            .subscribe(
              (data: User) => {
                this.receivedUser=data;
                console.log('TEMP', this.temp);
                console.log("DataMessage", this.receivedUser);
                this.done=true;
                return this.receivedUser;
              },
              error => console.log(error)
            );
        },
        error => console.log(error));
    this.hidden();

  }





  //Добавление тем


  // @ts-ignore

  compareObjects(o1: any, o2: any): boolean {
    return o1.id === o2.id && o1.text === o2.text;
  }

  phoneControl: FormControl;

  PHONE_PATTERN = /\+7\(\d{3}\)\-\d{3}\-\d{4}/;
  CHECK = [/\D/];

  PHONE_MASK = ['+','7','(', /[1-9]/, /\d/, /\d/, ')', '-', /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/];

}








