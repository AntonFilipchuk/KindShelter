import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.scss']
})
export class PagerComponent implements OnChanges {

  @Input() numberOfPages: number = 1;
  //Page index from requestParams
  @Input() pageIndex: number = 1;

  @Output() selectedPageNumberEmitter = new EventEmitter<number>();

  currentPage: number = 1;

  ngOnChanges(changes: SimpleChanges): void {
    //Every time when we have any changes set page to 1
    this.currentPage = this.pageIndex; 
  }

  selectedPageNumber(selectedPageNumber: number): void {
    if (selectedPageNumber < this.numberOfPages + 1 && selectedPageNumber > 0) {
      this.currentPage = selectedPageNumber;
      this.selectedPageNumberEmitter.emit(selectedPageNumber);
    }
  }
}
