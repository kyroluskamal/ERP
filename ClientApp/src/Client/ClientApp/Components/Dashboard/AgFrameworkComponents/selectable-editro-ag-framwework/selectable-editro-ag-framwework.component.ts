import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { ICellRendererParams } from 'ag-grid-community';
import { ItemsService } from '../../Items/items.service';

@Component({
  selector: 'app-selectable-editro-ag-framwework',
  templateUrl: './selectable-editro-ag-framwework.component.html',
  styleUrls: ['./selectable-editro-ag-framwework.component.css']
})
export class SelectableEditroAgFramweworkComponent implements ICellRendererAngularComp {

  constructor(private ItemServices: ItemsService) { }
  SelectMainCatsForm: FormControl = new FormControl("");
  selectedItem: any;
  params: any;
  agInit(params: any): void {
    this.params = params;
    this.selectedItem = params.value;
  }

  refresh(params?: any): boolean {
    this.selectedItem = this.getValueToDisplay(params);
    return true;
  }
  getValueToDisplay(params: ICellRendererParams) {
    this.selectedItem = params.value;
    return params.value;
  }
  onChange(event: any) {
    if (this.params.onClick instanceof Function) {

      this.params.onClick(this.params);
    }
  }
}
