<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="TecReparacionExamen2PrograII.Asignaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" contanie text-center">
    <h3>Asignaciones</h3>
    </div>
        <div>
        <br />
        <br />
        <asp:GridView runat="server" ID="datagridAsignaciones" PageSize="10" HorizontalAlign="Center"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True" />
        <br />
    </div>
    <div>
        <div>
                <div class="mb-3">
                    <label for="formGroupExampleInput" class="form-label">ID de detalle:</label> <br />
                    <asp:TextBox ID="TextBoxID" class="form-control" runat="server"></asp:TextBox>
                </div>
                <br />
                <div class="mb-3">
                    <label for="formGroupExampleInput2" class="form-label">ID de reparación:</label> <br />
                    <asp:TextBox ID="TextBoxRepID" class="form-control" runat="server"></asp:TextBox>
                </div>
                <br />
                <div class="mb-3">
                    <label for="exampleFormControlInput1" class="form-label">ID de técnico:</label><br />
                    <asp:TextBox ID="TextBoxTecID" class="form-control" runat="server"></asp:TextBox><br />
                </div>
                <br />
                <div class="mb-3">
                    <label for="formGroupExampleInput2" class="form-label">Fecha de asignación:</label> <br />
                    <asp:TextBox ID="TextBoxFechaAsig" class="form-control" runat="server"></asp:TextBox><br />
                </div>
                <br />
        </div>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Agregar" CssClass="btn" OnClick="Button1_Click"/>
        <asp:Button ID="Button2" runat="server" Text="Modificar" CssClass="btn" OnClick="Button2_Click"/>
        <asp:Button ID="Button3" runat="server" Text="Eliminar" CssClass="btn" OnClick="Button3_Click"/>
        <asp:Button ID="Button4" runat="server" Text="Consultar" CssClass="btn" OnClick="Button4_Click"/>
        <br />
        <br />
    </div>
</asp:Content>
