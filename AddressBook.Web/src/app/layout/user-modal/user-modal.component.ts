import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User } from 'src/app/model';
import { BaseService } from '../base.service';
import { NotifyService } from 'src/app/shared/notify.service';

@Component({
  selector: 'app-user-modal',
  templateUrl: './user-modal.component.html',
  styleUrls: ['./user-modal.component.sass']
})
export class UserModalComponent implements OnInit {
  user: User;
  userForm: FormGroup;
  formErrors = {
    firstname: '',
    lastname: '',
    email: ''
  };

  validationMessages = {
    firstname: {
      required: 'Firstname is required',
      minlength: 'Your Firstname must be at least 3 characters'
    },
    lastname: {
      required: 'Lastname is required',
      minlength: 'Your Lastname must be at least 3 characters'
    },
    email: {
      required: 'Email is required',
    }
  };

  constructor(
    private userService: BaseService,
    private notify: NotifyService,
    private fb: FormBuilder
  ) { }

  ngOnInit() {
  }

  private createForm() {
    this.userForm = this.fb.group({
      firstname: [this.user.firstname, Validators.compose([Validators.required, Validators.minLength(3)])],
      lastname: [this.user.lastname, Validators.compose([Validators.required, Validators.minLength(3)])],
      email: [this.user.email, Validators.required]
    });
    this.userForm.valueChanges.subscribe(value => this.onValueChanged(value));
    this.onValueChanged();
  }

  onValueChanged(value?: any) {
    if (!this.userForm) { return; }
    const form = this.userForm;
    for (const field in this.formErrors) {
      if (field) {
        this.formErrors[field] = '';
        const control = form.get(field);
        if (value === 'submit') {
          control.markAsDirty();
        }
        if (control && control.dirty && !control.valid) {
          const messages = this.validationMessages[field];
          for (const key in control.errors) {
            if (key) {
              this.formErrors[field] += messages[key] + ' ';
            }
          }
        }
      }
    }
  }

  onSubmit() {
    const model = this.userForm.value;
    this.user.firstname = model.firstname;
    this.user.lastname = model.lastname;
    this.user.email = model.email;
    this.user.id ? this.update() : this.insert();
  }

  insert() {
    this.userService.insert<User>(this.user, 'user').subscribe(res => {
      this.user = res;
      this.notify.success('Your insert was successfull');
    }, error => {
      this.notify.danger(error);
    });
  }

  update() {
    this.userService.update<User>(this.user, 'user', this.user.id).subscribe(res => {
      this.user = res;
      this.notify.success('Your update was successfull');
    }, error => {
      this.notify.danger(error);
    });
  }


  cancel() {
    this.user = null;
  }

  open() {
    this.user = new User();
    this.createForm();
  }

}
