using Ecu911.Modelos;

namespace Ecu911.Servicios


{
    public interface IServicio
    {
        Task<List<ProcesoCompra>> Lista();

        Task<ProcesoCompra> Obtener(int idProceso);
        Task<bool> Guardar(ProcesoCompra objeto);
        Task<bool> Editar(ProcesoCompra objeto);
        Task<bool> Eliminar(int idProceso);
    }
}
