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

  success(message: string = 'To αίτημα σας πραγματοποιήθηκε με επιτυχία!', title: string = 'Επιτυχία') {
    this.srv.success(message, title);
  }

  warning(message, title: string = 'Προσοχή') {
    this.srv.warning(message, title);
  }

  danger(message: string = 'To αίτημα απέτυχε.', delay = 4, title: string = 'Σφάλμα') {
    this.srv.error(message, title);
  }

  info(message, title: string = 'Ενημέρωση') {
    this.srv.info(message, title);
  }

  simple(message, title: string = '???') {
    this.srv.simple(message, title);
  }

  confirmation(message: string, fuc: Function, title: string = 'Επιβεβαίωση Διαγραφής', yes = 'Ναι', no = 'Οχι') {
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
