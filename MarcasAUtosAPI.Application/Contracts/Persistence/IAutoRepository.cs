using MarcasAUtosAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcasAUtosAPI.Application.Contracts.Persistence
{
    public interface IAutoRepository : IAsyncRepository<MarcaAuto>
    {
        Task<IEnumerable<MarcaAuto>> GetMarcas();

    }
}

