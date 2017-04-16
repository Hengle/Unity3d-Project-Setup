using UnityEditor;
using UnityEngine;


namespace Homebrew
{

  public class CodeTemplatesMenuItems
  {

    private const string MENU_ITEM_PATH = "Assets/Create/";
    private const int MENU_ITEM_PRIORITY = 70;

      [MenuItem (MENU_ITEM_PATH+"BasicScripts/C# Script",false,MENU_ITEM_PRIORITY)]
    private static void CreateBasicScript()
    {
      CodeTemplates.CreateFromTemplate (
          "BasicScript.cs",
  @"Assets/ProjectPref/Editor/CodeTemplates/Templates/BasicScript.txt");

    }

  }

}