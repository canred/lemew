<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="attendant.aspx.cs" Inherits="Web.admin.basic.attendant"  EnableViewState="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
Ext.onReady(function() {    
    /*實例化人員編輯的物件*/    
    WS_ATTENDANTQUERYPANEL = Ext.create('WS.AttendantQueryPanel',{
        param:{
            companyUuid:'<%= getUser().COMPANY_UUID %>'
        },
        /*將實例化的人員編輯物件傳入*/
        'subWinAttendant':'WS.AttendantWindow'
    });

    WS_ATTENDANTQUERYPANEL.render('divMain');
});
</script>			
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
<!-- 使用者session的檢查操作，當逾期時自動轉頁至登入頁面 -->
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/keeySession.js")%>'></script>           
</asp:Content>