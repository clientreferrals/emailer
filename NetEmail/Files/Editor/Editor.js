
    $(document).ready(function () {
        $('#summernote').summernote(
            {
                callbacks: {
                    onInit: function (e) {
                        $("#summernote").summernote("fullscreen.toggle");
                    }
                }
            }
        );
});

function setContent(content) {
    $(".note-editable").html(content);
}