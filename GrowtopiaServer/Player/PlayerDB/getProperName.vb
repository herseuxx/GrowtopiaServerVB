Imports System.Text

Public Class getProperName
    Public Shared Function getProperName(ByVal name As String) As String
        Dim newS As String = name.ToLower()
        Dim ret = New StringBuilder()

        For i As Integer = 0 To newS.Length - 1

            If newS(i) = "`"c Then
                i += 1
            Else
                ret.Append(newS(i))
            End If
        Next

        Dim ret2 = New StringBuilder()

        For Each c As Char In ret.ToString()
            If (c >= "a"c AndAlso c <= "z"c) OrElse (c >= "0"c AndAlso c <= "9"c) Then ret2.Append(c)
        Next

        Return ret2.ToString()
    End Function
End Class
