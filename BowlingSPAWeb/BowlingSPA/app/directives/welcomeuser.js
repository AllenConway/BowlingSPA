/// <reference path="../_refs.ts" />
var BowlingSPA;
(function (BowlingSPA) {
    var Directives;
    (function (Directives) {
        'use strict';
        BowlingSPA.app.directive('welcomeUser', function () {
            return {
                restrict: 'E',
                template: '<h4>Hello: {{name}}</h4>',
                link: function (scope, element, attr) {
                    scope.name = attr.name;
                }
            };
        });
    })(Directives = BowlingSPA.Directives || (BowlingSPA.Directives = {}));
})(BowlingSPA || (BowlingSPA = {}));
//# sourceMappingURL=welcomeuser.js.map