<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Limew.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Div1" style="float:left;margin-bottom:5px;margin-top:5px;">    
    <div id="systemInfo" style="margin-bottom:5px;margin-top:5px;"></div>
</div>
<style>
.btn1 {
  /*客戶*/
    width:160px!important; height:160px!important;
    background-image: url('./css/custimages/customer160x160.png') !important;     
}

.btn2 {
  /*供應商*/
    width:160px!important; height:160px!important;
    background-image: url('./css/custimages/supplier160x160.png') !important; 
}

.btn3 {
  /*商品*/
    width:160px!important; height:160px!important;
    background-image: url('./css/custimages/product160x160.png') !important; 
}

.btn4 {
  /*訂單*/
    width:160px!important; height:160px!important;
    background-image: url('./css/custimages/order160x160.png') !important; 
}

.btn5 {
  /*款項*/
    width:160px!important; height:160px!important;
    background-image: url('./css/custimages/money160x160.png') !important; 
}

.btn6 {
  /*出貨*/
    width:160px!important; height:160px!important;
    background-image: url('./css/custimages/shipping160x160.png') !important; 
}
.btn7 {
    width:160px!important; height:160px!important;
    background-image: url('./css/custimages/report160x160.png') !important; 
}

.btn11 {
    width:160px!important; height:160px!important;
    background-image: url('./css/custimages/unknow160x160.png') !important; 
}
</style>
<script language="javascript" type="text/javascript">
    var allMenu = '<%=this.getDrsAuthortyMenuV()%>';
    Ext.onReady(function () {        
        /*
        客戶
        供應商
        商品
        訂單
        出貨
        款項        
        */
        var allIconButton = Array();
        if (allMenu.indexOf('客戶') != -1) {
            allIconButton.push({
                xtype: 'button',                
                text: '',
                cls: 'btn1',
                border:false,
                style:{
                  backgroundColor:'white'
                },
                margin: '10 10 0 10',
                handler: function (handler, scope) {
                    window.location.href = './admin/limew/cust.aspx';
                }
            });
        };

        if (allMenu.indexOf('供應商') != -1) {
            allIconButton.push({
                xtype: 'button',
                text: '',
                cls: 'btn2',border:false,
                style:{
                  backgroundColor:'white'
                },
                margin: '10 10 0 10',
                handler: function (handler, scope) {
                    window.location.href = './admin/limew/supplier.aspx';
                }
            });
        };

        if (allMenu.indexOf('商品') != -1) {
            allIconButton.push({
                xtype: 'button',
                text: '',
                cls: 'btn3',
                margin: '10 10 0 10',border:false,
                style:{
                  backgroundColor:'white'
                },
                handler: function (handler, scope) {
                    window.location.href = './admin/limew/goods.aspx';
                }
            });
        };

        if (allMenu.indexOf('訂單') != -1) {
            allIconButton.push({
                xtype: 'button',
                text: '',
                cls: 'btn4',
                margin: '10 10 0 10',border:false,
                style:{
                  backgroundColor:'white'
                },
                handler: function (handler, scope) {
                    window.location.href = './admin/limew/order.aspx';
                }
            });
        };

        if (allMenu.indexOf('出貨') != -1) {
            allIconButton.push({
                xtype: 'button',
                text: '',
                cls: 'btn6',
                margin: '10 10 0 10',border:false,
                style:{
                  backgroundColor:'white'
                },
                handler: function (handler, scope) {
                    window.location.href = './admin/limew/shippingManager.aspx';
                }
            });
        };

        if (allMenu.indexOf('款項') != -1) {
            allIconButton.push({
                xtype: 'button',
                text: '',
                cls: 'btn5',
                margin: '10 10 0 10',border:false,
                style:{
                  backgroundColor:'white'
                },
                handler: function (handler, scope) {
                    window.location.href = './admin/limew/money.aspx';
                }
            });
        };

        var line = Math.floor(allIconButton.length / 3)+1;
        var allContainer = Array();
        for (var i = 1 ; i <= line ; i++) {
            var items = Array();
            var i1 = allIconButton.shift();
            var i2 = allIconButton.shift();
            var i3 = allIconButton.shift();
            if(i1!=undefined)
                items.push(i1);

            if (i2 != undefined)
                items.push(i2);

            if (i2 != undefined)
                items.push(i3);
            allContainer.push({
                xtype: 'container',
                layout: {
                    type: 'hbox',
                    align: 'center',
                    pack: 'center'
                },
                items:items
            });
        }
        

       	Ext.define('LimewPanel', {
       	    extend: 'Ext.panel.Panel',
       	    height:$(this).height()*.8,
       	    width:$(this).width()*.9,
       	    closeAction: 'destroy',
       	    border:false,
       	    initComponent: function() {
       	        this.items = allContainer;
       	        this.callParent(arguments);
       	    }
       	});
       	var main = Ext.create('LimewPanel',{});
        main.render('divMain');
        UTIL.session.fnKeep();
    });
</script>		
<center>	
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
</center>              
</asp:Content>
