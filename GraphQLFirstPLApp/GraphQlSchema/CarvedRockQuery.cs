using GraphQL.Types;
using GraphQLFirstPLApp.Data.Repositories;
using GraphQLFirstPLApp.GraphQLSchema.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLFirstPLApp.GraphQlSchema
{
    public class CarvedRockQuery : ObjectGraphType
    {
        public CarvedRockQuery(ProductRepository repo)
        {
           
            Field<ListGraphType<ProductType>>("products", resolve: context => repo.GetAll());
            
        }
    }
}
