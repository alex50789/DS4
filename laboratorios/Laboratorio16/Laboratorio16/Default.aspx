﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio16._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
       
        <div class="row">
            <div style ="height:200px; width:500px;">
                <asp:Label ID="lblMensaje" runat="server" foreColor="Red" Font-Size="35px" />

            </div>
            <div style="height:200px; width:500px;">
                <asp:Button ID="btnMessage" Text="Mostrar Mensaje" TooolTip="Dar click para mostrar mensaje" runat="server" OnClick="btnMensaje_Click" />
            </div>
        </div>
    

</asp:Content>
