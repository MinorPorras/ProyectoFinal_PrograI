<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="TecReparacionExamen2PrograII.usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #exampleInputEmail1 {
            width: 165px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" contanie text-center">
        <br />
            <h3>Usuarios</h3>
    </div>
    <div>
        <br />
        <br />
        <asp:GridView runat="server" ID="datagridUsuarios" HorizontalAlign="Center"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True" >
        </asp:GridView>
        <br />
    </div>
    <div>
        <div>
                <div class="mb-3">
                    <label for="formGroupExampleInput" class="form-label">ID:</label> <br />
                    <asp:TextBox ID="TextBoxID" class="form-control" runat="server"></asp:TextBox>
                </div>
                <br />
                <div class="mb-3">
                    <label for="formGroupExampleInput2" class="form-label">Nombre:</label> <br />
                    <asp:TextBox ID="TextBoxNom" class="form-control" runat="server"></asp:TextBox>
                </div>
                <br />
                <div class="mb-3">
                    <label for="exampleFormControlInput1" class="form-label">Correo Electrónico:</label><br />
                    <asp:TextBox ID="TextBoxCorreo" type="email" Text="ejemplo@correo.com" class="form-control" runat="server"></asp:TextBox>
                </div>
                <br />
                <div class="mb-3">
                    <label for="formGroupExampleInput2" class="form-label">Telefono:</label> <br />
                    <asp:TextBox ID="TextBoxTel" class="form-control" runat="server"></asp:TextBox>
                </div>
        </div>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Agregar" CssClass="btn" OnClick="Button1_Click"/>
        <asp:Button ID="Button2" runat="server" Text="Modificar" CssClass="btn" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="Eliminar" CssClass="btn" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="Consultar" CssClass="btn" OnClick="Button4_Click" />
        <br />
        <br />
    </div>
</asp:Content>
