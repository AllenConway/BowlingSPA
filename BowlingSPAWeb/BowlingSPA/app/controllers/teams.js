//IFFY Immediately Invoked Function Expression
(function () {

   var app = angular.module("BowlingSPA");

   var TeamsController = function ($scope, bowlingService) {

      //$scope.teams = [
      // {Id: '1', Name: 'Team 1'},
      // {Id: '2', Name: 'Team 2'},
      // {Id: '3', Name: 'Team 3'}
      //];

      $scope.teamData = {};
      var onTeamStandings = function (data) {
         $scope.teamData = data;
      };

      var onTeamStandingsError = function (response) {
         $scope.error = "Could not fetch the team standings";
      };

      $scope.showGridData = function ($event, team) {

         //Close the dropdown after a selection has been made
         $scope.status = {
            isopen: false
         };

         if (team === null) {
            return;
         }
         //Prevent default processing from occurring on the dropdown - this prevents any navigation from the anchor tag.
         //Another option supported by modern browsers is just to use href="" to prevent any navigation from occurring.
         //Downside of this method is manipulating the DOM from controller and thus coupling the view and Controller
         $event.preventDefault();


         bowlingService.getLeagueStandings(team.Id)
            .then(onTeamStandings, onTeamStandingsError);
         //$scope.userName = "Split Happens";
      };

      var onLeagues = function(data) {
         $scope.teams = data;
      };

      var onLeaguesError = function (response) {
         $scope.error = "Could not fetch the leagues";
      };

      bowlingService.getLeagues()
         .then(onLeagues, onLeaguesError);






      $scope.columns = [
          { field: 'Position', displayName: 'Position', width: "20%" },
          { field: 'TeamName', displayName: 'Team Name', width: "*" },
          { field: 'TotalPins', displayName: 'Total Pins', width: "20%" },
          { field: 'TotalPinsPlusHandicap', displayName: 'Total Pins + Handicap', width: "30%" }
      ];

      $scope.gridOptions = {
         data: 'teamData',
         columnDefs: 'columns'
      }

      

   };

   app.controller("TeamsController", ["$scope", "bowlingService", TeamsController]);

}());