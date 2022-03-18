angular.module("umbraco")
    .controller("TestEditorController",
        function ($scope, testEditorService, localizationService) {
            var vm = this;

            if (!Array.isArray($scope.model.value) || $scope.model.value === null || $scope.model.value === undefined) {
                $scope.model.value = [];
            }

            vm.selectedValues = [];

            /*localizationService.localize("courseCategoryPicker_courseCategoryLabel").then(data => {
                vm.courseCategoryLabel = data;
            });*/

            testEditorService.getAllTestEditors().then(response => {
                vm.testEditors = response.data;

                if ($scope.model.value) {
                    vm.selectedValues = [];

                    for (let i = 0; i < $scope.model.value.length; i++) {
                        vm.selectedValues[i] = vm.testEditors.find(c => c.id == $scope.model.value[i].id);
                    }
                }
            });

            vm.add = function () {
                vm.selectedValues.push({});
                $scope.model.value.push({});
            }

            vm.remove = function (index) {
                vm.selectedValues.splice(index, 1);
                $scope.model.value.splice(index, 1);
            }

            vm.selectedValuesChange = function (index) {
                if ($scope.model.value[index]) {
                    $scope.model.value[index] = { id: vm.selectedValues[index].id };
                } else {
                    $scope.model.value.push({ id: vm.selectedValues[index].id });
                }
            }
        });