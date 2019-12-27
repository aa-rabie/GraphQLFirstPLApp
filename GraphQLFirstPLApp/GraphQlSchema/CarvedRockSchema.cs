using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLFirstPLApp.GraphQlSchema
{
    public class CarvedRockSchema : Schema
    {
        public CarvedRockSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<CarvedRockQuery>();
        }
    }
}
