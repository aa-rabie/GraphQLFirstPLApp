using GraphQL.Types;
using GraphQL.DataLoader;
using GraphQLFirstPLApp.Data.Repositories;
using Entities = GraphQLFirstPLApp.Data.Entities;
using GraphQLFirstPLApp.Data.Entities;

namespace GraphQLFirstPLApp.GraphQLSchema.Types
{
    public class ProductType : ObjectGraphType<Entities.Product>
    {
        public ProductType(IDataLoaderContextAccessor dataLoaderContextAccessor, ProductReviewRepository repo)
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
            Field<ListGraphType<ProductReviewType>>("reviews", resolve: context =>
            {
                var loader = dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<int, ProductReview>(
                    "GetReviewsByProductId",repo.GetByProductIds);
                return loader.LoadAsync(context.Source.Id);
            });
        }
    }
}
