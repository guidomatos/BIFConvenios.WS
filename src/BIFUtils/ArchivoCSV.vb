Imports System.IO
Imports System.Text

Public Class ArchivoCSV
    Public Sub ExportaCSV(ByRef pData As DataSet, ruta As String, strFile As String)
        Dim ldr As DataRow
        Dim lNroColumnas As Integer

        Dim sb As New StringBuilder()   ' para contener el archivo CSV
        Dim j As Integer
        Dim k As Integer

        WS.Utils.RemoveFiles(ruta, New TimeSpan(0, 0, 60, 0, 0))
        'Crear el encabezado y la hoja...
        Dim quoter As String = """"""

        lNroColumnas = pData.Tables(0).Columns.Count

        For j = 0 To lNroColumnas - 1
            sb.Append(pData.Tables(0).Columns(j).ColumnName)   'headings
            sb.Append(",") ' delimiter
        Next

        sb.Append(vbCrLf)
        For Each ldr In pData.Tables(0).Rows

            For k = 0 To lNroColumnas - 1
                If ldr(k).ToString() = Nothing Then
                    sb.Append("""""" + ldr(k).ToString() + " " + ",")
                Else
                    Dim replVal As String = ldr(k).ToString().Replace("""", quoter)
                    replVal += " ,"
                    sb.Append(replVal)
                End If
            Next
            sb.Append(vbCrLf)
        Next

        Dim strFileContent As String = sb.ToString()

        Dim fi As New FileInfo(ruta + strFile)
        Dim sWriter As FileStream = fi.Open(FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
        sWriter.Write(Encoding.Default.GetBytes(strFileContent), 0, strFileContent.Length)
        sWriter.Flush()
        sWriter.Close()
    End Sub

    Public Function ImportaCSV(pRutaArchivo As String) As DataTable
        Dim ldt As New DataTable("Result")
        Dim ldataSplit As String()
        Dim lCol As Integer
        Dim lNroCol As Integer = 0

        Dim lStreamReader As StreamReader
        lStreamReader = New StreamReader(pRutaArchivo)
        Try

            'Aqui obtenemos los nombres de las columnas
            Dim ldata As String = lStreamReader.ReadLine
            ldataSplit = ldata.Split(",")

            'Aqui añadimos las columnas
            For lCol = 0 To ldataSplit.Length() - 1
                If ldataSplit(lCol).Trim <> "" Then
                    ldt.Columns.Add(New DataColumn(ldataSplit(lCol)))
                    lNroCol += 1
                End If
            Next

            'Aqui leemos la primera linea
            ldata = lStreamReader.ReadLine
            Do While (ldata IsNot Nothing)
                ldataSplit = ldata.Split(",")
                Dim ldr As DataRow = ldt.NewRow
                For lCol = 0 To lNroCol - 1
                    ldr.Item(lCol) = ldataSplit(lCol).ToString
                Next
                ldt.Rows.Add(ldr)
                ldata = lStreamReader.ReadLine
            Loop
        Catch ex As Exception
            Return New DataTable("Empty")
        Finally
            lStreamReader.Close()
        End Try
        Return ldt

    End Function
End Class