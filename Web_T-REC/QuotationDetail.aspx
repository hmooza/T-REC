<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="QuotationDetail.aspx.cs" Inherits="Web_T_REC.QuotationDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divwarning" class="alert alert-warning" role="alert" runat="server" visible="false">
        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
        <span class="sr-only">warning:</span>
        <asp:Label ID="lblmsgs" runat="server" Text="ไม่ได้รับอนุญาติให้เข้าถึงหน้านี้"></asp:Label>
    </div>

    <div class="panel panel-primary" id="divcontent" runat="server">
        <div class="panel-heading">
            <h3 class="panel-title">Equipment Detail</h3>
        </div>

        <div class="panel-body">
            <div class="well">
                <%--ID--%>
                <asp:HiddenField runat="server" ID="hdnQuotationID" />

                <%--<div class="form-horizontal" role="form">
                    <div class="form-group">
                        <label class="control-label col-md-3" for="txtNo">No.</label>
                        <div class="col-md-7 offset-2">
                            <asp:TextBox ID="txtNo" runat="server" type="text" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>--%>
                <div class="row">
                    <div class="form-horizontal">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label col-md-1" for="txtNo">No.</label>
                                <div class="col-md-3 offset-8">
                                    <asp:TextBox ID="txtNo" runat="server" type="text" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="well">
                <div class="row">
                    <div class="form-horizontal">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label col-md-3" for="txtQty">Qty</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="txtQty" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label col-md-3" for="txtDays">Days</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="txtDays" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3" for="txtEquipment">อุปกรณ์</label>
                                <div class="col-md-9">
                                    <asp:DropDownList runat="server" ID="ddlEquipment" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="row">
                    <div class="form-horizontal">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label col-md-3" for="txtPrice">ราคา</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="txtPrice" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label col-md-3" for="txtDiscount">ส่วนลด%</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="txtDiscount" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label col-md-3" for="txtDiscount_display">ส่วนลด</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="txtDiscount_display" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <asp:Button runat="server" ID="btnAdd" Text="OK" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>

            </div>

            <div style="padding-top: 10px;">
                <ul class="nav nav-tabs">
                    <li class="active"><a data-toggle="tab" href="#camera">กล้อง</a></li>
                    <li><a data-toggle="tab" href="#sound">เสียง</a></li>
                </ul>

                <div class="tab-content">
                    <div id="camera" class="tab-pane fade in active">
                        <h3>กล้อง</h3>
                        
                    </div>
                    <div id="sound" class="tab-pane fade">
                        <h3>เสียง</h3>
                        
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
