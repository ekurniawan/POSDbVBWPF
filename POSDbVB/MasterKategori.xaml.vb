Imports System.ComponentModel
Imports BO
Imports DAL

Public Class MasterKategori

    Private kategoriVm As KategoriViewModel
    Private viewKategori As ICollectionView

    Private Sub InisialisasiAwal()
        For Each ctr In gridForm.Children.OfType(Of TextBox)
            ctr.IsEnabled = False
        Next

        For Each ctr In stackButton.Children.OfType(Of Button)
            ctr.IsEnabled = True
        Next

        btnSave.IsEnabled = False
    End Sub

    Public Sub InisialisasiEdit()
        For Each ctr In gridForm.Children.OfType(Of TextBox)
            ctr.IsEnabled = True
        Next

        For Each ctr In stackButton.Children.OfType(Of Button)
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
        AddHandler btnSave.Click, AddressOf btnSave_Click
        AddHandler btnNew.Click, AddressOf btnNew_Click
        AddHandler btnDelete.Click, AddressOf btnDelete_Click
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As RoutedEventArgs)
        Dim delData = TryCast(viewKategori.CurrentItem, Kategori)
        If MessageBox.Show("Apakah anda akan mendelete data kategori " & delData.NamaKategori,
                           "Konfirmasi", MessageBoxButton.YesNo, MessageBoxImage.Question,
                           MessageBoxResult.No) = MessageBoxResult.Yes Then

            Try
                Dim _kategoriDal As New KategoriDAL
                _kategoriDal.Delete(delData)
                kategoriVm.ListKategori.Remove(delData)
            Catch ex As Exception
                MessageBox.Show("Ditemukan kesalahan : " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As RoutedEventArgs)
        Dim newKategori As New Kategori
        kategoriVm.ListKategori.Add(newKategori)
        viewKategori.MoveCurrentToLast()
        InisialisasiEdit()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        Dim _kategoriDAL As New KategoriDAL
        Dim result = _kategoriDAL.GetById(CInt(txtKategoriID.Text))

        Try
            If Not result Is Nothing Then
                '_kategoriDAL.Update(New Kategori With {.KategoriId = CInt(txtKategoriID.Text), .NamaKategori = txtNamaKategori.Text})
                Dim editRow = TryCast(viewKategori.CurrentItem, Kategori)
                _kategoriDAL.Update(editRow)
            Else
                Dim newRow = TryCast(viewKategori.CurrentItem, Kategori)
                Dim _kategoriId = _kategoriDAL.Insert(newRow)
                newRow.KategoriId = _kategoriId
            End If
            InisialisasiAwal()
        Catch ex As Exception
            MessageBox.Show("Ditemukan kesalahan : " & ex.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As RoutedEventArgs)
        InisialisasiEdit()
    End Sub

    Private Sub MasterKategori_Loaded(sender As Object, e As RoutedEventArgs)
        InisialisasiAwal()
    End Sub
End Class
