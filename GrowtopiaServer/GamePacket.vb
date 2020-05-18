Imports System.Text

Public Class GamePacket
    Public Shared Function ch2n(ByVal x As Char) As Byte
        Select Case x
            Case "0"c
                Return 0
            Case "1"c
                Return 1
            Case "2"c
                Return 2
            Case "3"c
                Return 3
            Case "4"c
                Return 4
            Case "5"c
                Return 5
            Case "6"c
                Return 6
            Case "7"c
                Return 7
            Case "8"c
                Return 8
            Case "9"c
                Return 9
            Case "A"c
                Return 10
            Case "B"c
                Return 11
            Case "C"c
                Return 12
            Case "D"c
                Return 13
            Case "E"c
                Return 14
            Case "F"c
                Return 15
        End Select

        Return 0
    End Function
    Public Structure GamePacket
        Public data As Byte()
        Public len As Integer
        Public indexes As Integer
    End Structure
    Public Shared Function appendFloat(ByVal p As GamePacket, ByVal val As Single) As GamePacket
        Dim data As Byte() = New Byte(p.len + 2 + 4 - 1) {}
        Array.Copy(p.data, 0, data, 0, p.len)
        Dim num As Byte() = BitConverter.GetBytes(val)
        data(p.len) = CByte(p.indexes)
        data(p.len + 1) = 1
        Array.Copy(num, 0, data, p.len + 2, 4)
        p.len = p.len + 2 + 4
        p.indexes += 1
        p.data = data
        Return p
    End Function
    Public Shared Function appendFloat(ByVal p As GamePacket, ByVal val As Single, ByVal val2 As Single) As GamePacket
        Dim data As Byte() = New Byte(p.len + 2 + 8 - 1) {}
        Array.Copy(p.data, 0, data, 0, p.len)
        Dim fl1 As Byte() = BitConverter.GetBytes(val)
        Dim fl2 As Byte() = BitConverter.GetBytes(val2)
        data(p.len) = CByte(p.indexes)
        data(p.len + 1) = 3
        Array.Copy(fl1, 0, data, p.len + 2, 4)
        Array.Copy(fl2, 0, data, p.len + 6, 4)
        p.len = p.len + 2 + 8
        p.indexes += 1
        p.data = data
        Return p
    End Function
    Public Shared Function appendFloat(ByVal p As GamePacket, ByVal val As Single, ByVal val2 As Single, ByVal val3 As Single) As GamePacket
        Dim data As Byte() = New Byte(p.len + 2 + 12 - 1) {}
        Array.Copy(p.data, 0, data, 0, p.len)
        Dim fl1 As Byte() = BitConverter.GetBytes(val)
        Dim fl2 As Byte() = BitConverter.GetBytes(val2)
        Dim fl3 As Byte() = BitConverter.GetBytes(val3)
        data(p.len) = CByte(p.indexes)
        data(p.len + 1) = 3
        Array.Copy(fl1, 0, data, p.len + 2, 4)
        Array.Copy(fl2, 0, data, p.len + 6, 4)
        Array.Copy(fl3, 0, data, p.len + 10, 4)
        p.len = p.len + 2 + 12
        p.indexes += 1
        p.data = data
        Return p
    End Function
    Public Shared Function appendInt(ByVal p As GamePacket, ByVal val As Int32) As GamePacket
        Dim data As Byte() = New Byte(p.len + 2 + 4 - 1) {}
        Array.Copy(p.data, 0, data, 0, p.len)
        Dim num As Byte() = BitConverter.GetBytes(val)
        data(p.len) = CByte(p.indexes)
        data(p.len + 1) = 9
        Array.Copy(num, 0, data, p.len + 2, 4)
        p.len = p.len + 2 + 4
        p.indexes += 1
        p.data = data
        Return p
    End Function
    Public Shared Function appendIntx(ByVal p As GamePacket, ByVal val As Int32) As GamePacket
        Dim data As Byte() = New Byte(p.len + 2 + 4 - 1) {}
        Array.Copy(p.data, 0, data, 0, p.len)
        Dim num As Byte() = BitConverter.GetBytes(val)
        data(p.len) = CByte(p.indexes)
        data(p.len + 1) = 5
        Array.Copy(num, 0, data, p.len + 2, 4)
        p.len = p.len + 2 + 4
        p.indexes += 1
        p.data = data
        Return p
    End Function
    Public Shared Function appendString(ByVal p As GamePacket, ByVal str As String) As GamePacket
        Dim data As Byte() = New Byte(p.len + 2 + str.Length + 4 - 1) {}
        Array.Copy(p.data, 0, data, 0, p.len)
        Dim strn As Byte() = Encoding.ASCII.GetBytes(str)
        data(p.len) = CByte(p.indexes)
        data(p.len + 1) = 2
        Dim len As Byte() = BitConverter.GetBytes(str.Length)
        Array.Copy(len, 0, data, p.len + 2, 4)
        Array.Copy(strn, 0, data, p.len + 6, str.Length)
        p.len = p.len + 2 + str.Length + 4
        p.indexes += 1
        p.data = data
        Return p
    End Function
    Public Shared Function createPacket() As GamePacket
        Dim data As Byte() = New Byte(61) {}
        Dim asdf As String = "0400000001000000FFFFFFFF00000000080000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
        For i As Integer = 0 To asdf.Length - 1 Step 2
            Dim x As Byte = ch2n(asdf(i))
            x = CByte((x << 4))
            x += ch2n(asdf(i + 1))
            data(i / 2) = x
            If asdf.Length > 61 * 2 Then
                Throw New System.Exception("?")
            End If
        Next
        Dim packet As GamePacket
        packet.data = data
        packet.len = 61
        packet.indexes = 0
        Return packet
    End Function
    Public Shared Function packetEnd(ByVal p As GamePacket) As GamePacket
        Dim n As Byte() = New Byte(p.len + 1 - 1) {}
        Array.Copy(p.data, 0, n, 0, p.len)
        p.data = n
        p.data(p.len) = 0
        p.len += 1
        p.data(56) = CByte(p.indexes)
        p.data(60) = CByte(p.indexes)
        Return p
    End Function

End Class
