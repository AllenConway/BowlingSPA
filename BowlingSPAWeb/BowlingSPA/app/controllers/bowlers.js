/// <reference path="../_refs.ts" />
var BowlingSPA;
(function (BowlingSPA) {
    (function (Controllers) {
        'use strict';

        

        var BowlersController = (function () {
            function BowlersController($scope, $http, bowlingService) {
                var _this = this;
                var onGetBowlers = function (data) {
                    return data;
                };

                var onGetBowlersError = function (response) {
                    $scope.error = "Could not fetch the bowler information.";
                };

                // Any function returning a promise object can be used to load values asynchronously
                $scope.getBowlers = function (val) {
                    //   bowlingService.getBowlerMatch(val)
                    //      .then(function(response) {
                    //      return response;
                    //   }, onGetBowlersError);
                    _this._apiResourceUrl = Globals.apiUrl; //.replace(/:([^\/])/, '\\:$1');

                    return $http.get(_this._apiResourceUrl + '/Bowler', { params: { name: val } }).then(function (response) {
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
                    //Persist the Id of the bowler selected to be used for future calls
                    $scope.bowlerIdSelected = $item.Id;

                    //Get the leagues for the bowler selected
                    bowlingService.getBowlerLeagues($item.Id).then(onGetBowlersLeagues, onGetBowlersLeaguesError);
                };

                //Angular databinding requires values being bound to be defined initially so it can know when changes have been made
                $scope.bowlerData = {};
                var onBowlerStandings = function (data) {
                    $scope.bowlerData = data;
                    //Alternate method - Alert Angular that binding changes have been made
                    //$scope.$apply();
                };

                var onBowlerStandingsError = function (response) {
                    $scope.error = "Could not fetch the bowler's standings";
                };

                $scope.showBowlerData = function ($event, bowlerId, teamId) {
                    //Close the dropdown after a selection has been made
                    $scope.status = {
                        isopen: false
                    };

                    if (bowlerId === null || teamId === null) {
                        return;
                    }

                    //Prevent default processing from occurring on the dropdown - this prevents any navigation from the anchor tag.
                    //Another option supported by modern browsers is just to use href="" to prevent any navigation from occurring.
                    //Downside of this method is manipulating the DOM from controller and thus coupling the view and Controller
                    $event.preventDefault();

                    bowlingService.getBowlerStandings(bowlerId, teamId).then(onBowlerStandings, onBowlerStandingsError);
                    //$scope.userName = "Split Happens";
                };
            }
            BowlersController.$inject = ["$scope", "$http", "bowlingService"];
            return BowlersController;
        })();
        Controllers.BowlersController = BowlersController;
    })(BowlingSPA.Controllers || (BowlingSPA.Controllers = {}));
    var Controllers = BowlingSPA.Controllers;
})(BowlingSPA || (BowlingSPA = {}));
//# sourceMappingURL=bowlers.js.map
