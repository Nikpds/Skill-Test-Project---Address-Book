import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { RouterModule, Route } from '@angular/router';

import { AngularOpenlayersModule } from 'ngx-openlayers';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';
import { DocumentationComponent } from './documentation/documentation.component';
import { MapComponent } from './map/map.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UserModalComponent } from './user-modal/user-modal.component';

const routes: Route[] = [
  { path: 'home', component: HomeComponent },
  { path: 'docs', component: DocumentationComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: '**', redirectTo: '' }
];
@NgModule({
  declarations: [
    NavbarComponent,
    HomeComponent,
    DocumentationComponent,
    MapComponent,
    UserModalComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    AngularOpenlayersModule,
    ReactiveFormsModule
  ],
  exports: [
    NavbarComponent
  ]
})
export class LayoutModule { }
