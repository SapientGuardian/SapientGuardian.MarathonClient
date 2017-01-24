using SapientGuardian.MarathonClient.Implementations.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapientGuardian.MarathonClient.Interfaces.V2
{
    /// <summary>
    /// Interface for the Marathon API V2
    /// </summary>
    public interface IMarathon
    {
        /// <summary>
        /// Gets an interface for App operations
        /// </summary>        
        IApps Apps { get; }

    }
}
