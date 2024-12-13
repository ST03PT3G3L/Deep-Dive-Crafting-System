<h1>Before Usage</h1>

Before you start creating your own crafting recipes and materials, you will first have to setup your scene to allow the scripts to work their magic.
Inside your scene, you will have to add the following prefabs: InventoryController and CraftingController, as well as a Canvas object with the prefabs ExampleInventory and CraftingInterface inside of it.
The ExampleInventory and CraftingInterface UI is completely customizable, as well as the prefabs ExampleCraftUIObject and ExampleInventoryGUIItem, however you need to make sure not to remove or rename any of the existing GameObjects inside these prefabs.

<H1>How to use</H1>

In this ReadMe document, I will explain step for step how to use the crafting system assets for within your own project.

<h3>Step 1: Create a prefab for the Item you want to craft</h3>
The first thing you will want to do, is create a prefab of the item you want to actually craft. It does not need to have any scripts as of now.
For this example, I have created a simple cube prefab with an animation that makes it rotate 360 degrees.

![image](https://github.com/user-attachments/assets/7929253b-134f-45ce-9668-9e99488152c6)

Create a new script for your prefab, give it a name, and then edit the script so it inherits from the ItemBase script instead of Monobehaviour, as shown in the image below.

![image](https://github.com/user-attachments/assets/e6c6ccf0-a08b-4d9d-a400-62a24ed4e73b)

If there is anything you would like to happen when this item is crafted or used, you will need to override the OnUse() and OnCraft() methods from the ItemBase script.
The OnCraft() method will always run whenever your item is crafted, and if you do not override the base method, it will simply display a message in the Debug Console. Anything you wish the item to do once it's crafted, for example get stored in the player's inventory, you want to put inside this method. 
The OnUse() method will also send a message in the Debug Console if it is not overwritten, except this method will only run when you want it to.
In the image below you can see the script I have created for my example item:

![image](https://github.com/user-attachments/assets/a2cccaa0-4b31-43dd-afa7-c212b7ede0c8)

When the item is crafted, it will first increase in size, stay large for a bit, and then shrink back down.
When you press the left shift key, it will run the OnUse() Method, which makes it play the rotating animation, having it rotate for 360 degrees.

<h3>Step 2: Create a crafting material</h3>
To create a new material to craft with, you will have to right click in the folder you want to store the material, then go through Create -> ScriptableObjects -> CreateMaterial.

![image](https://github.com/user-attachments/assets/8bf0a9e1-4af1-41cf-b370-5af6613c80aa)

After pressing the CreateMaterial option, you will create a new scriptable object of the class Material. You will have to give this material a Name and a Description.
For this example, I am keeping it simple.

![image](https://github.com/user-attachments/assets/9af860c5-53c6-45a1-a7b8-8276ad26c87c)

In the next version, you will also be able to give an icon to your material to see while it's in your inventory, as well as make the material craftable.

<h3>Step 3: Create your recipe</h3>
The step for creating a new material and creating a recipe are very simillar. However, instead of pressing CreateMaterial, you now have to navigate to Create -> ScriptableObjects -> CreateRecipe, as shown in the image below:

![image](https://github.com/user-attachments/assets/18025a67-d46b-4cf3-b864-a8756b4c9030)

This will once again create a new scriptable object, except this time it's of the class Recipe.
Inside this scriptable object, you will once again have to give it a name and a description.
However, unlike the material, you will also have to give the recipe the prefab of the item you want to create, as well as a list of all the materials you want to use for this recipe, as well as the amount of that material is needed.
This can be as many different materials as you want. In the example below, I will just give it the example material, with an amount of 50.

![image](https://github.com/user-attachments/assets/229a355e-3d5e-4d02-a2f6-9429b676c318)

<h3>Step 4: Add your recipe to your scene</h3>

Finally, to get your crafting recipe to work, you will have to insert your recipe into the Recipes list within the CraftingController prefab using the Inspector. If you wish, you can also do this via scripts as you can access the recipes list by using CraftingController.Instance.recipes.
The same goes for the InventoryController prefab. You will want to insert the crafting materials inside the recipeMaterials list, which you can once again do via the inspector (Don't forget to set the count as well), which is useful for testing puprposes of your crafting recipe, but you can also do this through code by using InventoryController.Instance.recipeMaterials.
For the purposes of this example, I have done this within the inspector, as seein in the images below:

![image](https://github.com/user-attachments/assets/54203dec-4a49-4e73-aa2f-e0f4ba3083e0)
![image](https://github.com/user-attachments/assets/f96a06e7-8349-4a15-8bcf-63fbb3797355)

<h3>Results</h3>

If you have succesfully followed all the steps and start your game, it should look like this:

![image](https://github.com/user-attachments/assets/efa944c5-2294-419e-aa55-138db2cf82fa)

As you can see, I have 55 TestMaterials, which is enough to craft the item I created the recipe for, which needs 50 TestMaterials. When I press the craft button, the item will be created and appear in the scene, after which it will Grow and Shrink, as expected through the OnCraft() Method.
When I do press the LeftShift key, it will rotate 360 degrees, as expected through the OnUse() Method, as shown in the Gif below:

![ExampleCraft](https://github.com/user-attachments/assets/a39e8ca0-993a-4de5-953e-204f3c2360b9)
