<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="FindJob.Views.ErrorPages.ServerErrorPages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <!-- import bootstrap css -->
    <link rel="stylesheet" href="../../Contents/Bootstrap/bootstrap.min.css" />
    <!-- import main css -->
    <link rel="stylesheet" href="../../Contents/MainStyle/Css/main.css" />
    <!-- import fontawsome css -->
    <link rel="stylesheet" href="../Contents/MainStyle/Css/all.min.css" />
    <title></title>
    <style>
        body{
            display:flex;
            justify-content:center;
            align-items:center;
        }
        img{
            height:400px;
            margin-top: 50px;
        }
        a {
            position:absolute;
                bottom: 40px;
        }
        h1{
            font-family:Arial;
            color:#3f3d56;
            position:absolute;

        }
    </style>
</head>
<body>
    <h1>Page Erreur</h1>
    <img src="../../Contents/Images/page_not_found.svg" alt="errorPage" />
    <a href="../Home.aspx" class="btn btn-primary my-4">Page Accueil</a>
    
    <!-- import scripts js -->
    <script src="../Contents/Bootstrap/bootstrap.min.js"></script>
    <script src="../Contents/MainStyle/Css/main.js"></script>
    <script src="../Contents/MainStyle/Js/all.min.js"></script>
</body>
</html>
