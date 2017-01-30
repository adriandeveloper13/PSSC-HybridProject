var courseModule = function() {
    function setCoursePostData() {
        var postData = new Object();
        postData.Name = $("#course-input-name").val();
        postData.ContentLink = $("#course-input-contentLink").val();

        return postData;
    }

    function addCoursePost() {
        debugger;
        var postData = setCoursePostData();
        ajaxHelper.post("/StudyYear/AddCourse", postData, function (data) {
            commonModule.navigate("/StudyYear/GetAllCourses");
        }, function () {

        });
    }

    return {
        addCoursePost: addCoursePost
    };

}();