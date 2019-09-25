Imports Npgsql


Public MustInherit Class ConnectionToNpgsql
    Private connectionString As String
    Protected Sub New()
        connectionString = "Server=127.0.0.1;Port=5432;Database=wstorages_site;User Id=postgres; Password=root;"
    End Sub
    Protected Function GetConnection() As NpgsqlConnection
        Return New NpgsqlConnection(connectionString)
    End Function

End Class
