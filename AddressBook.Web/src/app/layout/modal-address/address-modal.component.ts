import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Address } from 'src/app/model';
import { BaseService } from '../base.service';
import { NotifyService } from 'src/app/shared/notify.service';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-address-modal',
  templateUrl: './address-modal.component.html',
  styleUrls: ['./address-modal.component.sass']
})
export class ModalAddressComponent implements OnInit {
  address: Address;
  addressForm: FormGroup;
  latlongRegEx = /^(\+|-)?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))$/;
  formErrors = {
    address: '',
    longtitue: '',
    latitude: ''
  };

  validationMessages = {
    address: {
      required: 'Address is required'
    },
    latitude: {
      required: 'Latitude is required',
      pattern: 'Latitude is not valid'
    },
    longtitue: {
      required: 'Longtitue is required',
      pattern: 'Longtitue is not valid'
    }
  };
  constructor(
    private service: BaseService,
    private notify: NotifyService,
    private fb: FormBuilder
  ) { }

  ngOnInit() {
  }
  private createForm() {
    this.addressForm = this.fb.group({
      address: [null, Validators.required],
      latitude: [null, Validators.compose([Validators.required, Validators.pattern(this.latlongRegEx)])],
      longtitue: [null, Validators.compose([Validators.required, Validators.pattern(this.latlongRegEx)])]

    });
    this.addressForm.valueChanges.subscribe(value => this.onValueChanged(value));
    this.onValueChanged();
  }

  onValueChanged(value?: any) {
    if (!this.addressForm) { return; }
    const form = this.addressForm;
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
    const model = this.addressForm.value;
    this.address.address = model.address;
    this.address.lat = model.latitude;
    this.address.lon = model.longtitue;

    this.insert();
  }

  private insert() {
    this.service.insert<Address>(this.address, 'addressinfo').subscribe(res => {
      this.address = res;
      this.notify.success('Your insert was successfull');
      this.service.addAddressToUser(res);
      this.cancel();
    }, error => {
      this.notify.danger(error);
    });
  }

  cancel() {
    this.address = null;
  }

  open(userId: string) {
    this.address = new Address();
    this.address.userId = userId;
    this.createForm();
  }

}
