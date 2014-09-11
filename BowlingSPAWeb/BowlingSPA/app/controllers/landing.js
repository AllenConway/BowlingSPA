//IFFY Immediately Invoked Function Expression
(function () {

   //Find existing Module instance named 'BowlingSPA'
   var app = angular.module("BowlingSPA");

   var LandingController = function ($scope) {

      $scope.userName = "allen";

      //$scope.tabs = [
      //  { title: "Home", href: "#" },
      //  { title: "Teams", href: "#/teams" },
      //  { title: "Players", href: "#/players" }
      //];

      //$scope.changeHash = function (data) {
      //   if (data == null) {
      //      return;
      //   }
      //   window.location.hash = data;
      //};

   };

   //Register this controller with the app module. That way the html can find the controller without 
   //needing to put the controller function in the global namespace of the application.
   //Note: To prevent the minification process from shortening the parameter names, explicitly provide
   //list of parameter names as strings as the second parameter to the controller registration
   app.controller("LandingController", ["$scope", LandingController]);

}());