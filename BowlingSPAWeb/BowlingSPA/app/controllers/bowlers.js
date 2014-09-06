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

      var onBowlerStandings = function (data) {
         $scope.bowlerData = data;
      };

      var onBowlerStandingsError = function (response) {
         $scope.error = "Could not fetch the bowler's standings";
      };

      $scope.showBowlerData = function ($event, bowlerId, teamId) {

         //Close the dropdown after a selection has been made
         $scope.status = {
            isopen: false
         };

         if (bowlerId === null) {
            return;
         }
         //Prevent default processing from occurring on the dropdown - this prevents any navigation from the anchor tag.
         //Another option supported by modern browsers is just to use href="" to prevent any navigation from occurring.
         //Downside of this method is manipulating the DOM from controller and thus coupling the view and Controller
         $event.preventDefault();


         bowling.getBowlerStandings(bowlerId, teamId)
            .then(onBowlerStandings, onBowlerStandingsError);
         //$scope.userName = "Split Happens";
      };

   };

   app.controller("BowlersController", ["$scope", "$http", "bowling", BowlersController]);

}());