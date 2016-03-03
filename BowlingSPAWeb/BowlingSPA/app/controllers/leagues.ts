/// <reference path="../_refs.ts" />

module BowlingSPA.Controllers {
    'use strict';

    import BowlingModels = BowlingSPAService.Model.EntityModels;

    export interface LeaguesScope extends ng.IScope {
        error: string;
        leagueTeams: BowlingModels.Team[];
        leagues: any;
        status: any;        
        showGridData($event, league): any;
        columns: any[];
        gridOptions: any;
}

    export class LeaguesController {
        
        static $inject = ["$scope", "bowlingService"];

        constructor(
            $scope: LeaguesScope,            
            $bowlingService: Services.BowlingService) {
            

            var onGetLeagues = (leagues: BowlingModels.League[]) => {
                $scope.leagues = leagues;
            };

            var onGetLeaguesError = (response: any) => {
                $scope.error = "Could not fetch the leagues.";
            };

            //Populate all League data upon loading this controller
            $bowlingService.getLeagues()
                .then(onGetLeagues, onGetLeaguesError);

            var onGetLeagueTeams = (teams: BowlingModels.Team[]) => {
                $scope.leagueTeams = teams;
            };

            var onGetLeagueTeamsError = (response: any) => {
                $scope.error = "Could not fetch the selected league team data.";
            };

            $scope.showGridData = ($event, league: BowlingModels.League) => {

                //Close the dropdown after a selection has been made
                $scope.status = {
                    isopen: false
                };

                if (league === null) {
                    return;
                }
                //Prevent default processing from occurring on the dropdown - this prevents any navigation from the anchor tag.
                //Another option supported by modern browsers is just to use href="" to prevent any navigation from occurring.
                //Downside of this method is manipulating the DOM from controller and thus coupling the view and Controller
                $event.preventDefault();


                $bowlingService.getTeams(league.Id)
                    .then(onGetLeagueTeams, onGetLeagueTeamsError);                
            };

            $scope.columns = [
                { field: "Name", displayName: "Team Name", width: "*" },
            ];

            $scope.gridOptions = {
                data: "leagueTeams",
                columnDefs: "columns",
                enableSorting: true,
                sortInfo: { fields: ["Name"], directions: ['asc'] }
            }

        }

       

    }

} 