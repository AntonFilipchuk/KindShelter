import { Component, Input } from '@angular/core';
import { IPet } from 'src/app/shared/models/IPet';

@Component({
  selector: 'app-item-card',
  templateUrl: './item-card.component.html',
  styleUrls: ['./item-card.component.scss']
})
export class ItemCardComponent {
  @Input() pet!: IPet;
}
