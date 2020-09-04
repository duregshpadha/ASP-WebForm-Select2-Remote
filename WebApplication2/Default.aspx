<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
        <div class="col-sm-4">
            <select id="select2Input" class="w-100"></select>
        </div>
    </div>




    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js"
        integrity="sha512-bLT0Qm9VnAYZDflyKcBaQ2gg0hSYNQrJ8RilYldYQ1FxQYoCLtUjuuRuZo+fjqhx/qtq/1itJ0C2ejDxltZVFg==" crossorigin="anonymous"></script>
    <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-beta.1/dist/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-beta.1/dist/js/select2.min.js"></script>
    <script>

        $(function () {
            $('#select2Input').select2({
                placeholder: "Search for...",
                ajax: {
                    url: '<%= ResolveUrl("~/Default.aspx/GetSelecct2List") %>',
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    global: false,
                    data: function (params) {
                        var query = {
                            title: params.term || "",
                            pageNumber: params.page || 1,
                            pageSize: 10,
                        };
                        return JSON.stringify(query);
                    },
                    processResults: function (data, params) {
                        console.log(JSON.parse(data.d));
                        return JSON.parse(data.d);
                    }
                }
            });
        })
    </script>
</asp:Content>
