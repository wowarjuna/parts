$(function() {
    $('#fileupload').fileupload({
        submit: function (e, data) {
            var $this = $(this);
            $.getJSON('/api/items/uploadimages', function (result) {
                data.formData = result; // e.g. {id: 123}
                data.jqXHR = $this.fileupload('send', data);
            });
            return false;
        }
    });
});