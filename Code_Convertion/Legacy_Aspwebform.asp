<!-- Default.aspx -->
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html>
<head>
    <title>Registrazione</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Registrazione Utente</h2>
            <label for="txtName">Nome:</label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" Text="Invia" OnClick="btnSubmit_Click" runat="server" />
        </div>
    </form>
</body>
</html>

// Default.aspx.cs
using System;

public partial class _Default : System.Web.UI.Page
{
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string name = txtName.Text;
        string email = txtEmail.Text;

        // Simula il salvataggio dei dati
        ViewState["UserData"] = $"{name} ({email})";

        Response.Write($"Grazie per la registrazione, {name}!");
    }
}

