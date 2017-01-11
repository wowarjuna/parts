
var rules = {
    Name: {
        required: true
    },
    Year: {
        required: true
    },
    Qty: {
        required: true
    }
}

var submitHandler = function (form) {
    var data = {
        Id: $('#Id').val(),
        Name: $('#Name').val(),
        PartNo: $('#PartNo').val(),
        Year: $('#Year').val(),
        BrandId: $('#BrandId').val(),
        ModelId: $('#ModelId').val(),
        CategoryId: $('#CategoryId').val(),
        Description: $('#Description').val(),
        StoreInfo: $('#StoreInfo').val(),
        Qty: $('#Qty').val(),
        QuotedPrice: numeral().unformat($('#QuotedPrice').val()),
        Active: $('#Active').prop('checked'),
        BasketId: $('#BasketId').val(),
        StocklotId: $('#StocklotId').val()
    };

    $.post('/api/items', data).done(function (data) {
        $('.message-area').showInfo('Successfully updated');
    }, 'json').fail(function (jqXHR, textStatus, err) {
        $('.message-area').showError(err);
    });
    return false;
}


var on_brand_changed = function () {
    $.getJSON('/api/models/bybrand/' + $(this).val())
       .done(function (data) {
           $('#ModelId').empty();
           $('#ModelId').append($('<option>').text('- Select -').attr('value', 0));
           $.each(data, function (i, value) {
               $('#ModelId').append($('<option>').text(value.Name).attr('value', value.Id));
           });
       })
       .fail(function (jqXHR, textStatus, err) {
           alert(err);
       });
}

function on_image_preview() {

}

$(function () {

    $('.currency').maskMoney();

    $('#BrandId').change(on_brand_changed);

    $('#edit-item').validate({
        rules: rules,
        highlight: function (element) {
            $(element).closest('.input-group-sm').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.input-group-sm').removeClass('has-error');
        },
        errorElement: 'span',
        errorClass: 'help-block',
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        },
        submitHandler: submitHandler
    });

    


    $.getJSON('/store/item/getitemimages/' + $('#Id').val())
      .done(function (data) {
          var previewData = new Array();
          var configData = new Array();

          $(data).each(function (idx, obj) {
              previewData.push('<img width="150"  src="' + obj.url + '" class="file-preview-image" alt="' + obj.caption + '" title="' + obj.caption + '"/>');
              configData.push({ caption: obj.caption, width: '120px', url: '/store/item/deleteitemimage/', key: obj.id })
          });

          $("input[type='file']").fileinput({
              initialPreview: previewData,
              overwriteInitial: false,
              uploadExtraData: function () {
                  return { Id: $('#Id').val() }
              },
              initialPreviewConfig: configData

          });

          $('.file-preview-image').click(function () {
              $.magnificPopup.open({
                  items: {
                      src: $(this).attr('src')
                  },
                  type: 'image'
              });
          });
      })
      .fail(function (jqXHR, textStatus, err) {
          alert(err);
      });



});