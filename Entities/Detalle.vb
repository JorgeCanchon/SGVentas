Public Class Detalle
    Public Property Cantidad As Integer
    Public Property PrecioVenta As Decimal
    Public Property IdProducto As Integer
    Public Property IdVenta As Integer
    Public Property Venta As Venta
    Public Property Producto As Producto

    Public Sub New()

    End Sub

    Public Sub New(cantidad As Integer, precioVenta As Decimal, idProducto As Integer,
                   idVenta As Integer)
        Me.Cantidad = cantidad
        Me.PrecioVenta = precioVenta
        Me.IdProducto = idProducto
        Me.IdVenta = idVenta
    End Sub

    Public Function CalculateTotalVenta() As Decimal
        Return PrecioVenta * Cantidad
    End Function
End Class
