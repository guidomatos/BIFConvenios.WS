namespace BusinessLogic
{
    public class DLEMP_logic
    {
        public bool actualizar_dlemp(string cliente_id, string anio, string mes)
        {
            bool result;
            try
            {

                var dlemp_acc = new DataAccess.DLEMP();
                result = dlemp_acc.Actualizar_datos_DLEMP(cliente_id, anio, mes);
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}