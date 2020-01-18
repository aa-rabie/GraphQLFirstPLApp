using System;

namespace GraphQLFirstPLApp.Web.Exceptions
{
    public class GraphQlException : ApplicationException
    {
        public GraphQlException(string message) : base(message)
        {
        }
    }
}