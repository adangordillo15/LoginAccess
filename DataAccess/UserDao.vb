Imports Npgsql
Imports Common
Public Class UserDao
    Inherits ConnectionToNpgsql
    Public Function Login(email As String, pass As String) As Boolean
        Using connection = GetConnection()
            connection.Open()
            Using command = New NpgsqlCommand()
                command.Connection = connection
                command.CommandText = "select *from users where email=@email and password=@pass"
                command.Parameters.AddWithValue("@email", email)
                command.Parameters.AddWithValue("@password", pass)
                command.CommandType = CommandType.Text
                Dim reader = command.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read() 'Obtenemos los datos de la columna y asignamos a los campos de usuario activo en cache'
                        ActiveUser.email = reader.GetString(0)
                        ActiveUser.password = reader.GetString(1)
                    End While
                    reader.Dispose()
                    Return True
                Else
                    Return False
                End If
            End Using
        End Using
    End Function
End Class
