Imports BO
Imports System.Data.SqlClient
Imports Dapper


Public Class KategoriDAL

    Private conn As SqlConnection

    Public Sub New()
        conn = New SqlConnection(HelperKoneksi.GetConnectionString())
    End Sub

    Public Sub New(_conn As SqlConnection)
        conn = _conn
    End Sub

    Public Function GetAllClassic() As IEnumerable(Of Kategori)

        Using conn As New SqlConnection(HelperKoneksi.GetConnectionString())
            Dim lstKategori As New List(Of Kategori)

            Dim strSql = "select * from Kategori 
                          order by NamaKategori asc"

            Dim cmd As New SqlCommand(strSql, conn)
            conn.Open()
            Dim dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While (dr.Read())
                    lstKategori.Add(New Kategori With {
                                    .KategoriId = CInt(dr("KategoriId")),
                                    .NamaKategori = dr("NamaKategori").ToString()
                                    })
                End While
            End If
            dr.Close()
            cmd.Dispose()
            conn.Close()

            Return lstKategori
        End Using
    End Function

    Public Function GetAll() As IEnumerable(Of Kategori)
        Dim strSql = "select * from Kategori order by NamaKategori"
        Try
            Dim results = conn.Query(Of Kategori)(strSql)
            conn.Close()
            Return results
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function GetById(_kategoriId As Integer) As Kategori
        Dim strSql = "select * from Kategori 
                      where KategoriId=@KategoriId"
        Dim param = New With {.KategoriId = _kategoriId}
        Dim result = conn.Query(Of Kategori)(strSql, param).SingleOrDefault()
        conn.Close()

        Return result
    End Function

    Public Function GetAllByName(_namaKategori As Kategori) As IEnumerable(Of Kategori)
        Dim strSql = "select * from Kategori 
                      where NamaKategori like @NamaKategori"
        Dim param = New With {.NamaKategori = "%" & _namaKategori.NamaKategori + "%"}
        Dim results = conn.Query(Of Kategori)(strSql, param)
        conn.Close()
        Return results
    End Function

    Public Function Insert(_kategori As Kategori) As Integer
        Dim strSql = "insert into Kategori(NamaKategori) values(@NamaKategori);
                      select @@identity"

        Dim param = New With {.NamaKategori = _kategori.NamaKategori}
        Try
            Dim result = conn.ExecuteScalar(Of Integer)(strSql, param)
            Return result
        Catch sqlEx As SqlException
            Throw New Exception("Error : " & sqlEx.Number & " " & sqlEx.Message)
        Finally
            conn.Close()
        End Try
    End Function

    Public Sub Update(_kategori As Kategori)
        Dim strSql = "update Kategori set NamaKategori=@NamaKategori 
                      where KategoriId=@KategoriId"

        Dim param = New With {
                .NamaKategori = _kategori.NamaKategori,
                .KategoriId = _kategori.KategoriId
        }

        Try
            conn.Execute(strSql, param)
        Catch sqlEx As SqlException
            Throw New Exception("Error : " & sqlEx.Number & " " & sqlEx.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub Delete(_kategori As Kategori)
        Dim strSql = "delete from Kategori where KategoriId=@KategoriId"
        Dim param = New With {.KategoriId = _kategori.KategoriId}
        Try
            conn.Execute(strSql, param)
        Catch sqlEx As SqlException
            Throw New Exception("Error : " & sqlEx.Number & " " & sqlEx.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub InsertClassic(_kategori As Kategori)
        Using conn As New SqlConnection(HelperKoneksi.GetConnectionString())
            Dim strSql = "insert into Kategori(NamaKategori) values(@NamaKategori)"
            Dim cmd As New SqlCommand(strSql, conn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("NamaKategori", _kategori.NamaKategori)
            Try
                conn.Open()
                cmd.ExecuteNonQuery()
            Catch sqlEx As SqlException
                Throw New Exception("Error : " & sqlEx.Number & " " & sqlEx.Message)
            Catch ex As Exception
                Throw New Exception("Error : " & ex.Message)
            End Try
        End Using
    End Sub

End Class
