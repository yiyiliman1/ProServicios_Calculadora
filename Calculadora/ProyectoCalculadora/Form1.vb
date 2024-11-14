Public Class formPrincipal

    ' Variables globales para almacenar los valores numéricos y la operación en curso
    Dim valor1 As Double    ' Primer número introducido por el usuario
    Dim valor2 As Double    ' Segundo número introducido por el usuario
    Dim operacion As String ' Operación seleccionada (+, -, *, /, ^, %)

    ' Evento para agregar números al display de la calculadora
    Private Sub btnNumero_Click(sender As Button, e As EventArgs) Handles btnComa.Click, btn9.Click, btn8.Click, btn7.Click, btn6.Click, btn5.Click, btn4.Click, btn3.Click, btn2.Click, btn1.Click, btn0.Click
        ' Añadir el número correspondiente al botón presionado al contenido actual del display
        textDisplay.Text += sender.Text
    End Sub

    ' Evento para limpiar el display y reiniciar las variables
    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        ' Vaciar el display y restablecer las variables y la operación seleccionada
        textDisplay.Text = ""
        valor1 = 0
        valor2 = 0
        operacion = ""
    End Sub

    ' Evento para realizar un cálculo de porcentaje
    Private Sub btnPorcentaje_Click(sender As Object, e As EventArgs) Handles btnPorcentaje.Click
        ' Comprobar si el display tiene un valor numérico válido
        If textDisplay.Text <> "" AndAlso IsNumeric(textDisplay.Text) Then
            valor1 = CDbl(textDisplay.Text)  ' Convertir el texto en un número y asignarlo a valor1
            operacion = "%"                 ' Asignar la operación de porcentaje
            textDisplay.Text = (valor1 / 100).ToString()  ' Calcular el porcentaje de valor1 y mostrarlo en el display
        Else
            ' Mostrar un mensaje de error si el display está vacío o contiene un valor no numérico
            MessageBox.Show("Por favor, ingresa un número antes de elegir el porcentaje.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Evento para seleccionar una operación matemática (suma, resta, multiplicación, división)
    Private Sub btnOperacion_Click(sender As Object, e As EventArgs) Handles btnSuma.Click, btnResta.Click, btnMulti.Click, btnDiv.Click
        ' Verificar si el display contiene un valor
        If textDisplay.Text <> "" Then
            valor1 = CDbl(textDisplay.Text)  ' Convertir el valor en el display a número y asignarlo a valor1
            operacion = sender.Text          ' Guardar la operación del botón presionado
            textDisplay.Text = ""            ' Limpiar el display para la entrada del segundo número
        Else
            ' Mostrar error si el display está vacío
            MessageBox.Show("Por favor, ingresa un número antes de seleccionar una operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Evento para seleccionar la operación de potencia
    Private Sub btnPotencia_Click(sender As Object, e As EventArgs) Handles btnPotencia.Click
        ' Comprobar que el display no esté vacío
        If textDisplay.Text <> "" Then
            valor1 = CDbl(textDisplay.Text)  ' Convertir el texto del display a número y asignarlo a valor1
            operacion = "^"                  ' Asignar la operación de potencia
            textDisplay.Text = ""            ' Limpiar el display para la entrada del siguiente número
        Else
            ' Mostrar error si el display está vacío
            MessageBox.Show("Por favor, ingresa un número antes de seleccionar la potencia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Evento para ejecutar la operación seleccionada y mostrar el resultado
    Private Sub btnIgual_Click(sender As Object, e As EventArgs) Handles btnIgual.Click
        ' Verificar que el display contenga un valor numérico válido
        If textDisplay.Text <> "" AndAlso IsNumeric(textDisplay.Text) Then
            Dim resultado As Double ' Variable para guardar el resultado final

            ' Si la operación es porcentaje, se realiza el cálculo directamente sin usar un segundo valor
            If operacion = "%" Then
                resultado = valor1 / 100  ' Realizar el cálculo de porcentaje
                listHistorial.Items.Add($"{valor1} % = {resultado}") ' Registrar la operación en el historial
                textDisplay.Text = resultado.ToString()              ' Mostrar el resultado en el display
                operacion = ""                                       ' Limpiar la operación actual
                Exit Sub                                             ' Terminar la ejecución aquí
            End If

            valor2 = CDbl(textDisplay.Text)  ' Convertir el texto del display a número y asignarlo a valor2

            ' Realizar la operación correspondiente en función del valor de "operacion"
            Select Case operacion
                Case "+"
                    resultado = valor1 + valor2  ' Sumar los valores
                Case "-"
                    resultado = valor1 - valor2  ' Restar valor2 de valor1
                Case "*"
                    resultado = valor1 * valor2  ' Multiplicar los valores
                Case "/"
                    If valor2 <> 0 Then          ' Verificar que valor2 no sea 0 antes de dividir
                        resultado = valor1 / valor2  ' Dividir valor1 entre valor2
                    Else
                        textDisplay.Text = "Error"  ' Mostrar error si el divisor es 0
                        Exit Sub
                    End If
                Case "^"
                    resultado = Math.Pow(valor1, valor2)  ' Elevar valor1 a la potencia de valor2
                Case Else
                    textDisplay.Text = "Error"            ' Mostrar error si la operación no es válida
                    Exit Sub
            End Select

            ' Mostrar el resultado en el display
            textDisplay.Text = resultado.ToString()

            ' Añadir el cálculo al historial para referencia
            listHistorial.Items.Add($"{valor1} {operacion} {valor2} = {resultado}")
        Else
            ' Mensaje de error si el display está vacío o no contiene un número
            MessageBox.Show("Por favor, ingresa un número válido antes de usar el botón Igual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class



