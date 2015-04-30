<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="reportOrder.aspx.cs" Inherits="Limew.admin.limew.reportOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
    Ext.onReady(function () {
        WS_REPORTORDERQUERYPANEL = Ext.create('WS.ReportOrderQueryPanel', {
            subWinCustOrder: 'WS.CustOrderStep1ViewWindow'
        });
        WS_REPORTORDERQUERYPANEL.render('divMain');
        UTIL.runAll();
    });
</script>			
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
</asp:Content>
