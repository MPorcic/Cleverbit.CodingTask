import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MatchService {

  constructor(private $http: HttpClient) { 
    
  }

  getCurrentMatch()
  {
    return this.$http.get(environment.apiUrl+'/api/currentMatch');
  }
  getMatchResults() 
  {
    return this.$http.get<any[]>(environment.apiUrl+'/api/matchResults');
  }
  refreshResults()
  {
    return this.$http.get(environment.apiUrl+'/api/refreshResults');
  }
  sendEntryForMatch(matchId:number)
  {
    return this.$http.post(environment.apiUrl+'/api/sendEntry', matchId);
  }

}
