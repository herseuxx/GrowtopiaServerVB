Public Class fixColors
    Public Shared Function fixColors(ByVal text As String) As String
        Dim ret As String = ""
        Dim colorLevel As Integer = 0

        For i As Integer = 0 To text.Length - 1

            If text(i) = "`"c Then
                ret += text(i)
                If i + 1 < text.Length Then ret += text(i + 1)

                If i + 1 < text.Length AndAlso text(i + 1) = "`"c Then
                    colorLevel -= 1
                Else
                    colorLevel += 1
                End If

                i += 1
            Else
                ret += text(i)
            End If
        Next

        For i As Integer = 0 To colorLevel - 1
            ret += "``"
        Next

        For i As Integer = 0 To colorLevel + 1
            ret += "`w"
        Next

        Return ret
    End Function

End Class
