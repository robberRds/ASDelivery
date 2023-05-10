using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.IN;

namespace ASDelivery
{

    public class ASRecipeMaint : PXGraph<ASRecipeMaint, ASRecipe>
    {
        #region Graph constructor
        public ASRecipeMaint()
        {
            ASSetup setup = AutoNumSetup.Current;
        }
        #endregion

        public SelectFrom<ASRecipe>.View Recipe;

        public SelectFrom<ASIngredients>.
            Where<ASIngredients.refNbr.
                IsEqual<ASRecipe.refNbr.FromCurrent>>.
            View Ingredients;

        //public SelectFrom<ASIngredients,LeftJoin<InventoryItem, On<InventoryItem.inventoryID.IsEqual<ASIngredients.inventoryCD>>>> Ingr;

        public new PXSave<ASRecipe> Save;
        public new PXCancel<ASRecipe> Cancel;

        public PXSetup<ASSetup> AutoNumSetup;

    }
}