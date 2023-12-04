<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TecReparacionExamen2PrograII.InicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8"> 
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="CSS/StyleSheet1.css"> 
    <title>Login</title>
</head>
<body>
<form id="form1" autocomplete='off' class='form' runat="server">
  <div class='control'>
    <h1>
      Inicio de Sesión
    </h1>
  </div>
  <div class='control block-cube block-input'>
      <asp:TextBox ID="TextBoxUser" class='control block-cube block-input' type='text' placeholder="Usuario" runat="server"></asp:TextBox>
    <div class='bg-top'>
      <div class='bg-inner'></div>
    </div>
    <div class='bg-right'>
      <div class='bg-inner'></div>
    </div>
    <div class='bg'>
      <div class='bg-inner'></div>
    </div>
  </div>
  <div class='control block-cube block-input'>
    <asp:TextBox ID="TextBoxContraseña" class='control block-cube block-input' type='password' placeholder="Contraseña" runat="server"></asp:TextBox>
    <div class='bg-top'>
      <div class='bg-inner'></div>
    </div>
    <div class='bg-right'>
      <div class='bg-inner'></div>
    </div>
    <div class='bg'>
      <div class='bg-inner'></div>
    </div>
  </div>
  <button class='btn block-cube block-cube-hover' type='button'>
    <div class='bg-top'>
      <div class='bg-inner'></div>
    </div>
    <div class='bg-right'>
      <div class='bg-inner'></div>
    </div>
    <div class='bg'>
      <div class='bg-inner'></div>
    </div>
    <div class='text'>
        <asp:Button ID="ButtonIngresar" class='btn block-cube block-cube-hover' runat="server" Text="Ingresar" OnClick="ButtonIngresar_Click" />
    </div>
  </button>
</form>
</body>
</html>
