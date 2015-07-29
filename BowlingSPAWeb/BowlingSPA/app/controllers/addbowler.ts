/// <reference path="../_refs.ts" />

module BowlingSPA.Controllers {
    'use strict';

    export interface AddBowlerScope extends ng.IScope {
        bowler: BowlingSPAService.Model.EntityModels.Bowler;
        submit(newBowler: BowlingSPAService.Model.EntityModels.Bowler): void;
        cancelAddBowler(): void;
        onAddBowlerSuccess(data: any);
        onAddBowlerError(error: any);
        error: any;
    }

    export class AddBowlerController {

        static $inject = ["$scope", "$location", "bowlingService"];

        constructor(
            $scope: AddBowlerScope,
            $location: ng.ILocationService,
            bowlingService: BowlingSPA.Services.BowlingService) {

            $scope.bowler = {
                FullName: null,
                Id: 0,
                FirstName: null,
                LastName: null,
                ModifiedDate: new Date(),
                Average: null,
                Handicap: null,
                Scores: null
            }

            $scope.submit = (newBowler: BowlingSPAService.Model.EntityModels.Bowler) => {

                //$scope.bowler.FirstName = $scope.firstName;
                //$scope.bowler.LastName = $scope.lastName;
                //$scope.bowler.Average = $scope.average;
                //$scope.bowler.Handicap = $scope.handicap;

                bowlingService.addBowler(newBowler)
                    .then($scope.onAddBowlerSuccess, $scope.onAddBowlerError);                

            }

            $scope.onAddBowlerSuccess = (data) => {
                $location.path('/bowlers');
            }

            $scope.onAddBowlerError = (error) => {
                var message = "Could not add the bowler data. ";
                $scope.error = message.concat(error);
            }


            $scope.cancelAddBowler = () => {
                $location.path('/bowlers');
            };

        }



    }

} 