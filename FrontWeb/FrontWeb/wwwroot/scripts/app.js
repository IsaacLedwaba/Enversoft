var supplierApp = angular.module('supplierApp', [])

.controller('SupplierController', function ($scope, $http, $window) {

    function init() {

        $http.get('http://localhost:22068/supplier').then(function (response) {
            $scope.suppliers = response.data;
        });
    }

    $scope.addSupplier = function () {
        $scope.hideSupplier = true;
    }

    $scope.createSupplier = function () {

        var supplier = {};
        supplier.Code = $scope.supplierCode;
        supplier.Name = $scope.supplierName;
        supplier.TelephoneNo = $scope.supplierTelephone;

        $http.post('http://localhost:22068/supplier', JSON.stringify(supplier));

        $window.location.reload();
    }

    init();
});