using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using Serializacion;

namespace BaseDeDatos
{
    public static class ManajedorSQL
    {
        static SqlConnection conexion;

        static string queryInsertCliente = "INSERT INTO Clientes (nombre, apellido, edad, dni, idCliente) values (@nombre, @apellido, @edad, @dni, @idCliente)";
        static string queryDeleteCliente = "DELETE FROM Clientes WHERE idCliente = @idCliente";
        static string queryUpdateCliente = "UPDATE Clientes SET nombre = @nombre, apellido = @apellido, edad = @edad, dni = @dni, idCliente = @idCliente WHERE idCliente = @idCliente";

        static string queryInsertEmpleado = "INSERT INTO Empleados (nombre, apellido, edad, dni, idEmpleado) values (@nombre, @apellido, @edad, @dni, @idEmpleado)";
        static string queryDeleteEmpleado = "DELETE FROM Empleados WHERE idEmpleado = @idEmpleado";
        static string queryUpdateEmpleado = "UPDATE Empleados SET nombre = @nombre, apellido = @apellido, edad = @edad, dni = @dni, idEmpleado = @idEmpleado WHERE idEmpleado = @idEmpleado";

        static string queryInsertProducto = "INSERT INTO Productos (nombre, precio, cantidad, idProducto, marca) values (@nombre, @precio, @cantidad, @idProducto, @marca)";
        static string queryDeleteProducto = "DELETE FROM Productos WHERE idProducto = @idProducto";
        static string queryUpdateProducto = "UPDATE Productos SET nombre = @nombre, precio = @precio, cantidad = @cantidad, idProducto = @idProducto, marca = @marca WHERE idProducto = @idProducto";

        static string queryInsertPedido = "INSERT INTO Pedidos (nombre, precio, cantidad, idProducto, marca, idCliente, idEmpleado, idVenta, estado, delivery) values (@nombre, @precio, @cantidad, @idProducto, @marca, @idCliente, @idEmpleado, @idVenta, @estado, @delivery)";
        static string queryDeletePedido = "DELETE FROM Pedidos WHERE idVenta = @idVenta";
        static string queryUpdatePedido = "UPDATE Pedidos SET nombre = @nombre, precio = @precio, cantidad = @cantidad, idProducto = @idProducto, marca = @marca, idCliente = @idCliente, idEmpleado = @idEmpleado, idVenta = @idVenta, estado = @estado, delivery = @delivery WHERE idVenta = @idVenta";
        static ManajedorSQL()
        {
            conexion = new SqlConnection(@"Data Source = DESKTOP-L86C8Q5\SQLEXPRESS; Initial Catalog = Negocio; Integrated Security = True;");
            //conexion = new SqlConnection(@"Data Source = .\SQLEXPRESS; Initial Catalog = Negocio; Integrated Security = True;");
        }
        public static List<Cliente> ObtenerClientes()
        {
            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            List<Cliente> auxClientes = new List<Cliente>();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * From Clientes";

            SqlDataReader datosClientes = comando.ExecuteReader();

            while (datosClientes.Read())
            {
                auxClientes.Add(new Cliente(datosClientes["Nombre"].ToString(),
                                            datosClientes["Apellido"].ToString(),
                                            int.Parse(datosClientes["Edad"].ToString()),
                                            int.Parse(datosClientes["DNI"].ToString()),
                                            int.Parse(datosClientes["IdCliente"].ToString())));
            }
            
            if (conexion.State != ConnectionState.Closed)
                conexion.Close();

            return auxClientes;
        }


        public static void CargarListaClientes()
        {
            Negocio.ListaClientes = ManajedorSQL.ObtenerClientes();
        }
        public static void InsertCliente(Cliente cliente)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryInsertCliente;
                comando.Parameters.Add(new SqlParameter("Nombre", cliente.Nombre));
                comando.Parameters.Add(new SqlParameter("Apellido", cliente.Apellido));
                comando.Parameters.Add(new SqlParameter("Edad", cliente.Edad));
                comando.Parameters.Add(new SqlParameter("DNI", cliente.Dni));
                comando.Parameters.Add(new SqlParameter("IdCliente", cliente.IdCliente));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se insertó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static void DeleteCliente(Cliente cliente)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryDeleteCliente;
                comando.Parameters.Add(new SqlParameter("Nombre", cliente.Nombre));
                comando.Parameters.Add(new SqlParameter("Apellido", cliente.Apellido));
                comando.Parameters.Add(new SqlParameter("Edad", cliente.Edad));
                comando.Parameters.Add(new SqlParameter("DNI", cliente.Dni));
                comando.Parameters.Add(new SqlParameter("IdCliente", cliente.IdCliente));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se eliminó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }

        }
        public static void UpdateCliente(Cliente cliente)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryUpdateCliente;
                comando.Parameters.Add(new SqlParameter("Nombre", cliente.Nombre));
                comando.Parameters.Add(new SqlParameter("Apellido", cliente.Apellido));
                comando.Parameters.Add(new SqlParameter("Edad", cliente.Edad));
                comando.Parameters.Add(new SqlParameter("DNI", cliente.Dni));
                comando.Parameters.Add(new SqlParameter("IdCliente", cliente.IdCliente));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se modificó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }

        }
        public static List<Empleado> ObtenerEmpleados()
        {
            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            List<Empleado> auxEmpleados = new List<Empleado>();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * From Empleados";
            
            SqlDataReader datosEmpleados = comando.ExecuteReader();

            while (datosEmpleados.Read())
            {
                auxEmpleados.Add(new Empleado(datosEmpleados["Nombre"].ToString(),
                                              datosEmpleados["Apellido"].ToString(),
                                              int.Parse(datosEmpleados["Edad"].ToString()),
                                              int.Parse(datosEmpleados["DNI"].ToString()),
                                              int.Parse(datosEmpleados["IdEmpleado"].ToString())));
            }
            
            if (conexion.State != ConnectionState.Closed)
                conexion.Close();

            return auxEmpleados;
        }
        public static void CargarListaEmpleados()
        {
            Negocio.ListaEmpleados = ManajedorSQL.ObtenerEmpleados();
        }
        public static void InsertEmpleado(Empleado empleado)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryInsertEmpleado;
                comando.Parameters.Add(new SqlParameter("Nombre", empleado.Nombre));
                comando.Parameters.Add(new SqlParameter("Apellido", empleado.Apellido));
                comando.Parameters.Add(new SqlParameter("Edad", empleado.Edad));
                comando.Parameters.Add(new SqlParameter("DNI", empleado.Dni));
                comando.Parameters.Add(new SqlParameter("IdEmpleado", empleado.IdEmpleado));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se insertó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static void DeleteEmpleado(Empleado empleado)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryDeleteEmpleado;
                comando.Parameters.Add(new SqlParameter("Nombre", empleado.Nombre));
                comando.Parameters.Add(new SqlParameter("Apellido", empleado.Apellido));
                comando.Parameters.Add(new SqlParameter("Edad", empleado.Edad));
                comando.Parameters.Add(new SqlParameter("DNI", empleado.Dni));
                comando.Parameters.Add(new SqlParameter("IdEmpleado", empleado.IdEmpleado));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se eliminó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }

        }
        public static void UpdateEmpleado(Empleado empleado)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryUpdateEmpleado;
                comando.Parameters.Add(new SqlParameter("Nombre", empleado.Nombre));
                comando.Parameters.Add(new SqlParameter("Apellido", empleado.Apellido));
                comando.Parameters.Add(new SqlParameter("Edad", empleado.Edad));
                comando.Parameters.Add(new SqlParameter("DNI", empleado.Dni));
                comando.Parameters.Add(new SqlParameter("IdEmpleado", empleado.IdEmpleado));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se modificó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }

        }

        public static List<Producto> ObtenerProductos()
        {
            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            List<Producto> auxProductos = new List<Producto>();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * From Productos";
            
            SqlDataReader datosProductos = comando.ExecuteReader();

            while (datosProductos.Read())
            {
                auxProductos.Add(new Producto(datosProductos["Nombre"].ToString(),
                                              float.Parse(datosProductos["Precio"].ToString()),
                                              int.Parse(datosProductos["Cantidad"].ToString()),
                                              datosProductos["IdProducto"].ToString(),
                                              datosProductos["Marca"].ToString()));
            }

            if (conexion.State != ConnectionState.Closed)
                conexion.Close();

            return auxProductos;
        }
        public static void CargarListaProductos()
        {
            Negocio.ListaProductos = ManajedorSQL.ObtenerProductos();
        }
        public static void InsertProducto(Producto producto)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryInsertProducto;
                comando.Parameters.Add(new SqlParameter("Nombre", producto.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", producto.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", producto.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", producto.IdProducto));
                comando.Parameters.Add(new SqlParameter("Marca", producto.Marca));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se insertó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static void DeleteProducto(Producto producto)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryDeleteProducto;
                comando.Parameters.Add(new SqlParameter("Nombre", producto.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", producto.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", producto.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", producto.IdProducto));
                comando.Parameters.Add(new SqlParameter("Marca", producto.Marca));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se eliminó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }

        }
        public static void UpdateProducto(Producto producto)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryUpdateProducto;
                comando.Parameters.Add(new SqlParameter("Nombre", producto.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", producto.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", producto.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", producto.IdProducto));
                comando.Parameters.Add(new SqlParameter("Marca", producto.Marca));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se modificó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }

        }

        public static List<Pedido> ObtenerPedidos()
        {
            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            List<Pedido> auxPedidos = new List<Pedido>();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * From Pedidos";
            
            SqlDataReader datosPedidos = comando.ExecuteReader();

            while (datosPedidos.Read())
            {
                auxPedidos.Add(new Pedido(datosPedidos["Nombre"].ToString(),
                                          float.Parse(datosPedidos["Precio"].ToString()),
                                          int.Parse(datosPedidos["Cantidad"].ToString()),
                                          datosPedidos["idProducto"].ToString(),
                                          datosPedidos["Marca"].ToString(),
                                          int.Parse(datosPedidos["IdCliente"].ToString()),
                                          int.Parse(datosPedidos["idEmpleado"].ToString()),
                                          int.Parse(datosPedidos["idVenta"].ToString()),
                                          datosPedidos["Estado"].ToString(),
                                          datosPedidos["Delivery"].ToString()));
            }

            if (conexion.State != ConnectionState.Closed)
                conexion.Close();

            return auxPedidos;
        }
        public static void CargarListaPedidos()
        {
            Negocio.ListaPedidos = ManajedorSQL.ObtenerPedidos();
        }
        public static bool InsertPedido(Pedido pedido)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryInsertPedido;

                comando.Parameters.Add(new SqlParameter("Nombre", pedido.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", pedido.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", pedido.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", pedido.IdProducto));
                comando.Parameters.Add(new SqlParameter("Marca", pedido.Marca));

                comando.Parameters.Add(new SqlParameter("IdCliente", pedido.IdCliente));
                comando.Parameters.Add(new SqlParameter("IdEmpleado", pedido.IdEmpleado));
                comando.Parameters.Add(new SqlParameter("IdVenta", pedido.IdVenta));
                comando.Parameters.Add(new SqlParameter("Estado", pedido.Estado));
                comando.Parameters.Add(new SqlParameter("Delivery", pedido.Delivery));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se insertó ninguna fila de la tabla");
                }

                return true;
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
                return false;
            }

            finally
            {
                conexion.Close();

            }
        }

        public static bool DeletePedido(Pedido pedido)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryDeletePedido;
                comando.Parameters.Add(new SqlParameter("Nombre", pedido.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", pedido.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", pedido.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", pedido.IdProducto));
                comando.Parameters.Add(new SqlParameter("Marca", pedido.Marca));

                comando.Parameters.Add(new SqlParameter("IdCliente", pedido.IdCliente));
                comando.Parameters.Add(new SqlParameter("IdEmpleado", pedido.IdEmpleado));
                comando.Parameters.Add(new SqlParameter("IdVenta", pedido.IdVenta));
                comando.Parameters.Add(new SqlParameter("Estado", pedido.Estado));
                comando.Parameters.Add(new SqlParameter("Delivery", pedido.Delivery));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se eliminó ninguna fila de la tabla");
                }

                return true;
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
                return false;
            }

            finally
            {
                conexion.Close();
            }

        }

        public static bool UpdatePedidos(Pedido pedido)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryUpdatePedido;
                comando.Parameters.Add(new SqlParameter("Nombre", pedido.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", pedido.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", pedido.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", pedido.IdProducto));
                comando.Parameters.Add(new SqlParameter("Marca", pedido.Marca));

                comando.Parameters.Add(new SqlParameter("IdCliente", pedido.IdCliente));
                comando.Parameters.Add(new SqlParameter("IdEmpleado", pedido.IdEmpleado));
                comando.Parameters.Add(new SqlParameter("IdVenta", pedido.IdVenta));
                comando.Parameters.Add(new SqlParameter("Estado", pedido.Estado));
                comando.Parameters.Add(new SqlParameter("Delivery", pedido.Delivery));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se modificó ninguna fila de la tabla");
                }

                return true;
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
                return false;
            }

            finally
            {
                conexion.Close();
            }

        }
    }
}
