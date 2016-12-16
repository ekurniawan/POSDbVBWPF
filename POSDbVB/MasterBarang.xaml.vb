Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports BO
Imports DAL

Public Class MasterBarang
    Private _barangVm As BarangViewModel
    Private viewBarang As ICollectionView
    Private viewKategori As ICollectionView

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        _barangVm = New BarangViewModel()
        viewBarang = CollectionViewSource.GetDefaultView(_barangVm.ListBarang)
        viewKategori = CollectionViewSource.GetDefaultView(_barangVm.ListKategori)

        Me.DataContext = viewBarang
        cmbKategori.ItemsSource = viewKategori
    End Sub
End Class
