//IFFY Immediately Invoked Function Expression
(function () {

   var app = angular.module("BowlingSPA");

   var PlayersController = function ($scope, bowling) {

      // Any function returning a promise object can be used to load values asynchronously
      $scope.getBowlers = function (val) {



         bowling.getBowlers(val)
            .then(onTeamStandings, onTeamStandingsError);
      };

   };

   app.controller("PlayersController", ["$scope", "bowling", PlayersController]);

}());