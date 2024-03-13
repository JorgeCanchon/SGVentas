
Public Class GestorProductos
    Private Productos As List(Of Producto)
    Public Sub New()
        Productos = New List(Of Producto)
    End Sub

    Public Function AddItem(producto As Producto) As Boolean
        Try
            Productos.Add(producto)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetLatestId()
        Return If(Productos.Any(), Productos.Max(Function(p) p.ID) + 1, 1)
    End Function

    Public Sub UpdateStockItem(producto As Producto, cantidad As Integer)
        Dim productoEncontrado = GetItemById(producto.ID)

        If productoEncontrado IsNot Nothing Then
            productoEncontrado.Stock -= cantidad
            Productos(Productos.IndexOf(productoEncontrado)) = productoEncontrado
        End If
    End Sub

    Public Sub DeleteItem(producto As Producto)
        Productos.Remove(producto)
    End Sub

    Public Function GetItemById(id As Integer) As Producto
        Return Productos.Find(Function(producto) producto.ID = id)
    End Function

    Public Function GetAllProductos() As List(Of Producto)
        Return Productos
    End Function

End Class
