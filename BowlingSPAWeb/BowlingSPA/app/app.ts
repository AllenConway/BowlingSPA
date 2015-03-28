/// <reference path="_refs.ts" />

module BowlingSPA {
    'use strict';

    //Declare a new Angular Module named 'BowlingSPA' for use throughout the app
    //The module is the component that ties all of the other Angular application components together.
    export var app: ng.IModule = angular.module("BowlingSPA", ["ngRoute", "ngGrid", "ui.bootstrap"]);

    //Use inline annotated function; JS doesn't have annotations needed for DI, so annotate function with injection arguments
    //Use array of injection names, where the last item in the array is a function to call
    //Because JavaScript has no syntax for declaring the type of a variable, we must specify the data type. See: https://docs.angularjs.org/api/auto/service/$injector
    app.config([
        '$routeProvider', '$httpProvider',
        ($routeProvider: ng.route.IRouteProvider, $httpProvider: ng.IHttpProvider) => {

            // enable CORS on IE <= 9
            //Default behavior since v1.1.1 (http://bit.ly/1t7Vcci)
            delete $httpProvider.defaults.headers.common['X-Requested-With'];

            $routeProvider
                .when("/landing", {
                    templateUrl: "app/partials/landing.html",  //relative path to the .html partial
                    controller: "LandingController" //name of controller variable not the file
                })
                .when("/teams", {
                    templateUrl: "app/partials/teams.html",
                    controller: "TeamsController"
                })
                .when("/bowlers", {
                    templateUrl: "app/partials/bowlers.html",
                    controller: BowlingSPA.Controllers.BowlersController
                })
                .otherwise({ redirectTo: "/landing" });
        }
    ]);

}