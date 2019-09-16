import { Component, OnInit, OnDestroy } from '@angular/core';
import { BaseService } from '../base.service';
import { User } from 'src/app/model';
import { NotifyService } from 'src/app/shared/notify.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit, OnDestroy {
  private subscriptions = new Array<Subscription>();
  contancts = new Array<User>();
  constructor(
    private service: BaseService,
    private notify: NotifyService
  ) { }

  ngOnInit() {
    this.subscriptions.push(this.service.contacts$.subscribe(data => this.contancts = data));
    this.getContacts();
  }

  ngOnDestroy() {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }

  private getContacts() {
    this.service.getAll<User>('user/all').subscribe(res => {
      this.service.contacts = res;
    }, error => {
      this.notify.danger(error);
    });
  }
  // Show/Hide address on the map
  showAddressOnMap(contactIndex: number, addressIndex: number) {
    this.contancts[contactIndex].addresses[addressIndex].isVisible = !this.contancts[contactIndex].addresses[addressIndex].isVisible;
    this.service.contacts = this.contancts;
  }

  confirmDeleteContanct(index: number) {
    this.notify.confirmation('Do you want to remove the contact ?',
      () => this.deleteContact(index), 'Confirmation');
  }

  private deleteContact(index: number) {
    const id = this.contancts[index].id;
    this.service.delete(id, 'user').subscribe(res => {
      if (res) {
        this.contancts.splice(index, 1);
        this.notify.success('The contact was deleted');
      }
    }, error => {
      this.notify.danger(error);
    });
  }
}
