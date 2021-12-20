import { Component, OnInit } from '@angular/core';
import { LoginModel } from 'src/app/services/_login/login_model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  users: LoginModel[];
  user: LoginModel;

  constructor() {
    this.users = JSON.parse('' + localStorage.getItem('user'));
    this.user = this.users[0];
  }

  ngOnInit(): void {}
}
