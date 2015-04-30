<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="goodsRecordExpand.aspx.cs" Inherits="Limew.admin.limew.goodsRecordExpand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
    Ext.onReady(function () {
        WS_MYORDEREXPANDQUERYPANEL = Ext.create('WS.MyOrderExpandQueryPanel', {
            subWinMyOrder: 'WS.MyOrderWindow'
        });
        WS_MYORDEREXPANDQUERYPANEL.render('divMain');
        UTIL.runAll();
    });
</script>			
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
</asp:Content>
