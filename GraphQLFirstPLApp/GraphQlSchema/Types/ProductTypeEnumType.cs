using GraphQL.Types;

namespace GraphQLFirstPLApp.GraphQLSchema.Types
{
    public class ProductTypeEnumType : EnumerationGraphType<GraphQLFirstPLApp.Data.ProductType>
    {
        public ProductTypeEnumType()
        {
            Name = "Type";
            Description = "The Type of Product";
        }
    }
}