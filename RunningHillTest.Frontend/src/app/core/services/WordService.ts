import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WordModel } from '../../models/word.model'; 
import { environment } from '../../core/environment/enviroment'; 


@Injectable()
export class WordService {
  wordList: WordModel[] = [];
  private baseUrl = environment.BaseUrl;

  constructor(private http: HttpClient) {}

  getWords() {
    this.http.get<WordModel[]>(this.baseUrl+'/word/GetWords').subscribe(
      (data)=>{
        this.wordList= data;
      })
      return this.wordList;
  }
}