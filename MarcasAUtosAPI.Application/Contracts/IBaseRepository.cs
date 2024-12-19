using MarcasAUtosAPI.Domain;

namespace MarcasAUtosAPI.Application.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task<object?> AddAsync(MarcaAuto marca);

        //funciones para creación y actualizacion
        Task<IEnumerable<T>> GetAllAsync();

    }
}
