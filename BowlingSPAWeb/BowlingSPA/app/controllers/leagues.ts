/// <reference path="../_refs.ts" />

module BowlingSPA.Controllers {
    'use strict';

    export interface LeaguesScope extends ng.IScope {
        
    }

    export class LeaguesController {
        
        static $inject = ["$scope", "$location", "bowlingService"];

        constructor(
            $scope: LeaguesScope,
            $location: ng.ILocationService,
            $bolwingService: BowlingSPA.Services.BowlingService) {
            
        }

    }

} 