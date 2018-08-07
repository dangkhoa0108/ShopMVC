/// <reference path="../../../assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('tedushop.mydemo', ['tedushop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('mydemo',
            {
                url: '/mydemo',
                templateUrl: '/app/components/mydemo/mydemoView.html',
                controller: 'mydemoListController'
            });
    }
})();