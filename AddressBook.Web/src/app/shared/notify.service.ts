import { Injectable } from '@angular/core';

import { SnotifyService } from 'ng-snotify';
@Injectable({
  providedIn: 'root'
})
export class NotifyService {
  constructor(private srv: SnotifyService) {
    this.srv.config.toast.titleMaxLength = 20;
    this.srv.config.toast.timeout = 4000;
  }

  success(message: string = 'The action was successful!', title: string = 'Success') {
    this.srv.success(message, title);
  }

  warning(message, title: string = 'Warning') {
    this.srv.warning(message, title);
  }

  danger(message: string = 'Action was not succussfull.', delay = 4, title: string = 'Error') {
    this.srv.error(message, title);
  }

  info(message, title: string = 'Info') {
    this.srv.info(message, title);
  }


  confirmation(message: string, fuc: any, title: string = 'Confirmation', yes = 'Yes', no = 'No') {
    this.srv.confirm(message, title, {
      position: 'centerTop',
      timeout: 7000,
      showProgressBar: true,
      closeOnClick: true,
      pauseOnHover: true,
      html: `
      <div class="has-text-danger is-size-4">` + title + `</div>
      <div>` + message + `</div>
      `,
      buttons: [
        { text: yes, action: () => { fuc(), this.srv.clear(); }, bold: false },
        { text: no, action: () => this.srv.clear() }
      ]
    });
  }
}
