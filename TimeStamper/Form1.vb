Public Class Form1
    Dim timez As New DateTime
    Dim timed As New TimeSpan
    Private Declare Function GetKeyPress Lib "user32" Alias "GetAsyncKeyState" (ByVal key As Integer) As Integer
    Dim streamz As IO.FileStream
    Dim datez As String

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If GetKeyPress(Keys.NumPad1) Then
            timez = System.DateTime.Now
            Label1.Text = "Started: " & timez
            GC.Collect()
            My.Computer.FileSystem.WriteAllText(datez, "---Time Reset---" & Chr(13), True)
            GC.Collect()
        End If
        If GetKeyPress(Keys.NumPad0) Then
            timed = System.DateTime.Now - timez
            Label2.Text = "Last time Index: " & timed.ToString
            Label3.Text = "Last index: " & System.DateTime.Now
            GC.Collect()
            My.Computer.FileSystem.WriteAllText(datez, System.DateTime.Now & " - " & timed.ToString & Chr(13), True)
            GC.Collect()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        timez = System.DateTime.Now
        datez = IO.Directory.GetCurrentDirectory() & " \" & timez.Date.Month & timez.Date.Day & timez.Date.Year & ".txt"
        If IO.File.Exists(datez) Then
            IO.File.Create(datez)
        End If
        timez = System.DateTime.Now
        Label1.Text = "Time Started: " & timez
    End Sub
End Class
