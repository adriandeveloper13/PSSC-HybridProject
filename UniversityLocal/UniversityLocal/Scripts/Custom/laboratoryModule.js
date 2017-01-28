var laboratoryModule = function () {
    function setlaboratoryPostData() {
        var postData = new Object();
        postData.Name = $("#laboratory-input-name").val();
        postData.ContentLink = $("#laboratory-input-contentLink").val();

        return postData;
    }

    function addLaboratoryPost() {
        debugger;
        var postData = setlaboratoryPostData();
        ajaxHelper.post("/StudyYear/AddLaboratory", postData, function (data) {
            commonModule.navigate("/StudyYear/AddLaboratory");
        }, function () {

        });
    }

    return {
        addLaboratoryPost: addLaboratoryPost
    };

}();