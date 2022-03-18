angular.module("umbraco.resources")
    .factory("testEditorService", function ($http, $cookies) {
        return {
            getAllTestEditors: function () {
                return $http.get("/umbraco/api/Backofficeapi/GetAll");
            }
        }
    });