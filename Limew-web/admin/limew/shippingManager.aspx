<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="shippingManager.aspx.cs" Inherits="Limew.admin.limew.shippingManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
    Ext.onReady(function () {
        WS_CUSTORDERSHIPPINGQUERYPANEL = Ext.create('WS.CustOrderShippingQueryPanel', {
            subWinCustOrder: 'WS.CustOrderStep1ViewWindow'
        });
        WS_CUSTORDERSHIPPINGQUERYPANEL.render('divMain');
        UTIL.runAll();
    });
</script>			
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
</asp:Content>
