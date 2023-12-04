<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Reparaciones.aspx.cs" Inherits="TecReparacionExamen2PrograII.Reparaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class=" contanie text-center">
            <h3>Reparaciones</h3>
    </div>
        <div>
        <br />
        <br />
        <asp:GridView runat="server" ID="datagridRep" PageSize="10" HorizontalAlign="Center"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True" />
        <br />
    </div>
    <div>
        <div>
                <div class="mb-3">
                    <label for="formGroupExampleInput" class="form-label">ID de reparación:</label> <br />
                    <asp:TextBox ID="TextBoxID" class="form-control" runat="server"></asp:TextBox>
                </div>
                <br />
                <div class="mb-3">
                    <label for="formGroupExampleInput2" class="form-label">ID de Equipo:</label> <br />
                    <asp:TextBox ID="TextBoxEquipoID" class="form-control" runat="server"></asp:TextBox>
                </div>
                <br />
                <div class="mb-3">
                    <label for="exampleFormControlInput1" class="form-label">Fecha de solicitud:</label><br />
                    <asp:TextBox ID="TextBoxFecha" class="form-control" runat="server"></asp:TextBox><br />
                </div>
                <br />
                <div class="mb-3">
                    <label for="formGroupExampleInput2" class="form-label">Estado:</label> <br />
                    <asp:DropDownList ID="DropDownListEstado" runat="server" Height="16px" Width="520px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>NUEVO</asp:ListItem>
                        <asp:ListItem Value="ENPROCESO">EN PROCESO</asp:ListItem>
                        <asp:ListItem>COMPLETADO</asp:ListItem>
                    </asp:DropDownList>
                </div>
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
