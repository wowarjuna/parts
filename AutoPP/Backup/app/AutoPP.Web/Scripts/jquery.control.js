$.fn.extend({
    bindChildOnChange: function (url, child, isMulti, callback) {
        $(this).change(function () {
            $.get(url + $(this).val(), function (data) {
                if (data.Models != null) {
                    $(child).empty();
                    if (!isMulti)
                        $(child).append('<option value="-">- Select -</option>');

                    for (var _i = 0; _i < data.Models.length; _i++) {
                        //console.log(data.Models[_i]);
                        $(child).append('<option value="' + data.Models[_i].Id + '">' + data.Models[_i].Name + '(' + data.Models[_i].ModelNo + ') - ' + data.Models[_i].From + '/' + data.Models[_i].To + '</option>');
                    }
                }
                callback();
            });
        });
    },
    bindCascadingSelect: function (url, prefix, levels) {
        $(this).change(function () {
            var _current = parseInt($(this).attr("id").substring(prefix.length));
            clearControls(prefix, levels, _current);
            if (_current != levels - 1) {
                $(this).parent().append('<select name="' + prefix + '" id="' + prefix + (_current + 1) + '"></select>');
            }
        });
        function clearControls(prefix, levels, current) {
            for (var _i = current + 1; _i < levels; _i++) {
                $('#' + prefix + _i).remove();
            }
        }
    }

});