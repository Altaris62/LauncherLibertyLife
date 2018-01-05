Imports Microsoft.Win32

Public Class Form1
    Dim directory As String = False

    Private Sub Unrar(ByVal filepath As String, ByVal WorkingDir As String)
        Dim objRegKey As RegistryKey
        objRegKey = Registry.ClassesRoot.OpenSubKey("WinRAR\Shell\Open\Command")
        Dim obj As Object = objRegKey.GetValue("")
        Dim objRarPath As String = obj.ToString()

        objRarPath = objRarPath.Substring(1, objRarPath - 7)

        objRegKey.Close()

        Dim objArgs As String
        objArgs = " X " & " " & filepath & " " + " " + WorkingDir

        Dim objStartInfo As New ProcessStartInfo()
        objStartInfo.UseShellExecute = False
        objStartInfo.FileName = objRarPath
        objStartInfo.Arguments = objArgs
        objStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        objStartInfo.WorkingDirectory = WorkingDir & ""

        Dim objPro As New Process()
        objPro.StartInfo = objStartInfo
        objPro.Start()

    End Sub

    Private Sub setA3Directory()
        Dim FolderBrowserDialog As New FolderBrowserDialog
        FolderBrowserDialog.ShowDialog()
        directory = FolderBrowserDialog.SelectedPath

        If directory.Equals("") Then

            Exit Sub
        End If

        My.Computer.FileSystem.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LauncherLibertyLife")
        My.Computer.FileSystem.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LauncherLibertyLife\directory.a3", directory, False)

    End Sub


    Private Sub FlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton1.Click
        Process.Start("https://forum.liberty-life.ovh")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LauncherLibertyLife\directory.a3") Then
            directory = My.Computer.FileSystem.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LauncherLibertyLife\directory.a3")
        Else
            MsgBox("Vous devez selectionnez le chemin d'accès de votre dossier ARMA III", MsgBoxStyle.Exclamation, "Erreur")
            setA3Directory()
        End If
    End Sub

    Private Sub FlatButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton3.Click
        If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LauncherLibertyLife\directory.a3") Then
            Process.Start(My.Computer.FileSystem.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LauncherLibertyLife\directory.a3") & "\arma3_x64.exe")
        Else
            MsgBox("Vous devez selectionnez le chemin d'accès de votre dossier ARMA III", MsgBoxStyle.Exclamation, "Erreur")
            setA3Directory()
        End If
    End Sub

    Private Sub FlatButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FlatButton2.Click
        If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\LauncherLibertyLife\directory.a3") Then

        Else
            MsgBox("Vous devez selectionnez le chemin d'accès de votre dossier ARMA III", MsgBoxStyle.Exclamation, "Erreur")
            setA3Directory()
        End If
    End Sub

    Private Sub FlatButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton5.Click

    End Sub

    Private Sub FlatButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton4.Click

    End Sub
End Class
