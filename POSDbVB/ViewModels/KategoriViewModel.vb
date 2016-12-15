Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports BO
Imports DAL

Public Class KategoriViewModel
    Implements INotifyPropertyChanged

    Private _listKategori As ObservableCollection(Of Kategori)
    Public Property ListKategori() As ObservableCollection(Of Kategori)
        Get
            Return _listKategori
        End Get
        Set(value As ObservableCollection(Of Kategori))
            _listKategori = value
            NotifyPropertyChanged("ListKategori")
        End Set
    End Property

    Public Sub New()
        Dim _kategoriDal As New KategoriDAL
        ListKategori = New ObservableCollection(Of Kategori)(_kategoriDal.GetAll())
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private Sub NotifyPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
