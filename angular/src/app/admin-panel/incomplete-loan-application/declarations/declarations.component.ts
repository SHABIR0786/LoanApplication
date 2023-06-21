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
    debugger
    for(var i=0 ; i<19 ; i = i+1){
      this.declarationsList.push(new DeclarationsModel())
    }
    debugger
  }
  assignQuestionId(index, questionId)
  {
    debugger
    this.declarationsList[index].declarationQuestionId = questionId; 
  }
  create()
  {
    debugger
    if(this.declarationsList[0] != undefined && this.declarationsList[0].answer == "No")
    {
      this.declarationsList.splice(0,1)
      this.declarationsList.splice(0,2)
      this.declarationsList.splice(0,3)
    }
    if(this.declarationsList[17] != undefined && this.declarationsList[17].answer == "No")
    {
      this.declarationsList.splice(0,18)
    }
    if(this.declarationsList[5] != undefined && this.declarationsList[5].answer == "No")
    {
      this.declarationsList.splice(0,6)
    }
    var indexList=[];
    this.declarationsList.forEach((element:any, index:any)=>{
      debugger
      if(element.answer == '')
      {
        indexList.push({index:index})
      }
    })
    if(indexList.length > 0)
    {debugger
      indexList.forEach((element:any)=>{
        debugger
        this.declarationsList.splice(0,element.index)
  
      })
    }
   
    var obj = this.declarationsList;
    this.declarationsService.create(obj).subscribe((data:any)=>{
      if(data.success == true)
      {
        alert("Data inserted successfully")
      }
    })
  }
}
