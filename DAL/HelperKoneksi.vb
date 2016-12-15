Imports System.Configuration

Module HelperKoneksi

    Public Function GetConnectionString() As String
        Return ConfigurationManager.ConnectionStrings("POSConnectionString").ConnectionString
    End Function

End Module
