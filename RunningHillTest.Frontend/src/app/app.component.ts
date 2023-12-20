import { Component } from '@angular/core';
import { WordService } from './core/services/WordService';
import { WordModel } from './models/word.model';
import { Observable } from 'rxjs';
import { environment } from './core/environment/enviroment'; 
import { HttpClient } from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { WordTypeModel } from './models/wordtype.model';
import { SentenceModel } from './models/sentence.model';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  private baseUrl = environment.BaseUrl;
  isButtonEnabled: boolean = true;
  selectedType : number = 0;
  sentence : string = "";
  wordList: WordModel[] = [];
  wordTypeList: WordTypeModel[] = [];
  constructor(private http: HttpClient) {
    setInterval( ()=> this.time = new Date(), 1000);
   this.getWordTypes();
}

getWords(){
   this.http.get<WordModel[]>(this.baseUrl+'/word/GetWords').subscribe(
    (data)=>{
      this.wordList= data;
    }
  );
}
loadWords(selectedWordType: number): void {
  this.http.get<WordModel[]>(this.baseUrl+'/word/GetWordsByWordType/' + selectedWordType).subscribe(
    (data)=>{
      this.wordList = data;
    }
  );
}

changeSelected(selectedWord: string): void {
  this.isButtonEnabled = false;
    if(this.sentence != "")
    this.sentence += " " + selectedWord; 
    else
    {
      this.sentence = selectedWord;
    }
}
getWordTypes(){
  this.http.get<WordTypeModel[]>(this.baseUrl+'/wordType/GetWordTypes').subscribe(
   (data)=>{
     this.wordTypeList= data;
   }
 );
}
saveSentence()
{
  console.log(this.isButtonEnabled);
  console.log(this.sentence);
  if(!this.isButtonEnabled)
  {
    const newSentence: SentenceModel = {
      text : this.sentence,
      words : ""
    }
    this.http.post<SentenceModel>(this.baseUrl+'/wordType/SaveWord',newSentence).subscribe(data => {
     console.log(data);
  })
    this.sentence = "";
  }
}

title = 'Sentence creator';
  time = new Date();
}