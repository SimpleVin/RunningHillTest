// Angular Modules
import { Injectable } from '@angular/core';
// Application Classes
import { UrlBuilder } from '../../shared/url-builder';
import { QueryStringParameters } from '../../shared/classes';

import { environment } from '../environment/enviroment';

@Injectable({
  providedIn: 'root',
})

// Returns the api endpoints urls to use in services in a consistent way
export class ApiEndpointsService {
  constructor() {}


  /* #end region EXAMPLES */

  // TALENT MANAGEMENT
  // call Words endpoint
  public getWordTypesEndpoint = (): string => this.createUrl('/word/GetWordTypes');
  // call Words endpoint
  public getWordsByWordTypeEndpoint = (id: string): string => this.createUrlWithPathVariables('/word/GetWordsByWordType', [id]);
  // call Sentence endpoint
  public postCreateSentenceEndpoint = (): string => this.createUrl('/word/SaveWord');

  /* #region URL CREATOR */
  // URL
  private createUrl(action: string, isMockAPI: boolean = false): string {
    const urlBuilder: UrlBuilder = new UrlBuilder(
      environment.BaseUrl,
      action
    );
    return urlBuilder.toString();
  }

  // URL WITH PATH VARIABLES
  private createUrlWithPathVariables(action: string, pathVariables: any[] = []): string {
    let encodedPathVariablesUrl: string = '';
    // Push extra path variables
    for (const pathVariable of pathVariables) {
      if (pathVariable !== null) {
        encodedPathVariablesUrl += `/${encodeURIComponent(pathVariable.toString())}`;
      }
    }
    const urlBuilder: UrlBuilder = new UrlBuilder(environment.BaseUrl, `${action}${encodedPathVariablesUrl}`);
    return urlBuilder.toString();
  }
}