import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';
import { User } from './shared/models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  currentUserEmail?: string;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    const token = localStorage.getItem('token');
    this.accountService.loadCurrentUser(token).subscribe({
      next: user => this.currentUserEmail = user?.email
    });
  }
}
