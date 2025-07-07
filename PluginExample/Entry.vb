Imports System.Windows
Imports System.Windows.Forms

Public Class Entry

    Public Shared Sub Entry()
        '��ʼ���Ĵ��붼д����� 3FUI ������ִ��
        AddCustomWinformPanel()
        AddCustomWpfPanel()
        '��Ҫע������Ҳ���������ʱ��ˢ���Զ�������б�
        '�������������� Entry ������Զ������
        '�����޷������������ҵ�����ӵ��Զ������
    End Sub

    '##################################################
    '########## ����Զ��� WinForm ���Ļص����� ##########
    '##################################################
    Public Shared Property HostCall_AddCustomWinformPanel As Action(Of String, Control)
    Public Shared Sub SetHost_AddCustomWinformPanel(action As Object)
        HostCall_AddCustomWinformPanel = CType(action, Action(Of String, Control))
    End Sub
    Public Shared Sub AddCustomWinformPanel()
        '���Զ��� WinForm �����ӵ�������
        HostCall_AddCustomWinformPanel.Invoke("���ʾ����WinForm �ؼ�", New UserControlWinform1)
    End Sub

    '##################################################
    '########## ����Զ��� WPF ���Ļص����� ##########
    '##################################################
    Public Shared Property HostCall_AddCustomWpfPanel As Action(Of String, UIElement)
    Public Shared Sub SetHost_AddCustomWpfPanel(action As Object)
        HostCall_AddCustomWpfPanel = CType(action, Action(Of String, UIElement))
    End Sub
    Public Shared Sub AddCustomWpfPanel()
        '���Զ��� WPF �����ӵ�������
        HostCall_AddCustomWpfPanel.Invoke("���ʾ����WPF �ؼ�", New UserControlWpf1)
    End Sub

    '##################################################
    '########## ������񵽱�����еĻص����� ##########
    '##################################################
    Public Shared Property HostCall_AddMissionToQueue As Action(Of String, String, String)
    Public Shared Sub SetHost_AddMissionToQueue(action As Object)
        HostCall_AddMissionToQueue = CType(action, Action(Of String, String, String))
    End Sub
    Public Shared Sub AddMissionToQueue()
        '��������ӵ����������
        '������Զ���ؼ��е���������������
        HostCall_AddMissionToQueue.Invoke("�� ffmpeg �Ĳ�������Ҫ�� ffmpeg ��ʼ", "�ڱ����������ʾ���ļ�����Ҳ����������ʾ������Ϣ", "����ļ���·�����ģ����ڱ�������еĶ�λ�������")
    End Sub

End Class