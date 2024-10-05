using UnityEngine;
using UnityEditor;

namespace MyTools // Namespace declaration
{
    public class EditorMenus
    {
        [MenuItem("MyTools/Project/Project Setup Tool")] // Add to Unity's menu
        public static void InitProjectSetupTool()
        {
            // Debug.Log("Launching ProjectSetupTool"); 
            ProjectSetup_window.InitWindow(); // Call to initialize the window
        }
        [MenuItem("MyTools/Project/Replace Selected Objects")]
        public static void ReplaceSelectedObj()
        {
            IP_ReplaceObject_Editors.LaunchEditor();
        }
    }
}
