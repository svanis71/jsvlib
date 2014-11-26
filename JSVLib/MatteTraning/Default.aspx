<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MatteTraning.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Matteträning</title>
    <link rel="stylesheet" type="text/css" href="//ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/themes/blitzer/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="Content/Site.less" />
</head>
<body>
    <header id="header">Header goes here</header>
    <section id="wrapper">
        <section id="navigation">
            <div class="showMenuIcon" data-menuid="topmenu" data-action="show">Visa menyn</div>
            <nav id="nav">
                <dl id="topmenu" class="topmenu">
                    <dd class="topmenuItem"><span>Räknesätt</span>

                        <div class="dropdown">
                            <dl class="dropdownItems">
                                <dd class="dropdownItem">Plus</dd>
                                <dd class="dropdownItem">Minus</dd>
                                <dd class="dropdownItem">Multiplikation</dd>
                            </dl>
                        </div>
                    </dd>
                    <dd class="topmenuItem">Item 2</dd>
                    <dd class="topmenuItem">Item 3</dd>
                </dl>
            </nav>
        </section>
        <section id="page">
            <article id="content"></article>
        </section>
    </section>
    <footer id="footer">
        <section id="leftFoot">Vänsterfot</section>
        <section id="middleFoot"></section>
        <section id="rightFoot">Högerfot</section>
    </footer>

    <script src="Scripts/knockout-2.2.1.js"></script>
    <script src="Scripts/jquery-1.9.0.min.js"></script>
    <script src="Scripts/jquery-ui-1.9.2.min.js"></script>
    <script src="Scripts/Site.js" type="text/javascript"></script>
</body>
</html>
