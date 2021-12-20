import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { LoginModel } from 'src/app/services/_login/login_model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  @Output() toggleSidebarForMe: EventEmitter<any> = new EventEmitter();

  users: LoginModel[];
  user: LoginModel;

  constructor(private router: Router) {
    this.users = JSON.parse('' + localStorage.getItem('user'));
    this.user = this.users[0];
  }

  ngOnInit(): void {}

  toggleSidebar() {
    this.toggleSidebarForMe.emit();
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/']);
  }
}
