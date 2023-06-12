import { Component, OnInit } from "@angular/core";
import {DeclarationsModel} from "./declarations-model"
import {DeclarationsService} from "./declarations.service"
@Component({
  selector: "app-declarations",
  templateUrl: "./declarations.component.html",
  styleUrls: ["./declarations.component.css"],
})
export class DeclarationsComponent implements OnInit {
  declarationsList:DeclarationsModel[]=[]
  constructor(private declarationsService:DeclarationsService) {}

  ngOnInit(): void {
    for(var i=0 ; i<19 ; i = i+1){
      this.declarationsList.push(new DeclarationsModel())
    }
  }
  assignQuestionId(index, questionId)
  {
    this.declarationsList[index].declarationQuestionId = questionId; 
  }
  create()
  {
    var obj = this.declarationsList;
    this.declarationsService.create(obj).subscribe((data:any)=>{
      alert("Data Inserted successfully")
    })
  }
}
