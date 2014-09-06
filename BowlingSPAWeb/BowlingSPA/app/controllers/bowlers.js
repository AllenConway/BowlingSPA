//IFFY Immediately Invoked Function Expression
(function () {

   var app = angular.module("BowlingSPA");

   var BowlersController = function ($scope, $http, bowling) {

      var onGetBowlers = function (data) {
         return data;
      };

      var onGetBowlersError = function (response) {
         $scope.error = "Could not fetch the bowler information.";
      };

      // Any function returning a promise object can be used to load values asynchronously
      $scope.getBowlers = function (val) {

      //   bowling.getBowlerMatch(val)
      //      .then(function(response) {
      //      return response;
         //   }, onGetBowlersError);

         this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

         return $http.get(this._apiResourceUrl + '/Bowler', { params: { name: val } })
             .then(function (response) {
                //var matchingBowlers = [];
                //angular.forEach(response.data, function (item) {
                //   matchingBowlers.push(item.Id, item.FullName);
                //});
                //return matchingBowlers;
            return response.data;
         });

      };

      var onGetBowlersLeagues = function (data) {         
         $scope.bowlersTeams = data;
      };

      var onGetBowlersLeaguesError = function (response) {
         $scope.error = "Could not fetch the bowler's leagues";
      };

      $scope.getBowlersLeagues = function ($item) {
         bowling.getBowlerLeagues($item.Id)
                  .then(onGetBowlersLeagues, onGetBowlersLeaguesError);
      }

   };

   app.controller("BowlersController", ["$scope", "$http", "bowling", BowlersController]);

}());