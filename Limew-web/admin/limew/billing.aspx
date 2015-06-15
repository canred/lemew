<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="billing.aspx.cs" Inherits="Limew.admin.limew.billing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
    Ext.onReady(function () {
        WS_CUSTQUERYPANEL = Ext.create('WS.BillingQueryPanel', {
            subWinBilling: 'WS.BillingWindow'
        });
        WS_CUSTQUERYPANEL.render('divMain');
        UTIL.runAll();
    });
</script>			
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
</asp:Content>
