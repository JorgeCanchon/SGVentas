Public Class Venta
    Public Property ID As Integer
    Public Property FechaVenta As Date
    Public Property TotalVenta As Decimal
    Public Property DetalleVentas As List(Of Detalle)

    Public Sub New()

    End Sub

    Public Sub New(id As Integer, fechaVenta As Date)
        Me.ID = id
        Me.FechaVenta = fechaVenta
    End Sub

    Public Sub SetTotalVenta(totalVenta As Decimal)
        Me.TotalVenta = totalVenta
    End Sub

    Public Sub SetDetalle(detalle As List(Of Detalle))
        Me.DetalleVentas = detalle
    End Sub
End Class
