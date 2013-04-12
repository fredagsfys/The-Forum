<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="TheForum.Members.Post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="span12 well">
        <div class="span2 pull-right">
            <img class="img-polaroid" src="../App_Themes/Main/img/haris.jpg"/>
            <span class="text-error">Administrator</span> ✰✰<br/>
            Haris
        </div>
        <div class="span10">
	        <h2>The Admin Team</h2>
	    </div>
        <div class="span10">
            <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non turpis nunc, in imperdiet lacus. 
                Morbi porta facilisis ullamcorper. Vivamus in imperdiet nisi. Fusce pretium risus non velit sodales cursus.
                Duis posuere hendrerit malesuada. Donec non dictum eros. Donec vestibulum tortor ac orci posuere ullamcorper. 
                Ut sed justo sit amet velit molestie blandit sodales non risus. Donec vel dapibus arcu. Quisque iaculis elementum velit tempor egestas.
                Morbi scelerisque adipiscing nisl non accumsan. Vestibulum consectetur tincidunt lectus a egestas. Vivamus et velit diam.
            </p>
            <p> 
                Donec vestibulum eros vel sem ultrices venenatis. Phasellus in mauris non nunc vehicula tincidunt eget eget sem. Sed id nibh nec nulla consequat mollis. 
                Quisque adipiscing ante ac nunc rutrum quis ultrices velit ornare. Phasellus tempus nisl purus, at hendrerit purus. Phasellus ut dolor ut risus tempor 
                dapibus. Donec congue pretium justo, nec sagittis metus placerat ut. Proin aliquet vulputate nibh, a faucibus neque egestas ut. Duis lorem justo, lacinia 
                in pharetra sit amet, ornare sed arcu. Phasellus eget lacus nibh, ut faucibus lectus.
            </p>
        </div>
	    <div class="span11">
	            <hr>
            <a href="#" class="btn btn-small btn-success"><i class="icon-pencil"></i> Reply</a>
            <a href="#" class="btn btn-small btn-warning"><i class="icon-edit"></i> Edit</a>
            <a href="#" class="btn btn-small btn-danger" onclick="return confirm('Sure you want to delete the whole post?')"><i class="icon-trash"></i> Delete</a>
    	    | <i class="icon-user"></i> <a href="#">Haris</a> 
    	    | <i class="icon-calendar"></i> Sept 16th, 2013 at 4:20 pm
     	    | <i class="icon-comment"></i> <a href="#">1 Comments</a>

        </div>
    </div>
    
    <div class="span9 well">
        <div class="span2 pull-right">
            <img class="img-polaroid" src="../App_Themes/Main/img/oskar.jpg"/>
            <span class="text-success">Member</span>
            Oskar
        </div>
        <div class="span10">
	        <h5><span class="icon-share-alt"></span>Re: The Admin Team</h5>
	    </div>
        <div class="span10">
            <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non turpis nunc, in imperdiet lacus. 
                Morbi porta facilisis ullamcorper. Vivamus in imperdiet nisi. Fusce pretium risus non velit sodales cursus.
            </p>
            <p>
                Duis posuere hendrerit malesuada. Donec non dictum eros. Donec vestibulum tortor ac orci posuere ullamcorper. 
                Ut sed justo sit amet velit molestie blandit sodales non risus. Donec vel dapibus arcu. 
            </p>
        </div>
	    <div class="span11">
	            <hr>
            <a href="#" class="btn btn-small btn-danger" onclick="return confirm('Sure you want to delete this comment?')"><i class="icon-trash"></i> Delete</a>
    	    | <i class="icon-user"></i> <a href="#">Oskar</a> 
    	    | <i class="icon-calendar"></i> Sept 16th, 2013 at 4:20 pm

        </div>
    </div>
</asp:Content>
