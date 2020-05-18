Imports GrowtopiaServer.WorldItem
Public Class WorldInfo
    Public width As Integer = 100
    Public height As Integer = 60
    Public name As String = "TEST"
    Public items As WorldItem()
    Public owner As String = ""
    Public isPublic As Boolean = False
    Public Shared Function generateWorld(ByVal name As String, ByVal width As Integer, ByVal height As Integer) As WorldInfo
        Dim world As WorldInfo = New WorldInfo()
        Dim rand As Random = New Random()
        world.name = name
        world.width = width
        world.height = height
        world.items = New WorldItem(world.width * world.height - 1) {}

        For i As Integer = 0 To world.width * world.height - 1

            If i >= 3800 AndAlso i < 5400 AndAlso rand.[Next](0, 50) = 0 Then
                world.items(i).foreground = 10
            ElseIf i >= 3700 AndAlso i < 5400 Then
                world.items(i).foreground = 2
            ElseIf i >= 5400 Then
                world.items(i).foreground = 8
            End If

            If i >= 3700 Then world.items(i).background = 14

            If i = 3650 Then
                world.items(i).foreground = 6
            ElseIf i >= 3600 AndAlso i < 3700 Then
                world.items(i).foreground = 0
            End If

            If i = 3750 Then world.items(i).foreground = 8
        Next

        Return world
    End Function
End Class
