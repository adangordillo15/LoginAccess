Imports DataAccess
Public Class UserModel
    Dim userDao As New UserDao()
    Public Function Login(email As String, password As String) As Boolean
        Return userDao.Login(email, password)
    End Function
End Class
