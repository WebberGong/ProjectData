﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<ProjectData.UI.Models.LocalPasswordModel>" %>

<p>
    你没有此站点的本地密码。请添加一个本地
                密码，这样，无需外部登录便可以登录了。
</p>

<% using (Html.BeginForm("Manage", "Account")) { %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary() %>

    <fieldset>
        <legend>“设置密码”表单</legend>
        <ol>
            <li>
                <%: Html.LabelFor(m => m.NewPassword) %>
                <%: Html.PasswordFor(m => m.NewPassword) %>
            </li>
            <li>
                <%: Html.LabelFor(m => m.ConfirmPassword) %>
                <%: Html.PasswordFor(m => m.ConfirmPassword) %>
            </li>
        </ol>
        <input type="submit" value="设置密码" />
    </fieldset>
<% } %>
