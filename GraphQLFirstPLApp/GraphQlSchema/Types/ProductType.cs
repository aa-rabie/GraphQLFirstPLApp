using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLFirstPLApp.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Entities = GraphQLFirstPLApp.Data.Entities;

namespace GraphQLFirstPLApp.GraphQLSchema.Types
{
    public class ProductType : ObjectGraphType<Entities.Product>
    {
        public ProductType(ProductReviewRepository repo)
        {
            
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Description);
            Field(t => t.IntroducedAt).Description("When the product was first introduced in the catalog");
            Field(t => t.PhotoFileName).Description("The file name of the photo so the client can render it");
            Field(t => t.Price);
            Field(t => t.Rating).Description("The (max 5) star customer rating");
            Field(t => t.Stock);
            Field<ProductTypeEnumType>("Type", "The type of product");
            Field<ListGraphType<ProductReviewType>>("reviews", resolve: context => repo.GetByProductId(context.Source.Id));
        }
    }
}
