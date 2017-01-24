using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace SapientGuardian.MarathonClient.Implementations.V2
{
    internal class JObjectStringDictionary : IDictionary<string, string>
    {
        private readonly JObject jObject;
        private readonly IDictionary<string,JToken> dObject;
        internal JObjectStringDictionary(JObject jObject)
        {
            if (jObject == null) throw new ArgumentNullException(nameof(jObject));
            this.jObject = jObject;
            this.dObject = jObject;
        }

        public string this[string key]
        {
            get
            {
                return jObject[key]?.ToString();
            }

            set
            {
                jObject[key] = value;
            }
        }

        public int Count => dObject.Count;

        public bool IsReadOnly => dObject.IsReadOnly;

        public ICollection<string> Keys => dObject.Keys;

        public ICollection<string> Values
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(KeyValuePair<string, string> item)
        {
            dObject.Add(item.Key, item.Value);
        }

        public void Add(string key, string value)
        {
            dObject.Add(key, value);
        }

        public void Clear()
        {
            dObject.Clear();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(string key)
        {
            return dObject.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            return dObject.Remove(key);
        }

        public bool TryGetValue(string key, out string value)
        {
            JToken temp;
            if (dObject.TryGetValue(key, out temp))
            {
                value = temp.ToString();
                return true;
            }
            value = null;
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
