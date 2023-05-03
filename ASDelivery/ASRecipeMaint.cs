using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.IN;

namespace ASDelivery
{
    public class ASRecipeMaint : PXGraph<ASRecipeMaint>
    {
        public SelectFrom<ASRecipe>.View Recipe;
        public SelectFrom<ASIngredients>.View Ingredients;

        //public SelectFrom<ASIngredients,LeftJoin<InventoryItem, On<InventoryItem.inventoryID.IsEqual<ASIngredients.inventoryCD>>>> Ingr;

        public PXSave<ASRecipe> Save;
        public PXCancel<ASRecipe> Cancel;

    }
}