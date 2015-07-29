/// <reference path="../_refs.ts" />

module BowlingSPA.Services {
    'use strict';

    export class BowlingService {

        private _apiResourceUrl: string;
        private _http: ng.IHttpService;

        static $inject = ["$http"];
        constructor($http: ng.IHttpService) {

            this._http = $http;
        }

        public addBowler(bowler: BowlingSPAService.Model.EntityModels.Bowler): any {
            
            this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

            return this._http.post(this._apiResourceUrl + 'Bowler', bowler)
                .then(response => response.data);
        }

        public getLeagues(): any {

            this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

            return this._http.get(this._apiResourceUrl + 'Leagues')
                .then(response => response.data);
        }

        public getBowlerLeagues(bowlerId): any {

            this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

            return this._http.get(this._apiResourceUrl + 'BowlerLeagues/' + bowlerId)
                .then(response => response.data);
        }

        public getBowlerStandings(bowlerId, teamId): any {

            this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

            return this._http.get(this._apiResourceUrl + 'BowlerStandings', { params: { bowlerId: bowlerId, teamId: teamId } })
                .then(response => response.data);
        }

        public getBowlerMatch(val): any {

            this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

            return this._http.get(this._apiResourceUrl + 'Bowler', { params: { name: val } })
                .then(response => {
                    var matchingBowlers = [];
                    angular.forEach(response.data, item => {
                        matchingBowlers.push(item.FullName);
                    });
                    return matchingBowlers;
                });
        }

        public getBowlers(): any {

            this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

            return this._http.get(this._apiResourceUrl + '/Bowler')
                .then(response => response.data);
        }

        public getLeagueStandings(leagueId): any {

            this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

            return this._http.get(this._apiResourceUrl + '/LeagueStandings/' + leagueId)
                .then(response => response.data);
        }

    }

    BowlingSPA.app.service("bowlingService", BowlingService);

}