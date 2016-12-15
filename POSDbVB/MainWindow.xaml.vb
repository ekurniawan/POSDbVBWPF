Public Class MainWindow

    'Private Static MainWindow _instance;
    '    Public Static MainWindow Instance()
    '    {
    '        If (_instance == null)
    '            _instance = New MainWindow();
    '        Return _instance;
    '    }

    Private Shared _instance As MainWindow
    Public Shared Function Instance() As MainWindow
        If _instance Is Nothing Then
            _instance = New MainWindow
        End If
        Return _instance
    End Function

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        AddHandler btnMasterKategori.Click, AddressOf btnMasterKategori_Click

    End Sub

    Private Sub btnMasterKategori_Click(sender As Object, e As RoutedEventArgs)
        Dim frmMasterKategori As New MasterKategori
        frmMasterKategori.Show()
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Application.Current.Shutdown()

    End Sub

    Private Sub menuMasterKategori_Click(sender As Object, e As RoutedEventArgs)
        Dim frmMasterKategori As New MasterKategori
        frmMasterKategori.Show()
    End Sub
End Class
