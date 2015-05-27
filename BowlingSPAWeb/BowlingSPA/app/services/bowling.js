/// <reference path="../_refs.ts" />
var BowlingSPA;
(function (BowlingSPA) {
    var Services;
    (function (Services) {
        'use strict';
        var BowlingService = (function () {
            function BowlingService($http) {
                this._http = $http;
            }
            BowlingService.prototype.getLeagues = function () {
                this._apiResourceUrl = Globals.apiUrl; //.replace(/:([^\/])/, '\\:$1');
                return this._http.get(this._apiResourceUrl + '/Leagues')
                    .then(function (response) { return response.data; });
            };
            BowlingService.prototype.getBowlerLeagues = function (bowlerId) {
                this._apiResourceUrl = Globals.apiUrl; //.replace(/:([^\/])/, '\\:$1');
                return this._http.get(this._apiResourceUrl + '/BowlerLeagues/' + bowlerId)
                    .then(function (response) { return response.data; });
            };
            BowlingService.prototype.getBowlerStandings = function (bowlerId, teamId) {
                this._apiResourceUrl = Globals.apiUrl; //.replace(/:([^\/])/, '\\:$1');
                return this._http.get(this._apiResourceUrl + '/BowlerStandings', { params: { bowlerId: bowlerId, teamId: teamId } })
                    .then(function (response) { return response.data; });
            };
            BowlingService.prototype.getBowlerMatch = function (val) {
                this._apiResourceUrl = Globals.apiUrl; //.replace(/:([^\/])/, '\\:$1');
                return this._http.get(this._apiResourceUrl + '/Bowler', { params: { name: val } })
                    .then(function (response) {
                    var matchingBowlers = [];
                    angular.forEach(response.data, function (item) {
                        matchingBowlers.push(item.FullName);
                    });
                    return matchingBowlers;
                });
            };
            BowlingService.prototype.getBowlers = function () {
                this._apiResourceUrl = Globals.apiUrl; //.replace(/:([^\/])/, '\\:$1');
                return this._http.get(this._apiResourceUrl + '/Bowler')
                    .then(function (response) { return response.data; });
            };
            BowlingService.prototype.getLeagueStandings = function (leagueId) {
                this._apiResourceUrl = Globals.apiUrl; //.replace(/:([^\/])/, '\\:$1');
                return this._http.get(this._apiResourceUrl + '/LeagueStandings/' + leagueId)
                    .then(function (response) { return response.data; });
            };
            BowlingService.$inject = ["$http"];
            return BowlingService;
        })();
        Services.BowlingService = BowlingService;
        BowlingSPA.app.service("bowlingService", BowlingService);
    })(Services = BowlingSPA.Services || (BowlingSPA.Services = {}));
})(BowlingSPA || (BowlingSPA = {}));
//# sourceMappingURL=bowling.js.map