<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="tecnicos.aspx.cs" Inherits="TecReparacionExamen2PrograII.tecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" contanie text-center">
        <br />
            <h3>Técnicos</h3>
    </div>
        <div>
        <br />
        <br />
        <asp:GridView runat="server" ID="datagridTec" PageSize="10" HorizontalAlign="Center"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True" />
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
                    <label for="formGroupExampleInput2" class="form-label">Especialidad:</label> <br />
                    <asp:TextBox ID="TextBoxEsp" class="form-control" runat="server"></asp:TextBox>
                </div>
        </div>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Agregar" CssClass="btn" OnClick="Button1_Click"/>
        <asp:Button ID="Button2" runat="server" Text="Modificar" CssClass="btn" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="Eliminar" CssClass="btn" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="Consultar" CssClass="btn" OnClick="Button4_Click" />
        <asp:Button ID="Button5" runat="server" Text="Reporte" CssClass="btn"/>
        <br />
        <br />
    </div>
</asp:Content>
