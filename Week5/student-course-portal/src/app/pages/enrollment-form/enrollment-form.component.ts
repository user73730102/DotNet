import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-enrollment-form',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './enrollment-form.component.html',
  styleUrl: './enrollment-form.component.css'
})
export class EnrollmentFormComponent {
  submitted = false;

  onSubmit(form: NgForm) {
    console.log(form.value);
    console.log('Is valid:', form.valid);
    
    if (form.valid) {
      this.submitted = true;
    }
  }

  resetForm(form: NgForm) {
    form.resetForm();
    this.submitted = false;
  }
}
