import { Component, OnInit } from '@angular/core';
import { IPet } from 'src/app/shared/models/IPet';
import { TestServiceService } from '../test-service.service';
import { IPetPagination } from 'src/app/shared/models/IPetPagination';

@Component({
  selector: 'app-testing',
  templateUrl: './testing.component.html',
  styleUrls: ['./testing.component.scss']
})
export class TestingComponent implements OnInit {
  pets: IPet[] | undefined;

  constructor(private testService: TestServiceService) { }

  ngOnInit(): void {
    this.testService.getPets().subscribe(
      {
        next: (response: IPetPagination) => this.pets = response.data,
        error: e => console.log(e)
      }
    )
  }
}
