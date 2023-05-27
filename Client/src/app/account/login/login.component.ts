import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
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
      email: new FormControl("", Validators.email),
      password: new FormControl()
    }
  );

  isNotAuthorise: boolean = false;

  constructor(private accountService: AccountService, private router: Router) { }

  onSubmit()
  {
    if (!this.form.invalid)
    {
      this.accountService.logIn(this.form.value)
      .subscribe({
        next:  auth => this.router.navigateByUrl("/"),
        error: error => {
          this.isNotAuthorise = true;
        }
      });
    }
  }
}
