import { Component, OnInit } from '@angular/core';
import { EmailValidator, FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../account.service';
import { PasswordValidator } from './passwordValidator';
import { ErrorResponse } from 'src/app/shared/models/errorResponse';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  form = new FormGroup({
    email: new FormControl("", [Validators.email]),
    name:  new FormControl("", [Validators.min(2)]),
    givenName: new FormControl("", [Validators.min(3)]),
    password: new FormControl("", [Validators.min(3)]),
    passwordCheck: new FormControl("", PasswordValidator())
}); 

errors: ErrorResponse[] | null = []
validated: boolean = false;

constructor(private accountService: AccountService) { }

  onSubmit()
  {
    if (this.form.valid)
    {
      this.accountService.save(this.form.value).subscribe({
        next: () => this.validated=true,
        error: error => {
          this.errors = error.error;
        }
      });
    }
  }
}
