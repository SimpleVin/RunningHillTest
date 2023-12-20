import { Component } from '@angular/core';
import { WordService } from './core/services/WordService';
import { WordModel } from './models/word.model';
import { Observable } from 'rxjs';
import { environment } from './core/environment/enviroment'; 
import { HttpClient } from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { WordTypeModel } from './models/wordtype.model';
import { SentenceModel } from './models/sentence.model';
import { transition, style, animate, trigger } from '@angular/animations';
import {MatListModule} from '@angular/material/list';


const enterTransition = transition(':enter', [
  style({
    opacity: 0
  }),
  animate('1s ease-in', style({
    opacity: 1
  }))
]);
const leaveTrans = transition(':leave', [
  style({
    opacity: 1
  }),
  animate('3s ease-out', style({
    opacity: 0
  }))
])
const fadeIn = trigger('fadeIn', [
  enterTransition
]);

const fadeOut = trigger('fadeOut', [
  leaveTrans
]);

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  animations: [
    fadeIn,
    fadeOut
  ]
})
export class AppComponent {
  private baseUrl = environment.BaseUrl;
  isButtonEnabled: boolean = true;
  selectedType : number = 0;
  sentence : string = "";
  message: string = "";
  show = false;
  wordList: WordModel[] = [];
  wordTypeList: WordTypeModel[] = [];
  sentenceList: SentenceModel[] = [];
  constructor(private http: HttpClient) {
    setInterval( ()=> this.time = new Date(), 1000);
   this.getWordTypes();
   this.getSentences();
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


getSentences(){
  this.http.get<SentenceModel[]>(this.baseUrl+'/sentence/GetSentences').subscribe(
   (data)=>{
     this.sentenceList = data;
   }
 );
}
saveSentence()
{
  if(!this.isButtonEnabled)
  {
    const newSentence: SentenceModel = {
      text : this.sentence,
      words : ""
    }
    this.http.post<string>(this.baseUrl+'/sentence/SaveSentence',newSentence).subscribe(data => {
      this.show = true;
     this.message = data;
     
   this.getSentences();
  })
  setTimeout(() => {
    this.show = false;
}, 5000);
    this.sentence = "";
  }
}

title = 'Sentence creator';
  time = new Date();
}