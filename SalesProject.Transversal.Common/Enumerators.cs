namespace SalesProject.Transversal.Common
{
    
    public static class Enumerators
    {
        public enum TransactionStates
        {
            Emitido = 1,
            Creado = 2,
            Cancelado = 3
        }

        public enum DocumentTypes
        {
            OrdenCompra = 1,
            Cotizacion = 2,
            Compra = 3,
            Venta = 4,
            DevolucionCompra = 5,
            DevolucionVenta = 6,
            EntradaInventario = 7,
            SalidaInventario = 8,
            TransferenciaStock = 9
        }
    }
}
