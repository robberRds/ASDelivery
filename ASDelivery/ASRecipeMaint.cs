using System;
using System.Collections;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.AR;
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

        #region View
        public SelectFrom<ASRecipe>.View RecipeView;

        public SelectFrom<ASIngredients>.
            Where<ASIngredients.refNbr.
                IsEqual<ASRecipe.refNbr.FromCurrent>>.
            View IngredientsView;

        //public SelectFrom<ASIngredients,LeftJoin<InventoryItem, On<InventoryItem.inventoryID.IsEqual<ASIngredients.inventoryCD>>>> Ingr;

        public new PXSave<ASRecipe> Save;
        public new PXCancel<ASRecipe> Cancel;

        public PXSetup<ASSetup> AutoNumSetup;
        #endregion

        #region Events

        protected void _(Events.FieldUpdated<ASRecipe, ASRecipe.isActive> e)
        {
            ASRecipe row = e.Row;
            if (row == null)
                return;

            var recipeList = PXSelect<ASRecipe,
                Where<ASRecipe.dishID, Equal<Required<ASRecipe.dishID>>,
                    And<ASRecipe.refNbr, NotEqual<Required<ASRecipe.refNbr>>>>>
                .Select(this, row.DishID, row.RefNbr);

            foreach (ASRecipe recipe in recipeList)
            {
                if (row.IsActive == true && recipe.IsActive == true)
                {
                    recipe.IsActive = false;

                    RecipeView.Update(recipe);
                }
            }
        }

        #endregion

    }
}