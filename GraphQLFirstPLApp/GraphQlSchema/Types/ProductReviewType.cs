using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities = GraphQLFirstPLApp.Data.Entities;

namespace GraphQLFirstPLApp.GraphQLSchema.Types
{
    public class ProductReviewType : ObjectGraphType<Entities.ProductReview>
    {
        public ProductReviewType()
        {
            Field(t => t.Id);
            Field(t => t.Title);
            Field(t => t.Review);
        }
    }
}
