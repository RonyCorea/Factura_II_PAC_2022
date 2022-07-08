using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Datos
{
    public class ProductoDatos
    {
        public async Task<DataTable> DevolverProductosAsync()
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM producto;";

                using (MySqlConnection _conexion = new MySqlConnection(CanedaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;

                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception)
            {
            }
            return dt;
        }

        public async Task<bool> InsertarNuevoProductoAsync(Producto producto)
        {
            bool insert = false;
            try
            {
                string sql = "INSERT INTO producto VALUES (@Codigo, @Descripcion, @Existencia, @Precio, @Imagen);";

                using (MySqlConnection _conexion = new MySqlConnection(CanedaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 50).Value = producto.Codigo;
                        comando.Parameters.Add("@Descripcion", MySqlDbType.VarChar, 120).Value = producto.Descripcion;
                        comando.Parameters.Add("@Existencia", MySqlDbType.Int32).Value = producto.Existencia;
                        comando.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = producto.Precio;
                        comando.Parameters.Add("@Imagen", MySqlDbType.LongBlob).Value = producto.Imagen;

                        await comando.ExecuteNonQueryAsync();
                        insert = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return insert;
        }

        public async Task<bool> ActualizarProductoAsync(Producto producto)
        {
            bool actualizo = false;
            try
            {
                string sql = "UPDATE producto SET Descripcion = @Descripcion, Existencia = @Existencia, Precio = @Precio, Imagen = @Imagen WHERE Codigo = @Codigo;";

                using (MySqlConnection _conexion = new MySqlConnection(CanedaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 50).Value = producto.Codigo;
                        comando.Parameters.Add("@Descripcion", MySqlDbType.VarChar, 120).Value = producto.Descripcion;
                        comando.Parameters.Add("@Existencia", MySqlDbType.Int32).Value = producto.Existencia;
                        comando.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = producto.Precio;
                        comando.Parameters.Add("@Imagen", MySqlDbType.LongBlob).Value = producto.Imagen;
                        await comando.ExecuteNonQueryAsync();
                        actualizo = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return actualizo;
        }

        public async Task<bool> EliminarProductoAsync(string codigo)
        {
            bool elimino = false;
            try
            {
                string sql = "DELETE FROM producto WHERE Codigo = @Codigo;";

                using (MySqlConnection _conexion = new MySqlConnection(CanedaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 50).Value = codigo;
                        await comando.ExecuteNonQueryAsync();
                        elimino = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return elimino;
        }

        public async Task<byte[]> SeleccionarImagen(string codigo)
        {
            byte[] _imagen = new byte[0];

            try
            {
                string sql = "SELECT Imagen FROM producto WHERE Codigo = @Codigo;";

                using (MySqlConnection _conexion = new MySqlConnection(CanedaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 50).Value = codigo;

                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        if (dr.Read())
                        {
                            _imagen = (byte[])dr["Imagen"];
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return _imagen;

        }

        public async Task<Producto> GetPorCodigoAsync(string codigo)
        {
            Producto producto = new Producto(); 

            try
            {
                string sql = "SELECT * FROM producto WHERE Codigo = @Codigo;";

                using (MySqlConnection _conexion = new MySqlConnection(CanedaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 50).Value = codigo;

                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        if (dr.Read())
                        {
                            producto.Codigo = dr["Codigo"].ToString();
                            producto.Descripcion = dr["Descripcion"].ToString();
                            producto.Existencia = (int)dr["Existencia"];
                            producto.Precio = (decimal)dr["Precio"];
                            producto.Imagen = (byte[])dr["Imagen"];
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return producto;
        }

    }
}
