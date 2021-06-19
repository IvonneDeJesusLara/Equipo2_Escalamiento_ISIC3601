Public Class Form1
    Dim acumulador As String
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles txtResultado.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'DECLARAMOS LAS MATRICES 1.LA MATRIZ SUSTITUIDA ---> 2.LOS PUNTOS ---> 3.MATRIZ RESULTANTE 
        Dim matrizInicial(3, 3) As Integer
        Dim matrizDos(3, 3) As Integer
        Dim matrizFinal(3, 3) As Integer
        Dim x, y As Integer

        If Trim(txtX.Text) = "" Or Trim(txtY.Text) = "" Then
            vacio()
        Else
            'CORRESPONDE A S
            x = txtX.Text
            y = txtY.Text
            'INICIAMOS LAS MATRIZ SUSTITUIDA EN 5,2
            matrizInicial = {{x, 0, 0}, {0, y, 0}, {0, 0, 1}}
            'INIIAMOS LA MATRIZ DE REFERENCIA DE LA FIGURA
            matrizDos = {{1, 1, 2}, {1, 3, 2}, {1, 1, 1}}

            'REALIZAMOS LAS OPERACIONES
            For l = 0 To 2 Step +1
                For w = 0 To 2 Step +1
                    For v = 0 To 2 Step +1
                        'REALIZAMOS LA MULTIPLICACION DE DE LA MATRIZ SUSTITUIDA (INICIAL) Y LA MATRIZ DE COORDENADAS (DOS)
                        'FILA X COLUMNA
                        matrizFinal(l, w) = matrizFinal(l, w) + (matrizInicial(l, v) * matrizDos(v, w))
                    Next
                Next

            Next


            'IMPRIMIMOS EL MODELO A SEGUIR 
            acumulador = ("" & Space(4) + "MHS" & vbCrLf +
                                 "S      0      0" & vbCrLf +
                                 "0      S      0" & vbCrLf +
                                 "0      0      1" & vbCrLf & vbCrLf +
                                 "S =(" + (matrizInicial(0, 0) & Space(0)) + "," + (matrizInicial(1, 1) & Space(0)) + ")" & vbCrLf)
            'IMPRIMIMOS LAS MATRICES ---> 1.LA MATRIZ SUSTITUIDA ---> 2.LOS PUNTOS ---> 3.MATRIZ RESULTANTE 
            acumulador = acumulador + ("" & vbCrLf + "  MHS . S" & Space(20) + " MH . C" & Space(20) + "RESULTADO" & vbCrLf)
            For l = 0 To 2 Step +1
                For t = 0 To 2 Step +1
                    acumulador = acumulador + (matrizInicial(l, t) & Space(6))
                Next
                acumulador = acumulador + ("" & Space(10))
                For u = 0 To 2 Step +1
                    acumulador = acumulador + (matrizDos(l, u) & Space(6))
                Next
                'Console.WriteLine()
                acumulador = acumulador + ("" & Space(10))
                For c = 0 To 2 Step +1
                    acumulador = acumulador + (matrizFinal(l, c) & Space(6))
                Next
                acumulador = acumulador + " " & vbCrLf
            Next
            'IMPRIMIMOS LOS PUNTOS RESULTANTES
            acumulador = acumulador + (" " & vbCrLf + "PUNTOS RESULTANTES: " & vbCrLf)
            txtResultado.Text = (acumulador & vbCrLf +
                "P1:  (" + (matrizFinal(0, 0) & Space(0)) + "," + (matrizFinal(1, 0) & Space(0)) + ") " & vbCrLf +
            "P2:  (" + (matrizFinal(0, 1) & Space(0)) + "," + (matrizFinal(1, 1) & Space(0)) + ") " & vbCrLf +
            "P3:  (" + (matrizFinal(0, 2) & Space(0)) + "," + (matrizFinal(1, 2) & Space(0)) + ") " & vbCrLf)
        End If
    End Sub


    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim RESUL As String
        RESUL = MsgBox("¿ESTAS SEGURO DE QUERER SALIR?", vbYesNo + vbQuestion, "Cerrar programa")
        Select Case RESUL
            Case vbYes
                'SI QUIERO SALIR
                Me.Close()
            Case vbNo
                'NO QUIERO SALIR 
                ' Me.Show()
        End Select
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar()
    End Sub
    Public Sub vacio()
        MsgBox("VERIFICA QUE LOS CAMPOS NO SE ENCUENTREN VACIOS")
        limpiar()
    End Sub
    Public Sub limpiar()
        acumulador = Nothing
        txtResultado.Text = ""
        txtY.Text = ""
        txtX.Text = ""
    End Sub

End Class
