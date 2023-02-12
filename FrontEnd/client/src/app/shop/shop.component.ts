import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { IPet } from '../shared/models/IPet';
import { ShopService } from './shop.service';
import { IPetPagination } from '../shared/models/IPetPagination';
import { IAnimal } from '../shared/models/IAnimal';
import { PetRequestParams } from '../shared/models/PetRequestParams';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  //Use temple reference variable in select HTML component #search
  @ViewChild('search', { static: false }) searchCondition: ElementRef | undefined;

  pets: IPet[] | undefined;

  animals: IAnimal[] | undefined;

  petRequestParams = new PetRequestParams;

  ifVaccinated: boolean = false;

  sortOptions = [
    { name: 'Default', value: '' },
    { name: 'Price: low to high', value: 'priceAsc' },
    { name: 'Price: high to low', value: 'priceDsc' }
  ]

  test = [
    { name: "Test", testProperty: true }
  ]

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getPets();
    this.getAnimals();
  }

  private getPets() {
    this.shopService.getPets(this.petRequestParams).subscribe(
      {
        next: (response: IPetPagination | null) => this.pets = response?.data,
        error: (e: HttpErrorResponse) => {
          if (e.status === 404) {
            this.pets = undefined;
            console.log(e);
          }
          else {
            console.log(e);
          }
        }
      }
    )
  }

  private getAnimals() {
    this.shopService.getAnimals().subscribe(
      {
        next: (response: IAnimal[]) => this.animals = [{ id: 0, pluralAnimalName: 'All' }, ...response],
        error: (e: HttpErrorResponse) => console.log(e)
      }
    )
  }

  public onAnimalSelected(id: number) {
    this.petRequestParams.animalsId = id;
    this.petRequestParams.pageIndex = 1;
    this.getPets();
  }

  public onSortSelected($event: Event) {
    //When option is selected html element emits $event that contains
    //information about html element itself
    //so to get the value of an element 
    //(for this case - text of the selected element (priceAsc, priceDsc))
    //in HTML component we specify the [value]
    //$event.target should be casted to a HTMLInputElement
    //then we can get a value of it (that contains text that we passed to [value])
    const sortValue = ($event.target as HTMLInputElement).value;
    if (sortValue) {
      this.petRequestParams.sort = sortValue;
    }
    else {
      this.petRequestParams.sort = undefined;
    }

    this.getPets();
  }

  public onSearch() {
    if (!this.searchCondition) {
      return;
    }

    //Get the value of temple reference variable
    this.petRequestParams.search = this.searchCondition.nativeElement.value;
    this.getPets();
  }

  public onVaccinatedSelected()
  {
    this.ifVaccinated = !this.ifVaccinated;
    this.petRequestParams.vaccinationStatus = this.ifVaccinated;
    this.getPets(); 
  }
}
