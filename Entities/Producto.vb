Public Class Producto
    Public Property ID As Integer
    Public Property Nombre As String
    Public Property Precio As Decimal
    Public Property Stock As Integer
    Public Property DetalleVentas As List(Of Detalle)

    Public Sub New()
    End Sub

    Public Sub New(id As Integer, nombre As String, precio As Decimal, stock As Integer)
        Me.ID = id
        Me.Nombre = nombre
        Me.Precio = precio
        Me.Stock = stock
    End Sub

    Public Sub New(id As Integer, nombre As String, precio As Decimal, stock As Integer, detalleVentas As List(Of Detalle))
        Me.ID = id
        Me.Nombre = nombre
        Me.Precio = precio
        Me.Stock = stock
        Me.DetalleVentas = detalleVentas
    End Sub
End Class
