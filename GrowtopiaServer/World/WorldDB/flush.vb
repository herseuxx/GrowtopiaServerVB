Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class flush
    Public Sub flush(ByVal info As WorldInfo)
        Dim path As String = "worlds/" & info.name & ".json"
        Dim tiles As JArray = New JArray()
        Dim square As Integer = info.width * info.height

        For i As Integer = 0 To square - 1
            Dim tile As JObject = New JObject(New JProperty("fg", info.items(i).foreground), New JProperty("bg", info.items(i).background))
            tiles.Add(tile)
        Next

        Dim j As JObject = New JObject(New JProperty("name", info.name), New JProperty("width", info.width), New JProperty("height", info.height), New JProperty("owner", info.owner), New JProperty("isPublic", info.isPublic), New JProperty("tiles", tiles))
        File.WriteAllText(path, j.ToString())
    End Sub
End Class
