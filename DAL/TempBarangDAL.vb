Imports BO
Imports System.Data.SqlClient
Imports Dapper

Public Class TempBarangDAL
    Private conn As SqlConnection

    Public Sub New()
        conn = New SqlConnection(HelperKoneksi.GetConnectionString())
    End Sub

    Public Sub Insert(_barang As TempBarang)
        Dim strSql = "insert into TempBarang(KodeBarang,KategoriId,NamaBarang,HargaBeli,HargaJual,Stok,IsReady) 
                      values(@KodeBarang,@KategoriId,@NamaBarang,@HargaBeli,@HargaJual,@Stok,@IsReady)"

        Dim param = New With {.KodeBarang = _barang.KodeBarang,
            .KategoriId = _barang.KategoriId, .NamaBarang = _barang.NamaBarang,
            .HargaBeli = _barang.HargaBeli, .HargaJual = _barang.HargaJual, .Stok = _barang.Stok, .IsReady = _barang.IsReady}

        Try
            conn.Execute(strSql, param)
        Catch sqlEx As SqlException
            Throw New Exception("Error : " & sqlEx.Number & " " & sqlEx.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub Update(_barang As TempBarang)
        Dim strSql = "update TempBarang set KategoriId=@KategoriId,NamaBarang=@NamaBarang,HargaBeli=@HargaBeli,HargaJual=@HargaJual,Stok=@Stok,IsReady=@IsReady
                      where KodeBarang=@KodeBarang"

        Dim param = New With {.KodeBarang = _barang.KodeBarang,
            .KategoriId = _barang.KategoriId, .NamaBarang = _barang.NamaBarang,
            .HargaBeli = _barang.HargaBeli, .HargaJual = _barang.HargaJual, .Stok = _barang.Stok, .IsReady = _barang.IsReady}

        Try
            conn.Execute(strSql, param)
        Catch sqlEx As SqlException
            Throw New Exception("Error : " & sqlEx.Number & " " & sqlEx.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub Delete(_barang As TempBarang)
        Dim strSql = "delete TempBarang where KodeBarang=@KodeBarang"
        Dim param = New With {.KodeBarang = _barang.KodeBarang}

        Try
            conn.Execute(strSql, param)
        Catch sqlEx As SqlException
            Throw New Exception("Error : " & sqlEx.Number & " " & sqlEx.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Function CekBarang() As IEnumerable(Of TempBarang)
        Dim strSql = "select * from TempBarang"
        Dim results = conn.Query(Of TempBarang)(strSql)
        Return results
    End Function
End Class
