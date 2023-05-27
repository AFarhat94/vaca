import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function PasswordValidator() : ValidatorFn
{
    return (control: AbstractControl): ValidationErrors | null => 
    {
        const firstPasswordInput = control.parent?.get("password");
        const seconPasswordInput = control;

        if (firstPasswordInput?.value != seconPasswordInput.value)
        {
            return  {message : {value: "Password does not match"} } ;
        }

        return null;
    }
}