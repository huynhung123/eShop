(function (app) {

    app.factory('authData', authData)
    authData.$inject=['$scope']
    function authData($scope) {

        var authDataFactory = {};

        var authentication = {
            IsAuthenticated: false,
            userName: ""
        };
        authDataFactory.authenticationData = authentication;
        return authDataFactory;
    }
    
})(angular.module('Tedushop.common'));