import { Component, OnInit } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { IPet } from '../shared/models/IPet';
import { ShopService } from './shop.service';
import { IPetPagination } from '../shared/models/IPetPagination';
import { IAnimal } from '../shared/models/IAnimal';
import { PetRequestParams } from '../shared/models/PetRequestParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  pets: IPet[] | undefined;
  animals: IAnimal[] | undefined;
  petRequestParams = new PetRequestParams;

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getPets();
    this.getAnimals();
  }

  private getPets() {
    this.shopService.getPets(this.petRequestParams).subscribe(
      {
        next: (response: IPetPagination | null) => this.pets = response?.data,
        error: e => console.log(e)
      }
    )
  }

  private getAnimals()
  {
    this.shopService.getAnimals().subscribe(
      {
        next: (response: IAnimal[]) => this.animals = response,
        error: e => console.log(e)
      }
    )
  }

  public onAnimalSelected(id : number)
  {
    this.petRequestParams.animalsId = id;
    this.petRequestParams.pageIndex = 1;
    this.getPets();
  }
}
