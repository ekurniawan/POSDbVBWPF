Imports BO
Imports System.Data.SqlClient
Imports Dapper

Public Class BarangDAL
    Private conn As SqlConnection

    Public Sub New()
        conn = New SqlConnection(HelperKoneksi.GetConnectionString())
    End Sub

    Public Function GetAll() As IEnumerable(Of Barang)
        Dim strSql = "select * from Barang left join Kategori 
                      on Barang.KategoriId=Kategori.KategoriId"

        Dim results = conn.Query(Of Barang, Kategori, Barang)(strSql, Function(b, k)
                                                                          b.Kategori = k
                                                                          Return b
                                                                      End Function, splitOn:="KategoriId")
        Return results
    End Function

    Public Function GetById(_kodeBarang As String) As Barang
        Dim strSql = "select * from Barang left join Kategori 
                      on Barang.KategoriId=Kategori.KategoriId 
                      where Barang.KodeBarang = @KodeBarang"

        Dim param = New With {.KodeBarang = _kodeBarang}
        Dim result = conn.Query(Of Barang, Kategori, Barang)(strSql, Function(b, k)
                                                                         b.Kategori = k
                                                                         Return b
                                                                     End Function, param, splitOn:="KategoriId").SingleOrDefault
        Return result
    End Function

    Public Sub Insert(_barang As Barang)
        Dim strSql = "insert into Barang(KodeBarang,KategoriId,NamaBarang,HargaBeli,HargaJual,Stok) 
                      values(@KodeBarang,@KategoriId,@NamaBarang,@HargaBeli,@HargaJual,@Stok)"

        Dim param = New With {.KodeBarang = _barang.KodeBarang,
            .KategoriId = _barang.KategoriId, .NamaBarang = _barang.NamaBarang,
            .HargaBeli = _barang.HargaBeli, .HargaJual = _barang.HargaJual, .Stok = _barang.Stok}

        Try
            conn.Execute(strSql, param)
        Catch sqlEx As SqlException
            Throw New Exception("Error : " & sqlEx.Number & " " & sqlEx.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub Update(_barang As Barang)
        Dim strSql = "update Barang set KategoriId=@KategoriId,NamaBarang=@NamaBarang,HargaBeli=@HargaBeli,HargaJual=@HargaJual,Stok=@Stok 
                      where KodeBarang=@KodeBarang"

        Dim param = New With {.KodeBarang = _barang.KodeBarang,
            .KategoriId = _barang.KategoriId, .NamaBarang = _barang.NamaBarang,
            .HargaBeli = _barang.HargaBeli, .HargaJual = _barang.HargaJual, .Stok = _barang.Stok}

        Try
            conn.Execute(strSql, param)
        Catch sqlEx As SqlException
            Throw New Exception("Error : " & sqlEx.Number & " " & sqlEx.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub Delete(_barang As Barang)
        Dim strSql = "delete Barang where KodeBarang=@KodeBarang"
        Dim param = New With {.KodeBarang = _barang.KodeBarang}

        Try
            conn.Execute(strSql, param)
        Catch sqlEx As SqlException
            Throw New Exception("Error : " & sqlEx.Number & " " & sqlEx.Message)
        Finally
            conn.Close()
        End Try
    End Sub
End Class
