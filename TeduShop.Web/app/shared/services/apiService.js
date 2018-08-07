(function (app) {
    app.service('apiService', apiService);
    apiService.$inject = ['$http'];
    function apiService($http) {
        return {
            get: get
        }

        function get(url, params, success, failded) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failded(error);
            });
        }
    }
})(angular.module('tedushop.common'));