<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="money.aspx.cs" Inherits="Limew.admin.limew.money" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
    Ext.onReady(function () {
        WS_CUSTORDERQUERYPANEL = Ext.create('WS.CustOrderQueryPanel', {
            subWinCustOrder: 'WS.CustOrderWindow'
        });
        WS_CUSTORDERQUERYPANEL.render('divMain');
        UTIL.runAll();
    });
</script>			
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
</asp:Content>
