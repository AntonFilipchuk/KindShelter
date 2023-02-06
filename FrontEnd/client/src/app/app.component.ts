import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPet } from './shared/models/IPet';
import { IPetPagination } from './shared/models/IPetPagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'PetShop';
}
