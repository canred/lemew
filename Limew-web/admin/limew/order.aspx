<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="Limew.admin.limew.order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
    Ext.onReady(function () {
        WS_CUSTORDERQUERYPANEL = Ext.create('WS.CustOrderQueryPanel', {
            subWinCust: 'WS.CustWindow'
        });
        WS_CUSTORDERQUERYPANEL.render('divMain');
        UTIL.session.fnKeep();
    });
</script>			
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
</asp:Content>
