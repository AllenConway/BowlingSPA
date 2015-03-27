module BowlingSPA.Controllers {
    'use strict'

    //export var app :ng.IModule = angular.module("BowlingSPA");

    //Augment $scope with our own types so that Angular understands and we get type checking
    export interface BowlersScope extends ng.IScope {
        error: string;
        getBowlers(val: any): any;
        bowlersTeams: any;
        getBowlersLeagues($item: any);
        bowlerIdSelected: number;
        bowlerData: any;
        showBowlerData($event, bowlerId, teamId): any;
        status: any;
    }

    export class BowlersController {
        
        private _apiResourceUrl: string;
        private _http: ng.IHttpService;

        static $inject = ["$scope", "$http", "bowling"];
        constructor($scope: BowlersScope, $http: ng.IHttpService, bowling) {
            
            var onGetBowlers = (data: any) => {
                return data;
            };

            var onGetBowlersError = (response: any) => {
                $scope.error = "Could not fetch the bowler information.";
            };

            // Any function returning a promise object can be used to load values asynchronously
            $scope.getBowlers = (val: any) => {

                //   bowling.getBowlerMatch(val)
                //      .then(function(response) {
                //      return response;
                //   }, onGetBowlersError);

                this._apiResourceUrl = Globals.apiUrl;//.replace(/:([^\/])/, '\\:$1');

                return $http.get(this._apiResourceUrl + '/Bowler', { params: { name: val } })
                    .then((response) => {
                        //var matchingBowlers = [];
                        //angular.forEach(response.data, function (item) {
                        //   matchingBowlers.push(item.Id, item.FullName);
                        //});
                        //return matchingBowlers;
                        return response.data;
                    });

            };

            var onGetBowlersLeagues = (data: any) => {
                $scope.bowlersTeams = data;
            };

            var onGetBowlersLeaguesError = (response: any) => {
                $scope.error = "Could not fetch the bowler's leagues";
            };

            $scope.getBowlersLeagues = ($item: any) => {
                //Persist the Id of the bowler selected to be used for future calls
                $scope.bowlerIdSelected = $item.Id;
                //Get the leagues for the bowler selected
                bowling.getBowlerLeagues($item.Id)
                    .then(onGetBowlersLeagues, onGetBowlersLeaguesError);
            }

            //Angular databinding requires values being bound to be defined initially so it can know when changes have been made     
            $scope.bowlerData = {};
            var onBowlerStandings = (data) => {
                $scope.bowlerData = data;

                //Alternate method - Alert Angular that binding changes have been made
                //$scope.$apply();

            };

            var onBowlerStandingsError = (response: any) => {
                $scope.error = "Could not fetch the bowler's standings";
            };

            $scope.showBowlerData = ($event, bowlerId, teamId) => {

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


                bowling.getBowlerStandings(bowlerId, teamId)
                    .then(onBowlerStandings, onBowlerStandingsError);
                //$scope.userName = "Split Happens";
            };

        }

    }


}