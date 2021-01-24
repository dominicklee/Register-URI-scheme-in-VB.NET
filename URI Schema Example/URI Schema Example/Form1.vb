Imports Microsoft.Win32

Public Class Form1
    Const UriScheme As String = "myapp"
    Const FriendlyName As String = "My App"

    Public Shared Sub RegisterUriScheme()
        Using key = Registry.CurrentUser.CreateSubKey("SOFTWARE\Classes\" & UriScheme)
            Dim applicationLocation As String = Application.ExecutablePath
            key.SetValue("", "URL:" & FriendlyName)
            key.SetValue("URL Protocol", "")

            Using defaultIcon = key.CreateSubKey("DefaultIcon")
                defaultIcon.SetValue("", applicationLocation & ",1")
            End Using

            Using commandKey = key.CreateSubKey("shell\open\command")
                commandKey.SetValue("", """" & applicationLocation & """ ""%1""")
            End Using
        End Using
    End Sub

    Public Shared Sub UnregisterUriScheme()
        If (UriScheme <> "") Then   'for safety since if UriScheme is blank, we would delete everything!
            Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\Classes\" & UriScheme)
        End If
    End Sub

    Public Shared Function getParams()
        'Parses and returns the info sent from URI scheme
        Dim args As String() = Environment.GetCommandLineArgs()
        Dim param As String = ""

        If args.Length > 0 Then
            For Each arg In args
                If arg.StartsWith(UriScheme & "://") Then
                    param = arg.Replace(UriScheme & "://", "")
                    Exit For
                End If
            Next
        End If
        Return param
    End Function

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim text As String = getParams()
        If (text <> "") Then
            MsgBox(text)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RegisterUriScheme()
        MsgBox("App registered!")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        UnregisterUriScheme()
        MsgBox("App unregistered!")
    End Sub
End Class
