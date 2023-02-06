import { Component, OnInit } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { IPet } from '../shared/models/IPet';
import { ShopService } from './shop.service';
import { IPetPagination } from '../shared/models/IPetPagination';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  pets: IPet[] | undefined;


  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.shopService.getPets().subscribe(
      {
        next: (response: IPetPagination) => this.pets = response.data,
        error: e => console.log(e)
      }
    )
  }
}
