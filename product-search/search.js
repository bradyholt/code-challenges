function SearchCtrl($scope, $http) {
    $scope.error = null;
    $scope.searchText = '';
    $scope.searching = false;
    $scope.title = 'Top Sellers';
    $scope.predicate = '-price';
    $scope.searchCount = 0;

    $scope.search = function () {
        $scope.searching = true;
        $http({ method: 'GET', url: '/products/search', params: { searchText: $scope.searchText }, timeout: 5000 }).
          success(function (data, status, headers, config) {
              $scope.searching = false;
              $scope.error = false;
              $scope.products = data;
              $scope.searchCount++;
              $scope.title = $scope.searchText.length > 0 ? "Search Results" : "Top Sellers";
          }).
          error(function (data, status, headers, config) {
              $scope.searching = false;
              $scope.error = true;
              $scope.products = [];
              console.log(data);
          });
    };

    $scope.search($scope.searchText);
}

$(function () {
    $('#searchText').keydown(function (e) {
        if (e.keyCode == 13) {
            //call search on 'Enter' key inside search text box
            angular.element('#products').scope().search();
        }
    });
});