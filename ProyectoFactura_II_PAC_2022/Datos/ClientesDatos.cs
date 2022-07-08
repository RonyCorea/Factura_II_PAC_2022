using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ClientesDatos
    {
        public async Task<DataTable> DevolverClientesAsync()
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM cliente;";

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

        public async Task<bool> InsertarNuevoClienteAsync(Cliente cliente)
        {
            bool insert = false;
            try
            {
                string sql = "INSERT INTO cliente VALUES (@Identidad, @Nombre, @Direccion, @Email, @Foto);";

                using (MySqlConnection _conexion = new MySqlConnection(CanedaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 25).Value = cliente.Identidad;
                        comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 60).Value = cliente.Nombre;
                        comando.Parameters.Add("@Direccion", MySqlDbType.VarChar, 120).Value = cliente.Direccion;
                        comando.Parameters.Add("@Email", MySqlDbType.VarChar, 40).Value = cliente.Email;
                        comando.Parameters.Add("@Foto", MySqlDbType.LongBlob).Value = cliente.Foto;

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

        public async Task<bool> ActualizarClienteAsync(Cliente cliente)
        {
            bool actualizo = false;
            try
            {
                string sql = "UPDATE cliente SET Nombre = @Nombre, Direccion = @Direccion, Email = @Email, Foto = @Foto WHERE Identidad = @Identidad;";

                using (MySqlConnection _conexion = new MySqlConnection(CanedaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 25).Value = cliente.Identidad;
                        comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 60).Value = cliente.Nombre;
                        comando.Parameters.Add("@Direccion", MySqlDbType.VarChar, 120).Value = cliente.Direccion;
                        comando.Parameters.Add("@Email", MySqlDbType.VarChar, 40).Value = cliente.Email;
                        comando.Parameters.Add("@Foto", MySqlDbType.LongBlob).Value = cliente.Foto;
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

        public async Task<bool> EliminarClienteAsync(string identidad)
        {
            bool elimino = false;
            try
            {
                string sql = "DELETE FROM cliente WHERE Identidad = @Identidad;";

                using (MySqlConnection _conexion = new MySqlConnection(CanedaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 25).Value = identidad;
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

        public async Task<byte[]> SeleccionarFoto(string identidad)
        {
            byte[] _foto = new byte[0];

            try
            {
                string sql = "SELECT Foto FROM cliente WHERE Identidad = @Identidad;";

                using (MySqlConnection _conexion = new MySqlConnection(CanedaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarString, 25).Value=identidad;

                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        if (dr.Read())
                        {
                            _foto = (byte[])dr["Foto"];
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return _foto;

        }

        public async Task<Cliente> GetPorIdentidadAsync(string identidad)
        {
            Cliente cliente = new Cliente();

            try
            {
                string sql = "SELECT * FROM cliente WHERE Identidad = @Identidad;";

                using (MySqlConnection _conexion = new MySqlConnection(CanedaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarString, 25).Value = identidad;

                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        if (dr.Read())
                        {
                            cliente.Identidad = dr["Identidad"].ToString();
                            cliente.Nombre = dr["Nombre"].ToString();
                            cliente.Direccion = dr["Direccion"].ToString();
                            cliente.Email = dr["Email"].ToString();
                            cliente.Foto = (byte[])dr["Identidad"];
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return cliente;
        }

    }
}
