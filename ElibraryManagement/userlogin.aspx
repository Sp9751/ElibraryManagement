<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="ElibraryManagement.userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="image/generaluser.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>User Login</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">

                                   <label>User Id</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="User Id"></asp:TextBox>
                               </div>

                                <label>Password</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                               </div>

                               <div class="form-group">
                                   <asp:Button class="btn btn-success btn-lg form-control my-3" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                               </div>

                                <div class="form-group">
                                  <a href="Signup.aspx"><input class="btn btn-info btn-lg form-control" id="Button2" type="button" value="Sign Up"/></a>
                               </div>

                            </div>
                        </div>

                    </div>
                </div>
                <a href="homepage.aspx"> << Back To Home</a><br /><br />
            </div>
        </div>
    </div>

</asp:Content>
