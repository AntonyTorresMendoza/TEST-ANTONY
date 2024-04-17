using System;
using System.Linq;

using AccesoDatos.BDRUTADataSetTableAdapters;
using AccesoDatos;

namespace AccesoDatosLayer
{
    public class dalVenta
    {
        private VentasTableAdapter _ventasTableAdapter;

        public dalVenta()
        {
            _ventasTableAdapter = new VentasTableAdapter();
        }

        public CVenta SeleccionarVenta(int id)
        {
            var venta = _ventasTableAdapter.GetData().FirstOrDefault(v => v.ID == id);

            if (venta == null)
            {
                return null;
            }

            return new CVenta
            {
                id = venta.ID,
                idcliente = venta.IDCliente,
                idruta = venta.IDRuta,
                cantidadpersonas = venta.CantidadPersonas
            };
        }

        public void InsertarVenta(CVenta pVenta)
        {
            // Obtén el DataTable al que debes agregar la fila
            BDRUTADataSet.VentasDataTable ventasDataTable = _ventasTableAdapter.GetData();

            // Crea una nueva fila
            BDRUTADataSet.VentasRow nuevaVenta = ventasDataTable.NewVentasRow();

            // Establece las propiedades de la nueva fila}
            nuevaVenta.ID = pVenta.id;
            nuevaVenta.IDCliente = pVenta.idcliente;
            nuevaVenta.IDRuta = pVenta.idruta;
            nuevaVenta.CantidadPersonas = pVenta.cantidadpersonas;

            // Agrega la nueva fila al DataTable
            ventasDataTable.NewVentasRow(nuevaVenta);

            // Actualiza el DataTable usando el TableAdapter
            _ventasTableAdapter.Update(ventasDataTable);
        }


        public void ActualizarVenta(CVenta pVenta)
        {
            var venta = _ventasTableAdapter.GetData().First(v => v.ID == pVenta.id);
            venta.IDCliente = pVenta.idcliente;
            venta.IDRuta = pVenta.idruta;
            venta.CantidadPersonas = pVenta.cantidadpersonas;
            _ventasTableAdapter.Update(venta);
        }

        public void EliminarVenta(int ID_Venta)
        {
            var venta = _ventasTableAdapter.GetData().First(v => v.ID == ID_Venta);
            _ventasTableAdapter.Delete(venta.ID, venta.IDCliente, venta.IDRuta, venta.CantidadPersonas);
        }
    }
}
