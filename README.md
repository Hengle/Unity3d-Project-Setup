# Unity3d-Project-Setup
Use this library on blank project to generate Project tree.
Also includes :
- Scene tree generator
- Game object generator
- Code Templates generator

### ProjectTreeGenerator.cs ###
A script that will generate a project tree for you. 
Find GenerateFolderStructure method in the script and feel free to change structure to what you want. Also special .keep files will be included in folders to prevent ignoring empty folders with any processors.
```csharp
        private static Folder GenerateFolderStructure()
        {
            Folder rootFolder = new Folder ("Assets","");
            rootFolder.Add ("Extensions");
            rootFolder.Add ("Plugins");
            rootFolder.Add ("3rdParty");
            var GameAssets = rootFolder.Add ("GAME_ASSETS");
            GameAssets.Add ("Data");
            var ScriptAssets = GameAssets.Add ("Scripts");
            ScriptAssets.Add ("Attributes");
            ScriptAssets.Add ("GameLogic");
            ScriptAssets.Add ("Enums");
            ScriptAssets.Add ("ScriptableObjects");
            ScriptAssets.Add ("Utility");
            GameAssets.Add ("Scenes");
            var Prefabs = GameAssets.Add ("Prefabs");
            Prefabs.Add ("Resources");
            var staticAssets = GameAssets.Add ("STATIC_ASSETS");
            staticAssets.Add ("Models");
            staticAssets.Add ("Animations");
            staticAssets.Add ("Animators");
            staticAssets.Add ("Effects");
            staticAssets.Add ("Fonts");
            staticAssets.Add ("Materials");
            staticAssets.Add ("Shaders");
            staticAssets.Add ("Audio");
            staticAssets.Add ("Sprites");
            staticAssets.Add ("Textures");
            staticAssets.Add ("Videos");
            staticAssets.SubFolders.Find (f => f.Name=="Audio").Add ("Sounds");
            staticAssets.SubFolders.Find (f => f.Name=="Audio").Add ("Music");
            staticAssets.SubFolders.Find (f => f.Name=="Audio").Add ("Ambients");
            return rootFolder;
        }
    }
}
```
The script can be executed from Tools->Project->Generate Project Tree

[![Example](https://i.gyazo.com/8f24c7b42b51364f2de9cb5a86b4f175.gif "Example")](https://i.gyazo.com/8f24c7b42b51364f2de9cb5a86b4f175.gif "Example")

### SceneGenerator.cs ###
Setups scene in desired way. Feel free to customize tree from the script.
The script executes from Tools->Project->Generate Scene.
### ObjectGenerator.cs ###
Create custom object tree. Useful for making advanced game object with different children nodes. I usually do that to divide game logic from model view. 

[![Example](https://i.gyazo.com/a820e0297e1cb00cd5636877166662c5.png "Example")](https://i.gyazo.com/a820e0297e1cb00cd5636877166662c5.png "Example")

### CodeTemplates.cs ###
A useful pack of scripts to generate code files in unity3d. Also with enhanced ScriptKeywordProcessor from Sarper Soher. 

[![Example](https://i.gyazo.com/411120b4433f9be438c6e1cb28c96e4f.gif "Example")](https://i.gyazo.com/411120b4433f9be438c6e1cb28c96e4f.gif "Example")

In my case I've got this script :
```csharp
/*===============================================================
Product:    Battlecruiser
Developer:  Dimitry Pixeye - pixeye@hbrew.store
Company:    Homebrew - http://www.hbrew.store
Date:       16/04/2017 12:58
================================================================*/
using UnityEngine;

namespace Homebrew{

public class BasicScript : MonoBehaviour {


}
}
```
The easy steps to generate your own scripts.

- Open **templates** folder. 
You can find it In your assets folder  ProjectPref->Editor->CodeTemplates->Templates
- Add a simple .txt file.  
For example BasicScript
- Add some meat to your script! 

Customization rules :
The first line in your must be a path from where you will take the script template.
For example "BasicScripts/C# Scripts"

[![Example](https://i.gyazo.com/193ada0dad30c91e34d05e3a01644c82.png "Example")](https://i.gyazo.com/193ada0dad30c91e34d05e3a01644c82.png "Example")


You always should Add ##NAME## after class or interface. By default the name will be taken from the name of the template. Use prebuild tags for more advanced customization.

    #PROJECTNAME# 
    #DEVELOPERNAME# 
    #COMPANY# 
    #CREATIONDATE# 
    #NAMESPACE#

You can add more special tags if you want but in this case you should add them to postprocessor. 
To do that open **TemplateKeys.txt** in ProjectPref->Editor->CodeTemplates->Settings

The structure of templatekeys must be similar to this template:

      #CREATIONDATE#
      [Time]
      #PROJECTNAME#
      [PlayerSettings.productName]
      #DEVELOPERNAME#
      Your name
      #COMPANY#
      [PlayerSettings.companyName] 
      #NAMESPACE#
      Homebrew

- Odd line - the tag id braced in '#'
- Even line - the description of the tag.
- Use [Time] in description to add Current machine time
- Use [PlayerSettings.productName] in description to get product name from unity3d project settings
- Use [PlayerSettings.companyName] in description to get company name from unity3d project settings
