Imports System.ComponentModel

Public Class Kategori
    Implements INotifyPropertyChanged

    Private _kategoriId As Integer
    Public Property KategoriId() As Integer
        Get
            Return _kategoriId
        End Get
        Set(ByVal value As Integer)
            If value <> _kategoriId Then
                _kategoriId = value
                NotifyPropertyChanged("KategoriId")
            End If
        End Set
    End Property

    Private _namaKategori As String
    Public Property NamaKategori() As String
        Get
            Return _namaKategori
        End Get
        Set(ByVal value As String)
            If value <> _namaKategori Then
                _namaKategori = value
                NotifyPropertyChanged("NamaKategori")
            End If
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private Sub NotifyPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
