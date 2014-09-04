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
         getBowlers: getBowlers,
         getLeagueStandings: getLeagueStandings
      };

   };

   var app = angular.module("BowlingSPA");
   //Of the 20 ways you can register a service you create in Angular, this is by far the easiest
   app.factory("bowling", bowling);

}());