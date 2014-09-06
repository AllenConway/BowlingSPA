//IFFY Immediately Invoked Function Expression
(function () {

   var bowling = function ($http) {
      
      var getLeagues = function () {

         this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

         return $http.get(this._apiResourceUrl + '/Leagues')
             .then(function (response) {
                return response.data;
             });
      }

      var getBowlerLeagues = function (bowlerId) {

         this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

         return $http.get(this._apiResourceUrl + '/BowlerLeagues/' + bowlerId)
             .then(function (response) {
                return response.data;
             });
      }

      var getBowlerMatch = function (val) {

         this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

         return $http.get(this._apiResourceUrl + '/Bowler', { params: { name: val } })
             .then(function (response) {
                var matchingBowlers = [];
                angular.forEach(response.data, function (item) {
                   matchingBowlers.push(item.FullName);
                });
                return matchingBowlers;
             });
      }

      var getBowlers = function () {

         this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

         return $http.get(this._apiResourceUrl + '/Bowler')
             .then(function (response) {
                return response.data;
             });
      }

      var getLeagueStandings = function (leagueId) {

         this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

         return $http.get(this._apiResourceUrl + '/LeagueStandings/' + leagueId)
             .then(function (response) {
                return response.data;
             });
      }

      return {
         getLeagues: getLeagues,
         getBowlerLeagues: getBowlerLeagues,
         getBowlerMatch: getBowlerMatch,
         getBowlers: getBowlers,
         getLeagueStandings: getLeagueStandings
      };

   };

   var app = angular.module("BowlingSPA");
   //Of the 20 ways you can register a service you create in Angular, this is by far the easiest
   app.factory("bowling", bowling);

}());