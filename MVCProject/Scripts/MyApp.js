var app = angular.module('MyApp', []);

app.controller('TodoController', function ($scope, $http) {

    //get all TodoList
    $http.get('/Todo/GetTodoList')
    .success(function (result) {
        $scope.todolists = result;
    })
    .error(function (data) {
        console.log(data);
    });

    //get StatusType from Status
    $http.get('/Todo/GetStatusType')
    .success(function (result) {
        $scope.StatusTypes = result;
    })
    .error(function (data) {
        console.log(data);
    });

    $scope.task = {
        Id: "",
        Content: "",
        StatusId: "",
        Progress: ""
    };

    //add a task
    $scope.addTask = function () {
        $http.post('/Todo/AddTask', { task: $scope.task })
        .success(function (result) {
            $scope.todolists = result;
            $scope.task.Id = "";
            $scope.task.Content = "";
            $scope.task.StatusId = "";
            $scope.task.Progress = "";
        })
        .error(function (data) {
            console.log(data);
        });
    };

    //edit a task
    $scope.editTask = function (objTask) {
        $scope.task.Id = objTask.Id;
        $scope.task.Content = objTask.Content;
        $scope.task.StatusId = objTask.StatusId;
        $scope.task.Progress = objTask.Progress;
    };

    //update a task
    $scope.updateTask = function (objTask) {
        $http.post('/Todo/updateTask', { task: objTask })
        .success(function (result) {
            $scope.todolists = result;
            $scope.task.Id = "";
            $scope.task.Content = "";
            $scope.task.StatusId = "";
            $scope.task.Progress = "";

        })
        .error(function (data) {
            console.log(data);
        });
    };

    //delete a task
    $scope.deleteTask = function (objTask) {
        $http.post('/Todo/deleteTask', { task: objTask })
        .success(function (result) {
            $scope.todolists = result;
            $scope.task.Id = "";
            $scope.task.Content = "";
            $scope.task.StatusId = "";
            $scope.task.Progress = "";
        })
        .error(function (data) {
            console.log(data);
        });
    };

    //
    $scope.statusChange = function (objId) {
        console.log("--- statusChance ---");
        console.log(objId);
        if (objId == 4)
        {
        }
    };
});
