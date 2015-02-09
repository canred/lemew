﻿<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Limew.Default" EnableViewState="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Div1" style="float:left;margin-bottom:5px;margin-top:5px;">    
    <div id="systemInfo" style="margin-bottom:5px;margin-top:5px;"></div>
</div>
<script type="text/javascript">
Ext.onReady(function() {
    /*初始化登入物件*/  
    WS_LOGONPANEL = Ext.create('WS.LogonPanel',{
        /*值擴展*/
        val:{
            company:'<%= getCompany() %>',
            account:'<%= getAccount() %>',
            password:'<%= getPassword() %>'
        }
    });      
    /*設定登入物件的相關參數*/
    WS_LOGONPANEL.urlSuccess = '<%= Page.ResolveUrl(Limew.Parameter.Config.ParemterConfigs.GetConfig().DefaultPage)%>';
    WS_LOGONPANEL.urlFail = '<%= Page.ResolveUrl(Limew.Parameter.Config.ParemterConfigs.GetConfig().NoPermissionPage)%>';
    WS_LOGONPANEL.down('#ExtLogonForm').title = '<img src="' + SYSTEM_ROOT_PATH + '/css/custimages/login.gif" style="height:16px;margin-bottom:4px;margin-right:10px;" align="middle"><%= Limew.Parameter.Config.ParemterConfigs.GetConfig().SystemName%>';
    /*物件輸出到畫面上*/
    WS_LOGONPANEL.render('logon');    
});
</script>
<table width="100%">
    <tr>
        <td width="30%"></td>
        <td width="40%" >
        <div id="logon" style="margin-bottom:5px;margin-top:5px;width:2"></div>
        </td>
        <td width="30%"></td>
    </tr>
</table>                       
</asp:Content>
