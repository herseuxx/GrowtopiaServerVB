Imports System
Imports System.Security.Cryptography
Imports System.Text
Imports ENet.Managed
Module Program
    Public server As ENetHost
    Public cId As Integer = 1
    Public itemsDat As Byte()
    Public itemsDatSize As Integer = 0
    Public peers As List(Of ENetPeer) = New List(Of ENetPeer)()
    Public Function hashPassword(ByVal password As String) As String
        Using sha256Hash As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim builder As StringBuilder = New StringBuilder()

            For i As Integer = 0 To bytes.Length - 1
                builder.Append(bytes(i).ToString("x2"))
            Next

            Return builder.ToString()
        End Using
    End Function

    Public Function verifyPassword(ByVal password As String, ByVal hash As String) As Boolean
        Return hashPassword(password) = hash
    End Function
    Public Sub sendData(ByVal peer As ENetPeer, ByVal num As Integer, ByVal data As Byte(), ByVal len As Integer)
        Dim packet As Byte() = New Byte(len + 5 - 1) {}
        Array.Copy(BitConverter.GetBytes(num), 0, packet, 0, 4)

        If data IsNot Nothing Then
            Array.Copy(data, 0, packet, 4, len)
        End If

        packet(4 + len) = 0
        peer.Send(packet, 0, ENetPacketFlags.Reliable)
        server.Flush()
    End Sub

    Public Function getPacketId(ByVal data As Byte()) As Integer
        Return data(0)
    End Function

    Public Function getPacketData(ByVal data As Byte()) As Byte()
        Return data.Skip(4).ToArray()
    End Function
    Public Function text_encode(ByVal text As String) As String
        Dim ret As String = ""
        Dim i As Integer = 0

        While text And i <> 0

            Select Case text(i)
                Case vbLf
                    ret += "\n"
                Case vbTab
                    ret += "\t"
                Case vbBack
                    ret += "\b"
                Case "\"c
                    ret += "\\"
                Case vbCr
                    ret += "\r"
                Case Else
                    ret += text(i)
            End Select

            i += 1
        End While

        Return ret
    End Function
    Public Function explode(ByVal delimiter As String, ByVal str As String) As String()
        Return str.Split(delimiter.ToCharArray())
    End Function
    Public Function getStrUpper(ByVal txt As String) As String
        Dim ret As String = ""

        For Each c As Char In txt
            ret += c.ToString().ToUpper()
        Next

        Return ret
    End Function
    Public Sub saveAllWorlds()
        Console.WriteLine("Saving worlds...")
        '''saveAll.saveAll()
        Console.WriteLine("Worlds saved!")
    End Sub
    Sub Main(args As String())
        Console.WriteLine("Hello World!")
    End Sub
End Module
