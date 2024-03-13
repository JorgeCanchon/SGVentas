Public Class GestorVentas
    Private Ventas As List(Of Venta)

    Public Sub New()
        Ventas = New List(Of Venta)
    End Sub
    Public Function AddItem(venta As Venta) As Boolean
        Try
            Ventas.Add(venta)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetLatestId() As Integer
        Return If(Ventas.Any(), Ventas.Max(Function(p) p.ID) + 1, 1)
    End Function

    Public Function GetTotalVentas() As Decimal
        Return If(Ventas.Any(), Ventas.Sum(Function(p) p.TotalVenta), 0)
    End Function

    Public Sub DeleteItem(venta As Venta)
        Ventas.Remove(venta)
    End Sub

    Public Function GetItemById(id As Integer) As Venta
        Return Ventas.Find(Function(venta) venta.ID = id)
    End Function

    Public Function GetAllVentas() As List(Of Venta)
        Return Ventas
    End Function
End Class
