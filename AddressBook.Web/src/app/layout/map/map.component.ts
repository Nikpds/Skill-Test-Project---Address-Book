import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { BaseService } from '../base.service';
import { User, Address } from 'src/app/model';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.sass']
})
export class MapComponent implements OnInit, OnDestroy {
  private subscriptions = new Array<Subscription>();
  features = new Array<Address>();

  constructor(private service: BaseService) { }

  ngOnInit() {
    this.subscriptions.push(this.service.contacts$.subscribe(data => {
      this.getFeatures(data);
    }));
  }

  ngOnDestroy() {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }

  getFeatures(contacts: Array<User>) {
    const addr = contacts.map(x => x.addresses.filter(a => a.isVisible));
    this.features = [].concat.apply([], addr);
  }

}
