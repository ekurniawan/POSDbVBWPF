Imports System.ComponentModel

Public Class MasterKategori

    Private kategoriVm As KategoriViewModel
    Private viewKategori As ICollectionView

    Private Sub InisialisasiAwal()
        For Each ctr In gridForm.Children.OfType(Of TextBox)
            ctr.IsEnabled = False
        Next

        For Each ctr In gridForm.Children.OfType(Of Button)
            ctr.IsEnabled = True
        Next

        btnSave.IsEnabled = False
    End Sub

    Public Sub InisialisasiEdit()
        For Each ctr In gridForm.Children.OfType(Of TextBox)
            ctr.IsEnabled = True
        Next

        For Each ctr In gridForm.Children.OfType(Of Button)
            ctr.IsEnabled = False
        Next

        txtKategoriID.IsEnabled = False
        btnSave.IsEnabled = True
        txtNamaKategori.Focus()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        kategoriVm = New KategoriViewModel

        viewKategori = CollectionViewSource.GetDefaultView(kategoriVm.ListKategori)
        Me.DataContext = viewKategori

        AddHandler Me.Loaded, AddressOf MasterKategori_Loaded
        AddHandler btnEdit.Click, AddressOf btnEdit_Click
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As RoutedEventArgs)
        InisialisasiEdit()
    End Sub

    Private Sub MasterKategori_Loaded(sender As Object, e As RoutedEventArgs)
        InisialisasiAwal()
    End Sub
End Class
