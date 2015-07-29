//IFFY Immediately Invoked Function Expression
(function () {

   //Find existing Module instance named 'BowlingSPA'
   var app = angular.module("BowlingSPA");

   var LandingController = function ($scope) {

      $scope.userName = "Allen";

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

   app.controller("LandingController", ["$scope", LandingController]);

}());