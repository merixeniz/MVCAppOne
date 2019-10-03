using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace MVCAppOne.Infrastructure
{
    public class SessionManager : ISessionManager
    {
        private HttpSessionState _session;

        public SessionManager()
        {
            _session = HttpContext.Current.Session;
        }

        /// <summary>
        /// Usuniecie calej sesji
        /// </summary>
        public void Abandon()
        {
            _session.Abandon();
        }

        public T Get<T>(string key)
        {
            return (T)_session[key];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="createDefault"> delegat z funkcja, co zrobic gdy _session[key] == null </param>
        /// <returns></returns>
        public T Get<T>(string key, Func<T> createDefault)
        {
            T retval;

            if (_session[key] != null && _session[key].GetType() == typeof(T))
            {
                retval = (T)_session[key];
            }
            else
            {
                retval = createDefault();
                _session[key] = retval;
            }

            return retval;
        }

        public void Set<T>(string name, T value)
        {
            _session[name] = value;
        }

        public T TryGet<T>(string key)
        {
            try
            {
                return (T)_session[key];
            }
            catch (NullReferenceException)
            {
                return default(T);
            }
        }
    }
}