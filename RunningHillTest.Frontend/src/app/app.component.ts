import {Component, ViewChild} from '@angular/core';
import { WordModel } from './models/word.model';
import { environment } from './core/environment/enviroment'; 
import { HttpClient } from '@angular/common/http';
import { WordTypeModel } from './models/wordtype.model';
import { SentenceModel } from './models/sentence.model';
import { transition, style, animate, trigger } from '@angular/animations';


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
  panelOpenState = false;
  private baseUrl = environment.BaseUrl;
  isButtonEnabled: boolean = true;
  selectedType : number = 0;
  sentence : string = "";
  message: string = "";
  show = false;
  mySentence: WordModel[] = [];
  currentSelectedWord: number = 0;
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
  this.currentSelectedWord = selectedWordType;
  this.http.get<WordModel[]>(this.baseUrl+'/word/GetWordsByWordType/' + selectedWordType).subscribe(
    (data)=>{
      this.wordList = data;
    }
  );
}

changeSelected(selectedWord: string, id: string): void {
  this.mySentence.push({ text: selectedWord, id: id, wordTypeId: this.currentSelectedWord});

  this.isButtonEnabled = false;
 
}
remove(word: WordModel): void {
  const index = this.mySentence.indexOf(word);
 
  if (index >= 0) {
    this.mySentence.splice(index, 1);
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

    var NewSentence: SentenceModel = {
      text : "",
      words : ""
    }
    this.mySentence.forEach(function(item, index, list) {
        if(index === list.length - 1)
          {
            NewSentence.text +=item.text;
            NewSentence.words += item.id;
          }
          else{
            NewSentence.text += item.text + " ";
            NewSentence.words += item.id + ",";
          }
        });
   
    this.http.post<string>(this.baseUrl+'/sentence/SaveSentence',NewSentence).subscribe(data => {
      this.show = true;
     this.message = data;
     
  this.sentenceList.unshift({ text: NewSentence.text, words: ""});
  });
  setTimeout(() => {
    this.show = false;
}, 5000);
    this.sentence = "";
  }
}

title = 'Sentence creator';
  time = new Date();
}