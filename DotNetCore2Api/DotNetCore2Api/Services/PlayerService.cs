using DotNetCore2Api.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2Api.Services
{
    /// <summary>
    /// Implementacion de la interface IPlayerService
    /// </summary>
    public class PlayerService : IPlayerService
    {
        /// <summary>
        /// Obtiene el nombre del jugador
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return "Michael Jordan";
        }
    }
}
