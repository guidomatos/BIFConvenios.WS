Imports BIFConvenios.DO

Public Class ClienteBL
    ' Fields
    Private ReadOnly CodDO As New ClienteDO

    ' Methods
    Public Function ExisteCodigoIBS(codibs As Integer) As Boolean
        Return CodDO.ExisteCodigoIBS(codibs)
    End Function
End Class
