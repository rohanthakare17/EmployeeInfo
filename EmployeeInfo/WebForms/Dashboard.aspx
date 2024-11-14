<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="EmployeeInfo.WebForms.Dashboard" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Manage Information</title>
    <style>
        body { font-family: Arial, sans-serif; background-color: #f4f7fa; }
        .container { width: 80%; margin: auto; padding: 20px; background-color: #fff; border-radius: 8px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); }
        table { width: 100%; }
        th, td { padding: 8px; text-align: left; }
        .form-group { margin: 10px 0; }
    </style>
</head>
<body>
    <div class="container">
        <h2>Manage Information</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="false"></asp:Label>
        
        <div class="form-group">
            <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Label ID="lblDOB" runat="server" Text="Date of Birth: "></asp:Label>
            <asp:TextBox ID="txtDOB" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Label ID="lblSex" runat="server" Text="Sex: "></asp:Label>
            <asp:DropDownList ID="ddlSex" runat="server">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:DropDownList>
        </div>
        
        <div class="form-group">
            <asp:Label ID="lblPhone" runat="server" Text="Phone: "></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Label ID="lblAddress" runat="server" Text="Address: "></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Label ID="lblImage" runat="server" Text="Image: "></asp:Label>
            <asp:FileUpload ID="fileImage" runat="server" />
        </div>
        
        <div class="form-group">
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        </div>
        
        <br />
        <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvData_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="DateOfBirth" HeaderText="DOB" />
                <asp:BoundField DataField="Sex" HeaderText="Sex" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="Image" HeaderText="Image Path" />
                <asp:CommandField ShowSelectButton="True" SelectText="Edit" />
            </Columns>
        </asp:GridView>
    </div>
</body>
</html>

