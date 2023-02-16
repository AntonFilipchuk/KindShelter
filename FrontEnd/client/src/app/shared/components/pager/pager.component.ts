import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.scss']
})
export class PagerComponent {

  //Pager component comes from ngx-bootstrap
  @Input() totalItems!: number;

  @Input() pageSize!: number;

  @Output() numberOfSelectedPageEmitter = new EventEmitter<number>();

  pageChanged(event: PageChangedEvent): void {
    this.numberOfSelectedPageEmitter.emit(event.page)
  }

}
