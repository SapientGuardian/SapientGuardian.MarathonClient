using SapientGuardian.MarathonClient.Implementations.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapientGuardian.MarathonClient.Interfaces.V2
{
    /// <summary>
    /// An interface for the Marathon V2 Apps API
    /// </summary>
    public interface IApps
    {
        /// <summary>
        /// Gets all Apps
        /// </summary>
        /// <returns>All Apps</returns>
        Task<IEnumerable<App>> GetAll();

        /// <summary>
        /// Gets an App by its id
        /// </summary>
        /// <param name="id">The id of the App</param>
        /// <returns>The App</returns>
        Task<App> Get(string id);

        /// <summary>
        /// Updates an existing App
        /// </summary>
        /// <param name="app">The App to update</param>        
        Task Update(App app);
    }
}