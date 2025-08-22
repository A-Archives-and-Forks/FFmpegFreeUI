﻿
Public Class 新闻列表

    Public Shared Property 列表数据 As New List(Of KeyValuePair(Of String, String))

    Public Shared Sub 显示新闻列表()
        Form1.Panel5.Controls.Clear()
        GC.Collect()

        For i = 0 To 列表数据.Count - 1
            Dim c1 As New Label With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 40 * Form1.DPI, .TextAlign = ContentAlignment.MiddleLeft, .Padding = New Padding(10, 0, 0, 0), .BackColor = Color.Transparent, .Text = 列表数据(i).Key, .Tag = i, .Font = New Font(用户设置.实例对象.字体, 11)}
            AddHandler c1.MouseEnter, Sub(sender, e) sender.BackColor = ColorTranslator.FromWin32(RGB(56, 56, 56))
            AddHandler c1.MouseDown, Sub(sender, e) sender.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))
            AddHandler c1.MouseLeave, Sub(sender, e) sender.BackColor = Color.Transparent
            AddHandler c1.Click, Sub(sender, e)
                                     Select Case 列表数据(sender.Tag).Value.Split("|")(0)
                                         Case "msgbox"
                                             Dim 选项字典 As New Dictionary(Of String, Action)
                                             选项字典("了解") = Nothing
                                             软件内对话框.显示对话框(sender.Text, 列表数据(sender.Tag).Value.Split("|")(1).Replace("{vbCrLf}", vbCrLf), 选项字典, 软件内对话框.主题类型.常规)
                                         Case "link"
                                             Process.Start(New ProcessStartInfo With {.FileName = 列表数据(sender.Tag).Value.Split("|")(1), .UseShellExecute = True})
                                     End Select
                                 End Sub
            If 列表数据(i).Value.Split("|").Length >= 3 Then
                Select Case 列表数据(i).Value.Split("|")(2)
                    Case "red"
                        c1.ForeColor = Color.IndianRed
                    Case "orange"
                        c1.ForeColor = Color.Orange
                    Case "yellow"
                        c1.ForeColor = Color.GreenYellow
                    Case "green"
                        c1.ForeColor = Color.YellowGreen
                    Case "blue"
                        c1.ForeColor = Color.CornflowerBlue
                    Case "purple"
                        c1.ForeColor = Color.Violet
                End Select
            End If

            Form1.Panel5.Controls.Add(c1)
            c1.BringToFront()
        Next
    End Sub

    Public Shared Sub 获取新闻(Optional 强制重新获取 As Boolean = False)
        If My.Computer.Network.IsAvailable = False Then Exit Sub
        If 强制重新获取 Then GoTo jx1
jx1:
        Dim 服务器获取_新闻 As New ComponentModel.BackgroundWorker
        AddHandler 服务器获取_新闻.DoWork,
            Sub(sender As Object, e As ComponentModel.DoWorkEventArgs)
                Dim a As New GitAPI.TextFileString
                Dim x1 As String = "news.ini"
                a.获取文本文件数据(GitAPI.GitApiObject.开源代码平台.GitHub, "Lake1059/FFmpegFreeUI", "main", x1, Nothing, False)

                If a.ErrorString <> "" Then
                    e.Result = a.ErrorString
                    Exit Sub
                Else
                    e.Result = ""
                End If
                列表数据.Clear()
                键值对IO操作.读取键值对文本到列表(列表数据, a.网页返回字符串)
            End Sub
        AddHandler 服务器获取_新闻.RunWorkerCompleted,
            Sub(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs)
                If e.Result = "" Then
                    显示新闻列表()
                Else

                End If
            End Sub
        服务器获取_新闻.RunWorkerAsync()

    End Sub

End Class
