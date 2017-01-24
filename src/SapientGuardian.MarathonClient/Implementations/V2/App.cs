using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapientGuardian.MarathonClient.Implementations.V2
{
    /// <summary>
    /// Represenation of a Marathon App
    /// </summary>
    public class App
    {
        internal readonly JObject appJobj;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// Not intended for users.
        /// </summary>
        /// <param name="appJson">The json representation of the App.</param>
        public App(string appJson)
        {
            this.appJobj = JObject.Parse(appJson);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        /// <param name="appJobj">The JObject representation of the App.</param>
        internal App(JObject appJobj)
        {
            this.appJobj = appJobj;
        }

        /// <summary>
        /// Gets the JSON representation of the App.
        /// </summary>
        /// <returns>JSON representation</returns>
        public string ToJson()
        {
            return appJobj.ToString();
        }

        /// <summary>
        /// Unique identifier for the app consisting of a series of names separated by slashes. Each name must be at least 1 character and may only contain digits (0-9), dashes (-), dots (.), and lowercase letters (a-z). The name may not begin or end with a dash.
        /// </summary>
        /// <value>
        /// The id
        /// </value>
        public string Id
        {
            get
            {
                return appJobj["id"]?.Value<string>();
            }
        }

        /// <summary>
        /// The number of instances of this application to start. Please note: this number can be changed everytime as needed to scale the application.
        /// </summary>
        /// <value>
        /// The number of instances
        /// </value>
        public int? Instances
        {
            get
            {
                return appJobj["instances"]?.Value<int>();
            }
            set
            {
                appJobj["instances"] = value;
            }
        }

        /// <summary>
        /// Key value pairs that get added to the environment variables of the process to start.
        /// </summary>
        /// <value>
        /// The env vars
        /// </value>
        public IDictionary<string, string> Env
        {
            get
            {
                if (appJobj["env"] == null)
                {
                    appJobj["env"] = new JObject();
                }
                return new JObjectStringDictionary((JObject)(appJobj["env"]));
            }
        }

        /// <summary>
        /// The number of CPUs this application needs per instance.
        /// </summary>
        /// <value>
        /// The number of CPUs.
        /// </value>
        public float? Cpus
        {
            get
            {
                return appJobj["cpus"]?.Value<float>();
            }
            set
            {
                appJobj["cpus"] = value;
            }
        }

        /// <summary>
        /// The amount of memory in MB that is needed for the application per instance.
        /// </summary>
        /// <value>
        /// The amount of memory in MB.
        /// </value>
        public float? Mem
        {
            get
            {
                return appJobj["mem"]?.Value<float>();
            }
            set
            {
                appJobj["mem"] = value;
            }
        }

        /// <summary>
        /// A set of arbitrary key-value pairs.
        /// </summary>
        /// <value>
        /// The labels.
        /// </value>
        public IDictionary<string, string> Labels
        {
            get
            {
                if (appJobj["labels"] == null)
                {
                    appJobj["labels"] = new JObject();
                }
                return new JObjectStringDictionary((JObject)(appJobj["labels"]));
            }
        }

        /// <summary>
        /// Gets the number of tasks staged to run.
        /// </summary>
        /// <value>
        /// The number of tasks staged.
        /// </value>
        public int? TasksStaged => appJobj["tasksStaged"]?.Value<int>();

        /// <summary>
        /// Gets the number of tasks running.
        /// </summary>
        /// <value>
        /// The number of tasks running.
        /// </value>
        public int? TasksRunning => appJobj["tasksRunning"]?.Value<int>();

        /// <summary>
        /// Gets the number of healthy tasks.
        /// </summary>
        /// <value>
        /// The number of healthy tasks.
        /// </value>
        public int? TasksHealthy => appJobj["tasksHealthy"]?.Value<int>();

        /// <summary>
        /// Gets the number of unhealthy tasks.
        /// </summary>
        /// <value>
        /// The number of unhealthy tasks.
        /// </value>
        public int? TasksUnhealthy => appJobj["tasksUnhealthy"]?.Value<int>();
    }
}
