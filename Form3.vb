Imports System.IO
Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' MessageBox.Show(Form1.ciktiYolu & "\" & Form1.projeAdi & "oluşturuldu.")
        Directory.CreateDirectory(Form1.ciktiYolu & "\" & Form1.projeAdi)

        For i As Integer = 0 To Form2.resimler.Count - 1
            My.Computer.FileSystem.CopyFile(Form2.resimler(i), Form1.ciktiYolu & "\" & Form1.projeAdi & "\resim" & i & ".jpg", overwrite:=False)
            ProgressBar1.Value = i * (100 / (Form2.resimler.Count - 1))
            RichTextBox1.Text += Form2.resimler(i) & " Kopyalandı. Hedef Konum : " & Form1.ciktiYolu & "\" & Form1.projeAdi & vbNewLine
        Next
        RichTextBox1.Text += "Galeri oluşturma tamamlandı!" & TimeOfDay.Hour & ":" & TimeOfDay.Minute & vbNewLine & "Programı kapatabilirsiniz"



        Dim html As String = "<!DOCTYPE html>
<html>
    <head>
<title>Galeri</title>
    </head>
    <style>
      html, body, #container {
  margin: 0;
  width: 100%;
  height: 90%;
}
    </style>
    <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/photo-sphere-viewer@4/dist/photo-sphere-viewer.min.css'/>
    <script src='https://cdn.jsdelivr.net/npm/three/build/three.min.js'></script>
    <script src='https://cdn.jsdelivr.net/npm/uevent@2/browser.min.js'></script>
    <script src='https://cdn.jsdelivr.net/npm/photo-sphere-viewer@4/dist/photo-sphere-viewer.min.js'></script>
    <body>
        <div id='container'></div>"

        For i As Integer = 0 To Form2.resimler.Count - 1
            html += "<button onclick='resimfunc" & i & "();'>Resim</button>"
        Next

        html += "</body> <script>"

        For i As Integer = 0 To Form2.resimler.Count - 1
            html += " var resimVar" & i & " = 'resim" & i & ".jpg';"

        Next

        html += "var div = document.getElementById('container');
    var PSV = new PhotoSphereViewer.Viewer({
    panorama: resimVar0,
    container: div,
    defaultLat:    0.2,}); "
        For i As Integer = 0 To Form2.resimler.Count - 1
            html += "function resimfunc" & i & "(){
            PSV.setPanorama(resimVar" & i & ")
            .then(() => alert('Tamamlandı'));}"
        Next

        html += "</script></html>"

        File.WriteAllText(Form1.ciktiYolu & "\" & Form1.projeAdi & "\index.html", html)




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
        Process.Start(Form1.ciktiYolu & "\" & Form1.projeAdi)
    End Sub


End Class