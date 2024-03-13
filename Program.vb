Imports System.Runtime.InteropServices.JavaScript.JSType
Imports ConsoleTables

Module Program

    Dim gestorProductos As GestorProductos = New GestorProductos()
    Dim gestorVentas As GestorVentas = New GestorVentas()

    Sub Main(args As String())
        Dim opcion As Integer = 4
        DataTest()
        Do
            Try
                Console.WriteLine("Menu:")
                Console.WriteLine("1. Ver productos")
                Console.WriteLine("2. Insertar Producto")
                Console.WriteLine("3. Registrar Venta")
                Console.WriteLine("4. Total Ventas")
                Console.WriteLine("5. Ver Ventas")
                Console.WriteLine("6. Salir:")
                opcion = Convert.ToInt32(Console.ReadLine().ToString())

                Select Case opcion
                    Case 1
                        VerProducto()
                    Case 2
                        InsertarProducto()
                    Case 3
                        RegistrarVenta()
                    Case 4
                        TotalVentas()
                    Case 5
                        VerVentas()
                    Case 6
                        opcion = 0
                    Case Else
                        opcion = 0
                End Select
            Catch ex As Exception
                Console.BackgroundColor = ConsoleColor.Red
                Console.WriteLine($"Error: {ex.Message}")
                Console.ResetColor()
            End Try
        Loop Until opcion = 0
    End Sub

    Sub TotalVentas()
        Dim tableBuilder = New ConsoleTable()

        tableBuilder.AddColumn(New List(Of String) From {"Total Ventas"})

        Console.BackgroundColor = ConsoleColor.Blue

        Dim totalVentas = gestorVentas.GetTotalVentas()

        tableBuilder.AddRow(totalVentas)

        Console.WriteLine(tableBuilder.ToString())
        Console.ResetColor()
    End Sub
    Sub VerVentas()
        Dim tableBuilder = New ConsoleTable()

        tableBuilder.AddColumn(New List(Of String) From {"ID", "Fecha Venta", "Total"})

        Console.BackgroundColor = ConsoleColor.Blue
        Console.WriteLine("Ventas:")

        Dim ventas As List(Of Venta) = gestorVentas.GetAllVentas()

        For Each venta As Venta In ventas
            tableBuilder.AddRow(venta.ID, venta.FechaVenta, venta.TotalVenta)
        Next venta

        Console.WriteLine(tableBuilder.ToString())
        Console.ResetColor()
    End Sub

    Sub RegistrarVenta()

        Dim id = gestorVentas.GetLatestId()
        Dim venta As Venta = New Venta(id, Date.Now)

        Dim isValid = gestorVentas.AddItem(venta)

        If Not isValid Then
            Console.WriteLine($"No se pudo iniciar la venta")
            Return
        End If

        Dim detalleVenta As List(Of Detalle) = New List(Of Detalle)
        Console.WriteLine($"Venta #{id} iniciada con exito")
        Dim opcion As Integer = 4

        Do
            Dim idProducto As Integer = 0

            Console.WriteLine("Ingrese Id Producto")
            idProducto = Convert.ToInt32(Console.ReadLine().ToString())
            Dim producto = gestorProductos.GetItemById(idProducto)
            If producto IsNot Nothing Then
                Dim cantidadProducto As Integer = 0
                Console.WriteLine("Ingrese Cantidad Producto")
                cantidadProducto = Convert.ToInt32(Console.ReadLine().ToString())
                If Not producto.Stock < cantidadProducto Then
                    detalleVenta.Add(New Detalle(cantidadProducto, producto.Precio, idProducto, id))
                    gestorProductos.UpdateStockItem(producto, cantidadProducto)
                Else
                    Console.WriteLine($"Producto no cuenta con el stock suficiente: {producto.Stock}")
                End If
            Else
                    Console.WriteLine($"Producto no con el Id: {idProducto} no encontrado")
            End If

            Console.WriteLine($"Ingresar otro producto ingrese 1 de lo contrario ingrese 0")
            opcion = Convert.ToInt32(Console.ReadLine().ToString())
        Loop Until opcion = 0

        venta.SetDetalle(detalleVenta)
        Dim totalVenta As Integer = 0

        For Each detalle As Detalle In detalleVenta
            totalVenta += detalle.CalculateTotalVenta()
        Next detalle

        venta.SetTotalVenta(totalVenta)
    End Sub

    Sub InsertarProducto()
        Dim id As Integer = gestorProductos.GetLatestId()
        Dim nombre As String
        Dim precio As Decimal
        Dim stock As Integer

        Console.WriteLine("Ingrese Nombre")
        nombre = Console.ReadLine()
        Console.WriteLine("Ingrese Precio")
        precio = Convert.ToDecimal(Console.ReadLine())
        Console.WriteLine("Ingrese Stock")
        stock = Convert.ToInt32(Console.ReadLine())

        Dim isValid = gestorProductos.AddItem(New Producto(id, nombre, precio, stock))

        Console.WriteLine(If(isValid, "Producto ingresado con exito", "No se puedo ingresar el producto"))
    End Sub

    Sub DataTest()
        Dim productos As List(Of Producto) = New List(Of Producto) From {
            New Producto(1, "Tomate", 1000, 10),
            New Producto(2, "Cebolla", 2000, 10),
            New Producto(3, "Papa", 1500, 10),
            New Producto(4, "Arveja", 1300, 10)
        }

        For Each producto As Producto In productos
            gestorProductos.AddItem(producto)
        Next producto

    End Sub

    Sub VerProducto()
        Dim tableBuilder = New ConsoleTable()

        tableBuilder.AddColumn(New List(Of String) From {"ID", "Nombre", "Precio", "Stock"})

        Console.BackgroundColor = ConsoleColor.Blue
        Console.WriteLine("Productos:")

        Dim productos As List(Of Producto) = gestorProductos.GetAllProductos()

        For Each producto As Producto In productos
            tableBuilder.AddRow(producto.ID, producto.Nombre, producto.Precio, producto.Stock)
        Next producto

        Console.WriteLine(tableBuilder.ToString())
        Console.ResetColor()
    End Sub
End Module
