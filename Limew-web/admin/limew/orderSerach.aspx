﻿<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="orderSerach.aspx.cs" Inherits="Limew.admin.limew.orderSerach" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
    Ext.onReady(function () {
        WS_ORDERSEARCHQUERYPANEL = Ext.create('WS.OrderSearchQueryPanel', {
            subWinCustOrder: 'WS.CustOrderStep1ViewWindow'
        });
        WS_ORDERSEARCHQUERYPANEL.render('divMain');
        UTIL.runAll();
    });
</script>			
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
</asp:Content>