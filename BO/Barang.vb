Imports System.ComponentModel

Public Class Barang
    Implements INotifyPropertyChanged

    Private _kodeBarang As String
    Public Property KodeBarang() As String
        Get
            Return _KodeBarang
        End Get
        Set(ByVal value As String)
            If value <> _kodeBarang Then
                _kodeBarang = value
                NotifyPropertyChanged("KodeBarang")
            End If
        End Set
    End Property


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

    Private _namaBarang As String
    Public Property NamaBarang() As String
        Get
            Return _namaBarang
        End Get
        Set(ByVal value As String)
            If value <> _namaBarang Then
                _namaBarang = value
                NotifyPropertyChanged("NamaBarang")
            End If
        End Set
    End Property


    Private _hargaBeli As Decimal
    Public Property HargaBeli() As Decimal
        Get
            Return _hargaBeli
        End Get
        Set(ByVal value As Decimal)
            If value <> _hargaBeli Then
                _hargaBeli = value
                NotifyPropertyChanged("HargaBeli")
            End If
        End Set
    End Property

    Private _hargaJual As Decimal
    Public Property HargaJual() As Decimal
        Get
            Return _hargaJual
        End Get
        Set(ByVal value As Decimal)
            If value <> _hargaJual Then
                _hargaJual = value
                NotifyPropertyChanged("HargaJual")
            End If
        End Set
    End Property

    Private _stok As Integer
    Public Property Stok() As Integer
        Get
            Return _stok
        End Get
        Set(ByVal value As Integer)
            If value <> _stok Then
                _stok = value
                NotifyPropertyChanged("Stok")
            End If
        End Set
    End Property

    Private _isReady As Nullable(Of Boolean)
    Public Property IsReady() As Nullable(Of Boolean)
        Get
            Return _isReady
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            _isReady = value
            NotifyPropertyChanged("IsReady")
        End Set
    End Property

    Private _kategori As Kategori
    Public Property Kategori() As Kategori
        Get
            Return _kategori
        End Get
        Set(ByVal value As Kategori)
            _kategori = value
            NotifyPropertyChanged("Kategori")
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private Sub NotifyPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
