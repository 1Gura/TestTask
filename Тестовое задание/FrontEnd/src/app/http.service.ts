import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Topic} from './form/form.component';
import {User} from './user'


@Injectable()
// @ts-ignore
export class HttpService{

  constructor(private http: HttpClient){ }

  async Gettopics(arr) {

    const response = await fetch("localhost:44319/api/topics", {
      method: "GET",
      headers: {"Accept": "application/json"}
    });
    // если запрос прошел нормально
    if (response.ok === true) {
      // получаем данные
      const contacts = await response.json();
      arr = JSON.parse(contacts);
      return arr;
    }

  }


   getData(){
     return this.http.get<Topic[]>('https://localhost:44319/api/topics');
  }

  postData(user: User){
    const contact = { name: user.name, email: user.email, phone: user.phone};
    console.log(contact);
    return this.http.post('https://localhost:44319/api/contacts', contact);

  }

  postMessage(user: User, receivedMessage: User) {
    const message = {textMessage: user.textMessage, topicId: +user.select ,
    contactId: receivedMessage.id};
    console.log(message);
    return  this.http.post('https://localhost:44319/api/messages', message);
  }

  outData() {
     return this.http.get('https://localhost:44319/api/topics')
  }
}
