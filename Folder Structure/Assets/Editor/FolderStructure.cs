using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class FolderStructure : EditorWindow
{
    static List<string> folderNames = new List<string>()
    {
        "Animations",
        "Editor",
        "Materials",
        "Models",
        "Plugins",
        "Prefabs",
        "Resources",
        "Scenes",
        "Scripts",
        "Shaders",
        "Sounds",
        "Sprites",
        "Textures"
    };

    [MenuItem("Tools/CreateFolderStructure")]
    private static void Init()
    {
        CreateFolderStructure();
    }

    // Creates the folder in the given name
    static void CreateFolder(string path)
    {
        if (!Directory.Exists(path))
        {
            Debug.Log("Folder doesn't exists, thus creating a new folder: " + Path.GetFileName(path));
            Directory.CreateDirectory(path);
        }
    }

    // Creates the folder structure for the items in the list - folderNamesList
    static void CreateFolderStructure()
    {
        if (folderNames.Count > 0)
        {
            var assetPath = Application.dataPath;
            foreach (var name in folderNames)
            {
                var folderPath = Path.Combine(assetPath, name);
                CreateFolder(folderPath);
            }

            AssetDatabase.Refresh();
        }
    }

}
