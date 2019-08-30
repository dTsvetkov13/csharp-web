using SIS.HTTP.Common;
using SIS.HTTP.Sessions.Contracts;
using System;
using System.Collections.Generic;

namespace SIS.HTTP.Sessions
{
    public class HttpSession : IHttpSession
    {
        private readonly Dictionary<string, object> sessionParameters;

        public HttpSession(string id)
        {
            this.IsNew = true;
            this.sessionParameters = new Dictionary<string, object>();
            this.Id = id;
        }

        public string Id { get; }

        public bool IsNew { get; set; }

        public void AddParameter(string parameterName, object parameter)
        {
            CoreValidator.ThrowIfNullOrEmpty(parameterName, nameof(parameter));
            CoreValidator.ThrowIfNull(parameter, nameof(parameter));

            this.sessionParameters[parameterName] = parameter;
        }

        public void ClearParameters()
        {
            this.sessionParameters.Clear();
        }

        public bool ContainsParameter(string parameterName)
        {
            CoreValidator.ThrowIfNullOrEmpty(parameterName, nameof(parameterName));
            return this.sessionParameters.ContainsKey(parameterName);
        }

        public object GetParameter(string parameterName)
        {
            CoreValidator.ThrowIfNullOrEmpty(parameterName, nameof(parameterName));

            //TODO: Validate for existing parameter (maybe throw exception)
            
            return this.sessionParameters[parameterName];
        }
    }
}
