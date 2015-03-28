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

        public getLeagues(): any {

            this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

            return this._http.get(this._apiResourceUrl + '/Leagues')
                .then(function (response) {
                    return response.data;
                });
        }

        public getBowlerLeagues(bowlerId): any {

            this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

            return this._http.get(this._apiResourceUrl + '/BowlerLeagues/' + bowlerId)
                .then(function (response) {
                    return response.data;
                });
        }

        public getBowlerStandings(bowlerId, teamId): any {

            this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

            return this._http.get(this._apiResourceUrl + '/BowlerStandings', { params: { bowlerId: bowlerId, teamId: teamId } })
                .then(function (response) {
                    return response.data;
                });
        }

        public getBowlerMatch(val): any {

            this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

            return this._http.get(this._apiResourceUrl + '/Bowler', { params: { name: val } })
                .then(function (response) {
                    var matchingBowlers = [];
                    angular.forEach(response.data, function (item) {
                        matchingBowlers.push(item.FullName);
                    });
                    return matchingBowlers;
                });
        }

        public getBowlers(): any {

            this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

            return this._http.get(this._apiResourceUrl + '/Bowler')
                .then(function (response) {
                    return response.data;
                });
        }

        public getLeagueStandings(leagueId): any {

            this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

            return this._http.get(this._apiResourceUrl + '/LeagueStandings/' + leagueId)
                .then(function (response) {
                    return response.data;
                });
        }

    }

    BowlingSPA.app.service("bowlingService", BowlingService);

}