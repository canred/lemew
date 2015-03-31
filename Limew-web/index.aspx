<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Limew.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Div1" style="float:left;margin-bottom:5px;margin-top:5px;">    
    <div id="systemInfo" style="margin-bottom:5px;margin-top:5px;"></div>
</div>
<style>
.btn1 {
    width:160px!important; height:160px!important;
    background-image: url('./css/custimages/customer160x160.png') !important; 
}

.btn2 {
    width:160px!important; height:160px!important;
    background-image: url('./css/custimages/supplier160x160.png') !important; 
}

.btn3 {
    width:160px!important; height:160px!important;
    background-image: url('./css/custimages/product160x160.png') !important; 
}

.btn4 {
    width:160px!important; height:160px!important;
    background-image: url('./css/custimages/order160x160.png') !important; 
}

.btn5 {
    width:160px!important; height:160px!important;
    background-image: url('./css/custimages/money160x160.png') !important; 
}

.btn6 {
    width:160px!important; height:160px!important;
    background-image: url('./css/custimages/truck160x160.png') !important; 
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
    Ext.onReady(function () {
       	Ext.define('LimewPanel', {
       	    extend: 'Ext.panel.Panel',
       	    height:$(this).height()*.8,
       	    width:$(this).width()*.9,
       	    closeAction: 'destroy',
       	    border:false,
       	    initComponent: function() {
       	        this.items = [{
       	        	xtype : 'container',
       	        	layout : {
       	        		type : 'hbox',      
       	        		align : 'center' , 
       	        		pack : 'center'     
       	        	},
       	        	items : [{
       	        		xtype:'button',
       	        		text:'',
       	        		cls:'btn1',
       	        		margin:'10 10 0 10',
       	        		handler:function(handler,scope){
       	        			window.location.href = './admin/limew/cust.aspx';
       	        		}
       	        	},{
       	        		xtype:'button',
       	        		text:'',
       	        		margin:'10 10 0 10',
       	        		cls:'btn2',
       	        		handler:function(handler,scope){
       	        			window.location.href = './admin/limew/supplier.aspx';
       	        		}
       	        	},{
       	        		xtype:'button',
       	        		text:'',
       	        		cls:'btn3',margin:'10 10 0 10',
       	        		handler:function(handler,scope){
                                    window.location.href = './admin/limew/goods.aspx';
       	        			//your code
       	        		}
       	        	},{
       	        		xtype:'button',
       	        		text:'',
       	        		cls:'btn4',margin:'10 10 0 10',
       	        		handler:function(handler,scope){
       	        			window.location.href = './admin/limew/order.aspx';
       	        		}
       	        	},{
       	        		xtype:'button',
       	        		text:'',
       	        		cls:'btn5',margin:'10 10 0 10',
       	        		handler:function(handler,scope){
       	        			//your code
       	        		}
       	        	}]
       	        },{
       	        	xtype : 'container',
       	        	layout : {
       	        		type : 'hbox',      /* hbox */
       	        		align : 'center' , /* stretch , center , left , right */
       	        		pack : 'center'     /* stretch , center , left , right */
       	        	},
       	        	items : [{
       	        		xtype:'button',
       	        		text:'',
       	        		cls:'btn6',
       	        		margin:'10 10 0 10',
       	        		handler:function(handler,scope){
                      window.location.href = './admin/limew/goodsRecord.aspx';
       	        		}
       	        	},{
       	        		xtype:'button',
       	        		text:'',
       	        		margin:'10 10 0 10',
       	        		cls:'btn7',
       	        		handler:function(handler,scope){
       	        			//your code
       	        		}
       	        	},{
       	        		xtype:'button',
       	        		text:'',
       	        		cls:'btn11',margin:'10 10 0 10',
       	        		handler:function(handler,scope){
       	        			//your code
       	        		}
       	        	},{
       	        		xtype:'button',
       	        		text:'',
       	        		cls:'btn11',margin:'10 10 0 10',
       	        		handler:function(handler,scope){
       	        			//your code
       	        		}
       	        	},{
       	        		xtype:'button',
       	        		text:'',
       	        		cls:'btn11',margin:'10 10 0 10',
       	        		handler:function(handler,scope){
       	        			//your code
       	        		}
       	        	}]
       	        }]
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
