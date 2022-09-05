<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditKupac.aspx.cs" Inherits="Aplikacija.EditKupac" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EDIT</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/myEditCss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
            <asp:HyperLink runat="server" ID="link" NavigateUrl="https://localhost:44353/Home/Index">Home page</asp:HyperLink>
            <asp:SqlDataSource ID="SqlDataDdlGradovi" runat="server" ConnectionString="<%$ ConnectionStrings:AdventureWorksOBPConnectionString %>" SelectCommand="SELECT Grad.IDGrad, Grad.Naziv, Grad.DrzavaID FROM Grad INNER JOIN Kupac ON Grad.IDGrad = Kupac.GradID WHERE (Grad.IDGrad = @GradID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="gvCustomers" Name="GradID" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
           <br />
        <asp:Label runat="server" ID="lblTitle">Here you can edit customers!</asp:Label>
            <br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataConnectionDrzava" DataTextField="Naziv" DataValueField="IDDrzava" Height="30px" Width="192px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataConnectionDrzava" runat="server" ConnectionString="<%$ ConnectionStrings:AdventureWorksOBPConnectionString %>" SelectCommand="SELECT DISTINCT Drzava.* FROM Drzava INNER JOIN Grad ON Drzava.IDDrzava = Grad.DrzavaID INNER JOIN Kupac ON Grad.IDGrad = Kupac.GradID"></asp:SqlDataSource>
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataConnectionGrad" DataTextField="Naziv" DataValueField="IDGrad" Height="30px" Width="192px" AutoPostBack="True">
        </asp:DropDownList>
       
        <asp:SqlDataSource ID="SqlDataConnectionGrad" runat="server" ConnectionString="<%$ ConnectionStrings:AdventureWorksOBPConnectionString %>" SelectCommand="SELECT * FROM [Grad] WHERE ([DrzavaID] = @DrzavaID)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" DefaultValue="" Name="DrzavaID" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
       
            <asp:Label runat="server" ID="lblRows">rows</asp:Label>
            <asp:DropDownList ID="ddlRowsCount" runat="server" AutoPostBack="True" Height="30px" Width="55px" OnSelectedIndexChanged="ddlRowsCount_SelectedIndexChanged">
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>40</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
            </asp:DropDownList>
            <asp:Label runat="server" ID="lblRows2">Show</asp:Label>
        </div>
       
        <asp:GridView ID="gvCustomers" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table " DataKeyNames="IDKupac" DataSourceID="SqlDataConnection" ForeColor="#333333" GridLines="None" HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-default btn-sm" />
                <asp:BoundField DataField="IDKupac" HeaderText="IDKupac" InsertVisible="False" ReadOnly="True" SortExpression="IDKupac" />
                <%--<asp:BoundField DataField="Ime" HeaderText="Ime" SortExpression="Ime" />--%>
               
                <asp:TemplateField HeaderText="Ime" SortExpression="Ime">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblIme" Text='<%# Bind("Ime") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox runat="server" ID="tbIme" Text='<%# Bind("Ime") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator
                            runat="server"
                            ControlToValidate="tbIme" 
                            ErrorMessage="Field Ime is required!">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
               <%-- <asp:BoundField DataField="Prezime" HeaderText="Prezime" SortExpression="Prezime" />--%>

                <asp:TemplateField HeaderText="Prezime" SortExpression="Prezime">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblPrezime" Text='<%# Bind("Prezime") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox runat="server" ID="tbPrezime" Text='<%# Bind("Prezime") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator
                            runat="server"
                            ControlToValidate="tbPrezime" 
                            ErrorMessage="Field Prezime is required!">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
               <%-- <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />--%>
                
                <asp:TemplateField HeaderText="E-mail">
                <itemtemplate>
                    <asp:HyperLink runat="server"
                        Text='<%# Eval("Email") %>'
                        NavigateUrl='<%# Eval("Email", "mailto:{0}") %>' />
                </itemtemplate>
                   <EditItemTemplate>
                       <asp:TextBox runat="server" ID="tbEmail" Text='<%# Bind("Email") %>'></asp:TextBox>
                       <asp:RegularExpressionValidator
                           runat="server"
                           ControlToValidate="tbEmail"
                           ErrorMessage="Invalid e-mail adress!"
                           ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                           ></asp:RegularExpressionValidator>
                   </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Telefon" HeaderText="Telefon" />
                <asp:BoundField DataField="GradID" HeaderText="GradID" />
               <%-- <asp:BoundField DataField="Naziv" HeaderText="Grad" />--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblGrad" Text='<%# Bind("Naziv") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               <%-- <asp:BoundField DataField="Drzava" HeaderText="Drzava"/>--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDrzava" Text='<%# Bind("Drzava") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
            <EditRowStyle BackColor="#EFF3FB" />  <%--#2461BF--%>
            <FooterStyle BackColor="CadetBlue" Font-Bold="True" ForeColor="White" /> <%--#507CD1--%>
            <HeaderStyle BackColor="CadetBlue" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="CadetBlue" ForeColor="White" HorizontalAlign="Center" CssClass="GridPager"/>
            <RowStyle BackColor="#d6f5f5" />  <%--#EFF3FB--%>
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataConnection" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:AdventureWorksOBPConnectionString %>" DeleteCommand="DELETE FROM [Kupac] WHERE [IDKupac] = @original_IDKupac AND [Ime] = @original_Ime AND [Prezime] = @original_Prezime AND (([Email] = @original_Email) OR ([Email] IS NULL AND @original_Email IS NULL)) AND (([Telefon] = @original_Telefon) OR ([Telefon] IS NULL AND @original_Telefon IS NULL)) AND (([GradID] = @original_GradID) OR ([GradID] IS NULL AND @original_GradID IS NULL))" InsertCommand="INSERT INTO [Kupac] ([Ime], [Prezime], [Email], [Telefon], [GradID]) VALUES (@Ime, @Prezime, @Email, @Telefon, @GradID)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT Kupac.IDKupac, Kupac.Ime, Kupac.Prezime, Kupac.Email, Kupac.Telefon,Kupac.GradID, Grad.Naziv, Drzava.Naziv AS Drzava FROM Kupac INNER JOIN Grad ON Kupac.GradID = Grad.IDGrad INNER JOIN Drzava ON Grad.DrzavaID = Drzava.IDDrzava WHERE Kupac.GradID=@GradID AND Grad.DrzavaID=@IDDrzava" UpdateCommand="UPDATE [Kupac] SET [Ime] = @Ime, [Prezime] = @Prezime, [Email] = @Email, [Telefon] = @Telefon, [GradID] = @GradID WHERE [IDKupac] = @original_IDKupac AND [Ime] = @original_Ime AND [Prezime] = @original_Prezime AND (([Email] = @original_Email) OR ([Email] IS NULL AND @original_Email IS NULL)) AND (([Telefon] = @original_Telefon) OR ([Telefon] IS NULL AND @original_Telefon IS NULL)) AND (([GradID] = @original_GradID) OR ([GradID] IS NULL AND @original_GradID IS NULL))
">
            <DeleteParameters>
                <asp:Parameter Name="original_IDKupac" Type="Int32" />
                <asp:Parameter Name="original_Ime" Type="String" />
                <asp:Parameter Name="original_Prezime" Type="String" />
                <asp:Parameter Name="original_Email" Type="String" />
                <asp:Parameter Name="original_Telefon" Type="String" />
                <asp:Parameter Name="original_GradID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Ime" Type="String" />
                <asp:Parameter Name="Prezime" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="Telefon" Type="String" />
                <asp:Parameter Name="GradID" Type="Int32" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList2" Name="GradID" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DropDownList1" Name="IDDrzava" PropertyName="SelectedValue" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Ime" Type="String" />
                <asp:Parameter Name="Prezime" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="Telefon" Type="String" />
                <asp:Parameter Name="GradID" Type="Int32" />           
                <asp:Parameter Name="original_IDKupac" />
                <asp:Parameter Name="original_Ime" />
                <asp:Parameter Name="original_Prezime" />
                <asp:Parameter Name="original_Email" />
                <asp:Parameter Name="original_Telefon" />
                <asp:Parameter Name="original_GradID" />
            </UpdateParameters>
        </asp:SqlDataSource>
       
    </form>
</body>
</html>
