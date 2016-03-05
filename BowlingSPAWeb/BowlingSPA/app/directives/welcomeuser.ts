/// <reference path="../_refs.ts" />
module BowlingSPA.Directives {
    'use strict';

    BowlingSPA.app.directive('welcomeUser', () => {
        return {
            restrict: 'E', //E = element, A = attribute, C = class, M = comment 
            template: '<h4>Hello: {{name}}</h4>',
            link: (scope, element: any, attr: any) => {
                scope.name = attr.name;
            }
        };
    });
}