using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class FacturaDatos
    {
        public async Task<bool> GuardarAsync(Factura factura, List<DetalleFactura> detalles)
        {
            bool insert = false;
            int idFactura = 0;
            try
            {
                string sql = "INSERT INTO factura (IdentidadCliente, Fecha, ISV, Descuento, SubTotal, Total) VALUES (@IdentidadCliente, @Fecha, @ISV, @Descuento, @SubTotal, @Total); SELECT LAST_INSERT_ID();";
                string sqlDetalle = "INSERT INTO detallefactura (IdFactura, CodigoProducto, PrecioProducto, Cantidad, Total) VALUES (@IdFactura, @CodigoProducto, @PrecioProducto, @Cantidad, @Total);";
                string sqlExistencia = "UPDATE producto SET Existencia = Existencia - @Cantidad WHERE Codigo = @Codigo";

                using (MySqlConnection _conexion = new MySqlConnection(CanedaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@IdentidadCliente", MySqlDbType.VarChar, 25).Value = factura.IdentidadCliente;
                        comando.Parameters.Add("@Fecha", MySqlDbType.DateTime).Value = factura.Fecha;
                        comando.Parameters.Add("@ISV", MySqlDbType.Decimal).Value = factura.ISV;
                        comando.Parameters.Add("@Descuento", MySqlDbType.Decimal).Value = factura.Descuento;
                        comando.Parameters.Add("@SubTotal", MySqlDbType.Decimal).Value = factura.SubTotal;
                        comando.Parameters.Add("@Total", MySqlDbType.Decimal).Value = factura.Total;

                        idFactura = Convert.ToInt32(await comando.ExecuteScalarAsync());
                    }

                    foreach (var item in detalles)
                    {
                        using (MySqlCommand comando2 = new MySqlCommand(sqlDetalle, _conexion))
                        {
                            comando2.CommandType = System.Data.CommandType.Text;

                            comando2.Parameters.Add("@IdFactura", MySqlDbType.Int32).Value = idFactura;
                            comando2.Parameters.Add("@CodigoProducto", MySqlDbType.VarChar, 50).Value = item.CodigoProducto;
                            comando2.Parameters.Add("@PrecioProducto", MySqlDbType.Decimal).Value = item.Precio;
                            comando2.Parameters.Add("@Cantidad", MySqlDbType.Int32).Value = item.Cantidad;
                            comando2.Parameters.Add("@Total", MySqlDbType.Decimal).Value = item.Total;

                            await comando2.ExecuteNonQueryAsync();
                            insert = true;
                        }

                        using (MySqlCommand comando3 = new MySqlCommand(sqlExistencia, _conexion))
                        {
                            comando3.CommandType = System.Data.CommandType.Text;
                            comando3.Parameters.Add("@Codigo", MySqlDbType.VarChar, 50).Value = item.CodigoProducto;
                            comando3.Parameters.Add("@Cantidad", MySqlDbType.Int32).Value = item.Cantidad;

                            await comando3.ExecuteNonQueryAsync();
                            insert = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
            }
            return insert;
        }



    }
}
