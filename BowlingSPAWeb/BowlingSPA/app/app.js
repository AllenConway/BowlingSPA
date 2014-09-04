//IFFY Immediately Invoked Function Expression
(function () {

   //Declare a new Angular Module named 'BowlingSPA' for use throughout the app
   var app = angular.module("BowlingSPA", ["ngRoute", "ngGrid", "ui.bootstrap"]);

   app.config(function ($routeProvider, $httpProvider) {

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
         .when("/players", {
            templateUrl: "app/partials/players.html",
            controller: "PlayersController"
         })
         .otherwise({ redirectTo: "/landing" });
   });


}());

