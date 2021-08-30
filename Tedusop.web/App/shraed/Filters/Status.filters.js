(function (app) {

    app.filter('statusfilters', function () {

        return function (input) {

            if (input == true)
                return  'Kich hoạt';
            else
                return 'Khóa';

        }


    });

})(angular.module('Tedushop.common'));