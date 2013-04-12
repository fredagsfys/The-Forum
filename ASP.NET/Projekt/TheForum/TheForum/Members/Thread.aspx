<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="TheForum.Members.Thread" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <p><a href="#" class="btn btn-success"><i class="icon-pencil"></i> New post</a></p>
    <div class="row-fluid">
		<div class="span12">
					<div class="row-fluid">
					    <table class="table table-bordered table-striped table-hover">
							<thead>
								<tr>
									<th>Posts</th>
                                    <th>Views</th>
                                    <th>Comments</th>
                                    <th>Last comment</th>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td><a href="#">The Admin Team</a></td>
                                    <td>0</td>
                                    <td>0</td>
                                    <td><span class="icon-user"></span> Haris <a href="#"><span class="icon-share-alt"></span> Read</a></td>
								</tr>
                                <tr>
									<td><a href="#">What is a Admin?</a></td>
                                    <td>0</td>
                                    <td>0</td>
                                    <td><span class="icon-user"></span> Haris <a href="#"><span class="icon-share-alt"></span> Read</a></td>
								</tr>
								<tr>
									<td><a href="#">The Moderator Team</a></td>
                                    <td>0</td>
                                    <td>0</td>
                                    <td><span class="icon-user"></span> Haris <a href="#"><span class="icon-share-alt"></span> Read</a></td>
								</tr>
								<tr>
									<td><a href="#">What is a Moderator?</a></td>
                                    <td>0</td>
                                    <td>0</td>
                                    <td><span class="icon-user"></span> Haris <a href="#"><span class="icon-share-alt"></span> Read</a></td>
								</tr>
							</tbody>
						</table>	
					</div>							
				</div>
			</div>
</asp:Content>
