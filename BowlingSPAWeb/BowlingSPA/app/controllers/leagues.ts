/// <reference path="../_refs.ts" />

module BowlingSPA.Controllers {
    'use strict';

    export interface LeaguesScope extends ng.IScope {
        error: string;
        leagues: any;
        status: any;
        getLeagues(): any;
        showGridData($event, league): any;
    }

    export class LeaguesController {
        
        static $inject = ["$scope", "$location", "bowlingService"];

        constructor(
            $scope: LeaguesScope,
            $location: ng.ILocationService,
            $bowlingService: Services.BowlingService) {
            

            var onGetLeagues = (leagues: BowlingSPAService.Model.EntityModels.League[]) => {
                $scope.leagues = leagues;
            };

            var onGetLeaguesError = (response: any) => {
                $scope.error = "Could not fetch the leagues";
            };

            //Populate all League data upon loading this controller
            $bowlingService.getLeagues()
                .then(onGetLeagues, onGetLeaguesError);

            //$scope.showGridData = ($event, league) => {

            //    //Close the dropdown after a selection has been made
            //    $scope.status = {
            //        isopen: false
            //    };

            //    if (league === null) {
            //        return;
            //    }
            //    //Prevent default processing from occurring on the dropdown - this prevents any navigation from the anchor tag.
            //    //Another option supported by modern browsers is just to use href="" to prevent any navigation from occurring.
            //    //Downside of this method is manipulating the DOM from controller and thus coupling the view and Controller
            //    $event.preventDefault();


            //    bowlingService.getLeagueStandings(team.Id)
            //        .then(onTeamStandings, onTeamStandingsError);
            //    //$scope.userName = "Split Happens";
            //};

        }

       

    }

} 