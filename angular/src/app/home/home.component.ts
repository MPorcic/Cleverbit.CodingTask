import { MatchService } from './../services/match.service';
import { environment } from './../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private $http: HttpClient, private matchService: MatchService) { }

  public matches:any[] = [];
  displayedColumns: string[] = [ 'matchId', 'winner', 'score'];
  public match: any;
  entrySubmitted: boolean = false;
  matchResults: any[] = [];

  ngOnInit(): void {
    var headers_object = new HttpHeaders();
    this.$http.get<any[]>(environment.apiUrl+"/api/ping/with-auth", {
      responseType: "json",
      withCredentials: true
    }
    ).subscribe(x => {
      this.matches = x;
      console.log(this.matches);
    })
    this.getResults();
    this.refreshCurrentMatch();
  }

  refreshCurrentMatch()
  {
    this.matchService.getCurrentMatch().subscribe((x: any)=> {
      this.match = x
      var matchId = localStorage.getItem('matchId');
      if(!matchId)
      {
        localStorage.setItem('matchId', x.id);
      } else {
        this.entrySubmitted = matchId == x.id;
      }
    });
  }

  getResults()
  {
    this.matchService.getMatchResults().subscribe((results:any[]) => {
      this.matchResults = results;

    });
  }

  sendEntry(matchId: number)
  {
    console.log('sends');
    this.matchService.sendEntryForMatch(matchId).subscribe(x=> 
      {
        this.entrySubmitted = true;
        localStorage.setItem('matchId', matchId+'');
      });
  }
  refreshResults()
  {
    this.matchService.refreshResults().subscribe((x) => 
     {
       this.refreshCurrentMatch();

     });
  }
}
