﻿Public Class 编码队列管理选项

    Public Shared ReadOnly a As New 暗黑上下文菜单 With {.ShowImageMargin = False, .Font = Form1.Font}

    Public Shared Sub 初始化()
        AddHandler Form1.UiButton任务管理菜单.MouseDown, Sub(s, e)
                                                       If e.Button = MouseButtons.Left Then
                                                           a.Show(Form1.UiButton任务管理菜单, New Point(15 * Form1.DPI, 15 * Form1.DPI + Form1.UiButton任务管理菜单.Height))
                                                       End If
                                                   End Sub
        a.Items.AddRange(New ToolStripItem() {
                 New ToolStripSeparator() With {.Tag = "null"},
                 New ToolStripMenuItem("任务数据管理") With {.ForeColor = Color.CornflowerBlue, .Enabled = False},
                 New ToolStripMenuItem("(可多选) 复制任务的命令行（每行一个）", Nothing, AddressOf 界面控制_编码队列.复制多个任务的命令行),
                 New ToolStripMenuItem("(可多选) 将参数面板数据覆盖到任务", Nothing, AddressOf 界面控制_编码队列.将参数面板数据覆盖到任务),
                 New ToolStripMenuItem("(仅单选) 将任务参数覆盖到参数面板", Nothing, AddressOf 界面控制_编码队列.将任务参数覆盖到参数面板),
                 New ToolStripMenuItem("(可多选) 将任务放到添加文件选项卡", Nothing, AddressOf 界面控制_编码队列.将任务放到添加文件选项卡),
                 New ToolStripMenuItem("(仅单选) 导出任务参数数据到预设文件", Nothing, AddressOf 界面控制_编码队列.导出任务参数数据到预设文件),
                 New ToolStripSeparator(),
                 New ToolStripMenuItem("任务数量管理") With {.ForeColor = Color.CornflowerBlue, .Enabled = False},
                 New ToolStripMenuItem("全选", Nothing, AddressOf 界面控制_编码队列.全选任务),
                 New ToolStripMenuItem("反选", Nothing, AddressOf 界面控制_编码队列.反选任务),
                 New ToolStripSeparator() With {.Tag = "null"}})
    End Sub

    Public Shared Sub 重设字体()
        a.Font = New Font(用户设置.实例对象.字体, a.Font.Size)
    End Sub

End Class