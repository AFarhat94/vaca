import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AccountService } from '../account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  form = new FormGroup(
    {
      email: new FormControl(),
      password: new FormControl()
    }
  );

  constructor(private accountService: AccountService, private router: Router) { }

  onSubmit()
  {
    this.accountService.logIn(this.form.value)
        .subscribe({
          next:  auth => this.router.navigateByUrl("/"),
          error: error => console.log(error)
      })
  }
}
