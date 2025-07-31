<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeWebForm.aspx.cs" Inherits="EmployeeManagementPL.EmployeeWebForm" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Employee List</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <style>
        .btn-delete {
            background-color: #dc3545; /* Red */
            color: white;
            border: none;
            padding: 5px 10px;
            border-radius: 4px;
        }

        .btn-edit {
            background-color: #ffc107; /* Yellow */
            color: black;
            border: none;
            padding: 5px 10px;
            border-radius: 4px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <h2 class="mb-4">Employee Form</h2>

        <asp:HiddenField ID="hfEmployeeId" runat="server" />

        <div class="mb-3">
            <label for="txtName" class="form-label">Name</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label for="txtDepartment" class="form-label">Department</label>
            <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label for="txtHireDate" class="form-label">Hire Date</label>
            <asp:TextBox ID="txtHireDate" runat="server" CssClass="form-control" TextMode="Date" />
        </div>

        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary ms-2" OnClick="btnClear_Click" />

        <hr class="my-4" />

        <h3>Employee List</h3>
        <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False"
    CssClass="table table-bordered table-striped" DataKeyNames="EmployeeId"
    OnRowCommand="gvEmployees_RowCommand">
    <Columns>
        <asp:BoundField DataField="EmployeeId" HeaderText="ID" />
        <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
        <asp:BoundField DataField="Department" HeaderText="Department" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="HireDate" HeaderText="Hire Date" DataFormatString="{0:yyyy-MM-dd}" />
        
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnEdit" runat="server" Text="Edit"
                    CommandName="EditRow" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn-edit" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnDelete" runat="server" Text="Delete"
                    CommandName="DeleteRow" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn-delete" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


        <asp:ScriptManager ID="ScriptManager1" runat="server" />
    </form>
</body>
</html>
