@using AutoPP.Web.Controllers.Helpers
<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
   
    <link href="@Url.Content("~/Content/styles.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/css/demo_table.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/css/demo_page.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/css/jquery-ui-1.8.16.custom.css")" rel="stylesheet" type="text/css" />
    <script src="@Url.Content("~/Scripts/jquery-1.4.4.min.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jquery-ui.min.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/rx.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/rx.html.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/rx.jQuery.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jquery-ui.min.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jquery.dataTables.min.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jquery.dataTablesExt.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jquery.control.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/MicrosoftAjax.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/MicrosoftMvcValidation.js")" type="text/javascript"></script>
</head>
<body>
    <div id="wrapper">
        <div id="header">
            <div class="logo">
            </div>
            <div class="headerInfo">
                @Html.Partial("_LogOnPartial")
            </div>
            <div class="clear">
            </div>
            <div class="topbar">
            </div>
        </div>
        <div id="body">
            @RenderBody()
            <div class="clear">
            </div>
        </div>
        <div id="footer">
            <span>Colombo Parts &copy; 2012</span> <span><a href="#">Terms and Conditions</a></span>
            <span><a href="#">Contact Us</a></span>
        </div>
    </div>
    
</body>
</html>
