Imports GrowtopiaServer.flush
Public Class saveAll
    Public worlds As WorldInfo() = New WorldInfo() {}
    Public Sub saveAll()
        For i As Integer = 0 To worlds.Length - 1
            '''flush(worlds(i))
        Next

        worlds = New WorldInfo() {}
    End Sub
End Class
