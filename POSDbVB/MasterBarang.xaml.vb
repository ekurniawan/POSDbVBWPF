Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports BO
Imports DAL

Public Class MasterBarang
    Private _barangVm As BarangViewModel
    Private viewBarang As ICollectionView
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

        btnSave.IsEnabled = True
        txtKodeBarang.Focus()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        _barangVm = New BarangViewModel()
        viewBarang = CollectionViewSource.GetDefaultView(_barangVm.ListBarang)
        viewKategori = CollectionViewSource.GetDefaultView(_barangVm.ListKategori)

        Me.DataContext = viewBarang
        cmbKategori.ItemsSource = viewKategori

        AddHandler btnNew.Click, AddressOf btnNew_Click
        AddHandler btnSave.Click, AddressOf btnSave_Click
        AddHandler btnSavePermanen.Click, AddressOf btnSavePermanen_Click

        Dim _tempBarangDal As New TempBarangDAL
        Dim listBarang = _tempBarangDal.CekBarang()
        For Each brg In listBarang
            _barangVm.ListBarang.Add(New Barang With {.KodeBarang = brg.KodeBarang,
                                  .HargaJual = brg.HargaJual, .KategoriId = brg.KategoriId,
                                  .NamaBarang = brg.NamaBarang, .HargaBeli = brg.HargaBeli, .IsReady = brg.IsReady,
                                  .Stok = brg.Stok})
        Next

    End Sub

    Private Sub btnSavePermanen_Click(sender As Object, e As RoutedEventArgs)
        Dim _tempBarangDal As New TempBarangDAL
        Dim _barangDal As New BarangDAL
        Dim listTempBarang = _tempBarangDal.CekBarang()


        For Each brg In listTempBarang
            _barangDal.Insert(New Barang With {.KodeBarang = brg.KodeBarang,
                                  .HargaJual = brg.HargaJual, .KategoriId = brg.KategoriId,
                                  .NamaBarang = brg.NamaBarang, .HargaBeli = brg.HargaBeli, .IsReady = brg.IsReady,
                                  .Stok = brg.Stok})
            _tempBarangDal.Delete(brg)
        Next

    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        Dim _tempBarangDal As New TempBarangDAL
        Dim currBarang = TryCast(viewBarang.CurrentItem, Barang)
        Try
            _tempBarangDal.Insert(New TempBarang With {.KodeBarang = currBarang.KodeBarang,
                                  .HargaJual = currBarang.HargaJual, .KategoriId = currBarang.KategoriId,
                                  .NamaBarang = currBarang.NamaBarang, .HargaBeli = currBarang.HargaBeli, .IsReady = currBarang.IsReady,
                                  .Stok = currBarang.Stok})
            InisialisasiAwal()
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message)
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As RoutedEventArgs)
        Dim newBarang As New Barang
        _barangVm.ListBarang.Add(newBarang)
        viewBarang.MoveCurrentToLast()

        InisialisasiEdit()
    End Sub
End Class
