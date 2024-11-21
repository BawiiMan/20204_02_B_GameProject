using MyGame.CraftingSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.CraftingSystem
{
    public class CraftingManager : MonoBehaviour
    {
        private static CraftingManager instance;

        public static CraftingManager Instance => instance;

        private Dictionary<string, Recipe> recipes = new Dictionary<string, Recipe>();
        private Inventory<IItem> playerInventory;
        private InventoryManager inventoryManager;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            //InventoryManager 찾기

            inventoryManager = FindObjectOfType<InventoryManager>();
            if (inventoryManager != null)
            {
                playerInventory = inventoryManager.GetInventory();
            }
            else
            {
                Debug.LogError("InventoryManager no found !");
            }
        }

        public bool TryCraft(string recipeId)
        {
            if (!recipes.TryGetValue(recipeId, out Recipe recipe))
                return false;
            if (!CheckMaterials(recipe))
                return false;

            ConsumeMaterials(recipe);
            CreateResult(recipe);

            return true;
        }
        private bool CheckMaterials(Recipe recipe)                  //재료 확인 함수
        {
            playerInventory = inventoryManager.GetInventory();

            foreach (var material in recipe.requiredMaterials)
            {
                if (!playerInventory.HasEnough(material.Key, material.Value))
                    return false;
            }

            return true;
        }
        private void ConsumeMaterials(Recipe recipe)
        {
            foreach (var material in recipe.requiredMaterials)
            {
                playerInventory.RemoveItems(material.Key, material.Value);
            }
        }

        private void CreateSwordRecipe()
        {
            var ironSword = new Weapon("Iron Sword", 1001, 10);
            var recipe = new Recipe("RECIPE_IRON_SWORD", ironSword, 1);
            recipe.AddRequirdMaterial(101, 2);      //Iron Ingot X2
            recipe.AddRequirdMaterial(102, 1);      //Wood X 1
            recipes.Add(recipe.recipeId, recipe);
        }

        private void CreatePotionRecipe()
        {
            var healthPotion = new HealthPotion("Health Potion", 2001, 50);
            var recipe = new Recipe("RECIPE_HEALTH_POTION", healthPotion, 1);
            recipe.AddRequirdMaterial(201, 2);      //Herb X2
            recipe.AddRequirdMaterial(202, 1);      //Water X1
            recipes.Add(recipe.recipeId, recipe);
        }

        private void CreateResult(Recipe recipe)
        {
            playerInventory.AddItem(recipe.resultItem);
        }

        public List<Recipe> GetAvilableRecipes()
        {
            return new List<Recipe>(recipes.Values);
        }
    }
}
