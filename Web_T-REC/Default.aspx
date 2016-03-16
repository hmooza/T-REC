<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div style="background: #e9e7e7;">
        <div class="container marketing">

<%--            <style>
                .wrapper {
                    float: left;
                    clear: left;
                    display: table;
                    table-layout: fixed;
                }

                img.img-responsive {
                    display: table-cell;
                    max-width: 100%;
                }
            </style>
            <div class="wrapper col-md-3">
                <img class="img-responsive" src="https://www.google.co.uk/images/srpr/logo11w.png" />

            </div>--%>


            <!-- NEWS -->
            <div class="row">

                <style>
                    .ratio {
                        position: relative;
                        width: 100%;
                        height: 0;
                        padding-bottom: 10px;
                        background-repeat: no-repeat;
                        background-position: center center;
                        background-size: cover;
                    }
                </style>

               

                <div class="col-lg-10 col-md-10 thumb col-xs-10 thumb">

                    <div class="thumbnail">
                        <img class="ratio" src="Pic/ChangeClass1.jpg" />
                    </div>
                </div>

<%--                <div class="col-lg-10 col-md-10 thumb col-xs-10 thumb">

                    <div class="thumbnail">
                        <img class="ratio" src="Pic/ChangeClas2.png" />
                    </div>
                </div>

                <div class="col-lg-10 col-md-10 thumb col-xs-10 thumb">

                    <div class="thumbnail">
                        <img class="ratio" src="Pic/News3.png" />
                    </div>
                </div>--%>
            </div>


            <%--<h1>ประกาศ !!! กำลังอัพเดทระบบ</h1>--%>
            <h1>Update ระบบ</h1>


            <%--<h2 style="padding-top: 60px;"></h2>--%>
            <h3>T-REC  System</h3>
            <div>  </div>
             <div>TEST</div>

            <br />
        </div>
    </div>


    <div class="well well-large">
        Developer by DaoSCAAT , daoscaat@gmail.com Tel.098-2654323 Mint
        <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
    </div>

    <div id="div222"></div>
    

    <%--<div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">Panel title</h3>
        </div>
        <div class="panel-body">
            Panel content&nbsp; Default
        </div>
        <div class="panel-footer">
            <asp:Button ID="Button1" runat="server" Text="Button" class="btn btn-primary" />
            <asp:Button ID="Button2" runat="server" Text="Button" class="btn btn-danger" />
        </div>
    </div>--%>

    <%--<div class="container">
        <div class="row">
            <div class='col-sm-6'>
                <div class="form-group">
                    <div class='input-group date' id='datetimepicker5'>
                        <input type='text' class="form-control" data-date-format="YYYY/MM/DD" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
            </div>
            <script type="text/javascript">
                $(function () {
                    $('#datetimepicker5').datetimepicker({
                        pickTime: false
                    });
                });
            </script>
        </div>
    </div>--%>


    <%-- <div class="date-form">

        <div class="form-horizontal">
            <div class="control-group">
                <label for="date-picker-1" class="control-label">
                    A <span class="glyphicon glyphicon-calendar"></span>

                </label>
                <div class="controls">
                    <input id="date-picker-1" type="text" class="date-picker form-control" />
                </div>
            </div>
            <div class="control-group">
                <label for="date-picker-2" class="control-label">B</label>
                <div class="controls">
                    <div class="input-group">
                        <input id="date-picker-2" type="text" class="date-picker form-control" />
                        <label for="date-picker-2" class="input-group-addon btn">
                            <span class="glyphicon glyphicon-calendar"></span>

                        </label>
                    </div>
                </div>
            </div>
            <div class="control-group">
                <label for="date-picker-3" class="control-label">C</label>
                <div class="controls">
                    <div class="input-group">
                        <label for="date-picker-3" class="input-group-addon btn">
                            <span class="glyphicon glyphicon-calendar"></span>

                        </label>
                        <input id="date-picker-3" type="text" class="date-picker form-control" />
                    </div>
                </div>
            </div>
        </div>

        <hr />
        <div>
            <span id="msg" class="controls form-control uneditable-input"></span>
        </div>
    </div>

    <script type="text/javascript">
        $(".date-picker").datepicker();

        $(".date-picker").on("change", function () {
            var id = $(this).attr("id");
            var val = $("label[for='" + id + "']").text();
            $("#msg").text(val + " changed");
        });

    </script>--%>


    <%--  <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Select date</h3>
            </div>
            <div class="panel-body">
                <div class="input-append date" id="datepick" data-date="22-05-2014" data-date-format="dd-mm-yyyy">
                    <input class="span2" size="16" type="text" value="22-05-2014">
                    <span class="add-on"><i class="icon-calendar"></i></span>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $('#datepick').datepicker({
                format: "yyyy/mm/dd",
                autoclose: true,
                todayHighlight: true
            });
        });

    </script>--%>


    <%--    <asp:TextBox runat="server" ID="Text" />
    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="Server" BehaviorID="Calendar" TargetControlID="Text" />
    <asp:Button runat="server" ID="Button" OnClientClick="return false;" />

  
    <script type="text/javascript">

        // (c) Copyright Microsoft Corporation.
        // This source is subject to the Microsoft Permissive License.
        // See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
        // All other rights reserved.

        // Script objects that should be loaded before we run
        var typeDependencies = ['AjaxControlToolkit.CalendarBehavior'];

        function registerTests(harness) {
            var text = harness.getElement('ctl00_ContentPlaceHolder1_Text');
            var calendar = harness.getObject('Calendar');
            var button = harness.getElement('ctl00_ContentPlaceHolder1_Button');
            var test = null;

            test = harness.addTest('Show on focus');
            test.addStep(function () {
                harness.fireEvent(text, "onfocus");
                harness.assertTrue(calendar._isOpen);
            });

            test = harness.addTest('Hide on blur');
            test.addStep(function () {
                harness.fireEvent(text, "onfocus");
                harness.fireEvent(text, "onblur");
            }, 100, function () { return !calendar._isOpen; });

            test = harness.addTest('Parse date');
            test.addStep(function () {
                text.value = '15-1-2000';
                harness.fireEvent(text, "onfocus");
                harness.fireEvent(text, 'onchange');
                harness.assertEqual('15-1-2000', calendar.get_selectedDate().format("d-M-yyyy"));
            });

            //            test = harness.addTest('Pick date');
            //            test.addStep(function() {
            //                calendar.set_visibleDate(new Date('1/1/2000'));
            //                calendar.show();
            //                harness.fireEvent(calendar._daysBody.rows[0].cells[6], "click");
            //                harness.assertEqual('1/1/2000', text.value);
            //            });

            test = harness.addTest('set_firstDayOfWeek typo');
            test.addStep(function () {
                calendar.set_firstDayOfWeek(AjaxControlToolkit.FirstDayOfWeek.Default);
            });
        }

    </script>--%>
</asp:Content>

