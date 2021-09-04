﻿/// <reference path="../../../assets/admin/libs/angular.js/angular.js" />


(function (app) {
    app.factory('apiService', apiService);
    apiService.$inject = ['$http', 'notificationService'];

    function apiService($http, notificationService) {
        return {
            get: get,
            post: post
        }
        //them moi san pham
                
            function post(url, data, success, failure) {
                $http.post(url, data).then(function (result) {
                    success(result);
                }, function (error) {
                    console.log(error.status)
                    if (error.status === 401) {
                        notificationService.displayError('Authenticate is required.');
                    }
                    else if (failure != null) {
                        failure(error);
                    }

                });
            }


            // Get sn pham ra
            function get(url, params, success, failure) {

                $http.get(url, params).then(function (result) {

                    success(result);


                }, function (error) {

                    failure(error);

                });

            }
        }

    }) (angular.module('Tedushop.common'));