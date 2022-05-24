<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TSAQG._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <br />
        <br />
        <div class="form">
            <h2 class="fw-light text-center">Text Summarization & Question Generation </h2>
            <hr id="hr" runat="server" />
            <div class="row">

                <div class="col col-lg-6 form-group">
                    <asp:TextBox ID="orignalT" class="form-control form-group-lg w-100" runat="server" TextMode="MultiLine" Style="min-width: 100%; resize: none;" placeholder="Orignal Text" Rows="20"></asp:TextBox>

                </div>

                <div class="col col-lg-6">
                    <asp:TextBox ID="summaryT" class="form-control form-group-lg" runat="server" Style="min-width: 100%; resize: none; float: right;" placeholder="Summarized Text" Rows="20" TextMode="MultiLine"></asp:TextBox>
                </div>

            </div>
            <br />
            <div class="d-flex justify-content-center">
                <asp:Button ID="processB" runat="server" CssClass="btn-group-lg btn-secondary form-control" Width="30%" Text="Process" OnClick="processB_Click" />

            </div>
            <div id="questions" runat="server">
                <br />
            </div>
        </div>
    </div>


</asp:Content>
