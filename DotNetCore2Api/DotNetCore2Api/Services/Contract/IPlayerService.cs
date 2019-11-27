using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2Api.Services.Contract
{
    /// <summary>
    /// Interface de PlayerService
    /// </summary>
    public interface IPlayerService
    {
        /// <summary>
        /// Obtiene el Nombre del jugador
        /// </summary>
        /// <returns></returns>
        string GetName();
    }
}
