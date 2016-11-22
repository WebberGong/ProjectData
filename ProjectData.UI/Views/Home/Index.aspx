<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    中交二公局第二公司沥青搅拌站数据
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        var totalCount = undefined;
        var id = undefined;
        var mPageNumber = undefined;
        var mPageSize = undefined;

        Date.prototype.Format = function (fmt) {
            var o = {
                "M+": this.getMonth() + 1,
                "d+": this.getDate(),
                "h+": this.getHours(),
                "m+": this.getMinutes(),
                "s+": this.getSeconds(),
                "q+": Math.floor((this.getMonth() + 3) / 3),
                "S": this.getMilliseconds()
            };
            if (/(y+)/.test(fmt))
                fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
            for (var k in o)
                if (new RegExp("(" + k + ")").test(fmt))
                    fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
            return fmt;
        };

        function initGrid() {
            var queryCondition = document.getElementById("queryCondition");
            var heightOffset = 35 + queryCondition.offsetHeight + 20;
            $('#grid').datagrid({
                width: fixWidth(1, 8),
                height: fixHeight(1, heightOffset),
                striped: true,
                singleSelect: true,
                loadMsg: '数据加载中请稍后……',
                pagination: !$('#cbIsAutoQuery').is(':checked'),
                pageSize: 30,
                pageList: [10, 20, 30, 40, 50],
                pageNumber: 1,
                rownumbers: false,
                columns: [
                        [
                            { field: 'RowNum', title: '序号', align: 'center' },
                            { field: 'RiQiShiKe', title: '日期时刻', align: 'center' },
                            { field: 'PanHao', title: '盘号', align: 'center' },
                            { field: 'PeiBiHao', title: '配比号', align: 'center' },
                            { field: 'CheHao', title: '车号', align: 'center' },
                            { field: 'KeHuHao', title: '客户号', align: 'center' },
                            { field: 'GuLiao6', title: '骨料6', align: 'center' },
                            { field: 'GuLiao5', title: '骨料5', align: 'center' },
                            { field: 'GuLiao4', title: '骨料4', align: 'center' },
                            { field: 'GuLiao3', title: '骨料3', align: 'center' },
                            { field: 'GuLiao2', title: '骨料2', align: 'center' },
                            { field: 'GuLiao1', title: '骨料1', align: 'center' },
                            { field: 'ShiFen3', title: '石粉3', align: 'center' },
                            { field: 'ShiFen2', title: '石粉2', align: 'center' },
                            { field: 'ShiFen1', title: '石粉1', align: 'center' },
                            { field: 'LiQing', title: '沥青', align: 'center' },
                            { field: 'HeJi', title: '合计Kg', align: 'center' },
                            { field: 'YiCangWd', title: '一仓温度', align: 'center' },
                            { field: 'HunHeLiaoWd', title: '混合料温度', align: 'center' },
                            { field: 'ChuChenQiWd', title: '除尘器入口温度', align: 'center' },
                            { field: 'LiQingWd', title: '沥青温度', align: 'center' },
                            { field: 'GuLiaoWd', title: '骨料温度', align: 'center' }
                        ]
                ]
            });
            initPager();
        };

        function initPager() {
            var pager = $('#grid').datagrid('getPager');
            $(pager).pagination({
                beforePageText: '第',
                afterPageText: '页&nbsp;&nbsp;&nbsp;&nbsp;共&nbsp;{pages}&nbsp;页',
                displayMsg: '当前显示&nbsp;{from}&nbsp;-&nbsp;{to}&nbsp;条记录&nbsp;&nbsp;&nbsp;&nbsp;共&nbsp;{total}&nbsp;条记录',
                onSelectPage: function (pageNumber, pageSize) {
                    mPageNumber = pageNumber;
                    mPageSize = pageSize;
                    fillData(pageNumber, pageSize);
                }
            });
        };

        function fillData(pageNumber, pageSize) {
            var isAutoQuery = $('#cbIsAutoQuery').is(':checked');
            var startTime = $('#startTime').datetimebox('getValue');
            var endTime = $('#endTime').datetimebox('getValue');
            var url = serviceBaseUrl + 'api/json/reply/GetDbDataRequest';
            $.ajax({
                type: "post",
                dataType: "jsonp",
                async: false,
                url: url,
                data: {
                    IsAutoQuery: isAutoQuery,
                    StartTime: startTime,
                    EndTime: endTime,
                    PageNumber: pageNumber,
                    PageSize: pageSize
                },
                success: function (result) {
                    var data = { total: result.TotalCount, rows: result.Data };
                    totalCount = result.TotalCount;
                    $('#grid').datagrid("loadData", data);
                }
            });
        };

        function fillGrid() {
            var pageNumber = $('#grid').datagrid('options').pageNumber;
            var pageSize = $('#grid').datagrid('options').pageSize;
            fillData(pageNumber, pageSize);
        };

        function fixWidth(percent, offset) {
            return document.body.clientWidth * percent - offset;
        };

        function fixHeight(percent, offset) {
            return document.body.clientHeight * percent - offset;
        };

        function initElements() {
            $('#cbIsAutoQuery').attr("checked", "checked");
            $('#btnQuery').attr("disabled", "disabled");
            $('#btnExport').attr("disabled", "disabled");
            var startTime = new Date();
            var endTime = new Date();
            startTime.setHours(new Date().getHours() - 2);
            $('#startTime').datetimebox('setValue', startTime.Format("yyyy-MM-dd hh:mm:ss"));
            $('#endTime').datetimebox('setValue', endTime.Format("yyyy-MM-dd hh:mm:ss"));
            $('.panel-header').attr('style', 'height: 35px');
            $('.panel-title').attr('style', 'text-align: center; margin-top: 10px; font-size: 30px; font-weight:bold');
        };

        function cbIsAutoQueryChanged() {
            initGrid();
            if ($('#cbIsAutoQuery').is(':checked')) {
                $('#btnQuery').attr("disabled", "disabled");
                $('#btnExport').attr("disabled", "disabled");
                fillGrid();
                id = setInterval("fillGrid()", 20000);
            } else {
                $('#btnQuery').removeAttr("disabled");
                $('#btnExport').removeAttr("disabled");
                var data = { total: 0, rows: [] };
                totalCount = 0;
                $('#grid').datagrid("loadData", data);
                clearInterval(id);
            }
        };

        function onQuery() {
            var startTime = $('#startTime').datetimebox('getValue');
            var endTime = $('#endTime').datetimebox('getValue');
            if (startTime > endTime) {
                alert("开始时间不能大于结束时间！");
                return;
            }
            initGrid();
            fillGrid();
        };

        function onExport() {
            var isAutoQuery = $('#cbIsAutoQuery').is(':checked');
            var startTime = $('#startTime').datetimebox('getValue');
            var endTime = $('#endTime').datetimebox('getValue');
            var url = "Home/ExportDbData?isAutoQuery=" + isAutoQuery + "&startTime=" + startTime + "&endTime=" + endTime + "&pageNumber=" + 1 + "&pageSize=" + 2000;
            window.location.href = url;
        };

        $(document).ready(function () {
            initElements();
            initGrid();
            fillGrid();
            window.onresize = function () {
                var queryCondition = document.getElementById("queryCondition");
                var heightOffset = 35 + queryCondition.offsetHeight + 20;
                $('#grid').datagrid({ width: fixWidth(1, 8), height: fixHeight(1, heightOffset) });
                $("#grid").datagrid("getPager").pagination("refresh", { total: totalCount, pageNumber: mPageNumber, pageSize: mPageSize });
                initPager();
            };
            if ($('#cbIsAutoQuery').is(':checked')) {
                id = setInterval("fillGrid()", 20000);
            };
        });
    </script>
    <table>
        <tr id="queryCondition" style="height: 35px">
            <td style="width: 20px">
                <input id="cbIsAutoQuery" type="checkbox" onchange="cbIsAutoQueryChanged()" />
            </td>
            <td style="width: 100px; text-align: left">
                <label>
                    是否自动查询</label>
            </td>
            <td style="width: 70px; text-align: right">
                <label>
                    开始时间：</label>
            </td>
            <td style="width: 180px">
                <input id="startTime" class="easyui-datetimebox" data-options="required:true,showSeconds:true"
                    style="width: 150px">
            </td>
            <td style="width: 70px; text-align: right">
                <label>
                    结束时间：</label>
            </td>
            <td style="width: 180px">
                <input id="endTime" class="easyui-datetimebox" data-options="required:true,showSeconds:true"
                    style="width: 150px">
            </td>
            <td style="width: 70px; text-align: center; margin-left: 30px">
                <input id="btnQuery" type="button" onclick="onQuery()" value="查  询" style="width: 60px; height: 22px" />
            </td>
            <td style="width: 70px; text-align: left">
                <input id="btnExport" type="button" onclick="onExport()" value="导  出" style="width: 60px; height: 22px" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td colspan="9" style="text-align: center">
                <table id="grid" style="width: 100%">
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
