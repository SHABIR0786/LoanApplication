import { Component, Input, OnInit } from '@angular/core';
import {IDeclarationModel} from '../../interfaces/IDeclarationModel';

@Component({
  selector: 'app-declaration',
  templateUrl: './declaration.component.html',
  styleUrls: ['./declaration.component.css']
})
export class DeclarationComponent implements OnInit {

  @Input() data: IDeclarationModel = {};
  constructor() { }

  ngOnInit(): void {
  }

}
