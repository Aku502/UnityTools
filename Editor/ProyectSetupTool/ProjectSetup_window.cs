using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.VersionControl; // For editor scripting
using UnityEditor.SceneManagement;
using Unity.VisualScripting;
using System.Xml.Serialization.Configuration; // For creating scenes within the Editor

namespace MyTools
{
    public class ProjectSetup_window : EditorWindow
    {
        #region Variables
        static ProjectSetup_window win; // Stores the window instance

        private string gameName = "Game"; // Game name to be used for folder and scene creation, default is "Game"

        #endregion

        #region Main Methods
        /// <summary>
        /// Initializes and opens the Project Setup window. If a window already exists, it reuses it.
        /// </summary>
        public static void InitWindow()
        {
            win = EditorWindow.GetWindow<ProjectSetup_window>("Project Setup");
            win.Show(); // Displays the window
        }

        /// <summary>
        /// Draws the GUI for the Project Setup window.
        /// </summary>
        void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            gameName = EditorGUILayout.TextField("Game Name: ", gameName); // Input field for game name
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Create Project Structure", GUILayout.Height(35), GUILayout.ExpandWidth(true)))
            {
                // Button to create project structure when clicked
                CreateProjectFolders();
            }

            // Repaint window to refresh any changes
            if (win != null)
            {
                win.Repaint();
            }
        }
        #endregion

        #region Custom Methods
        /// <summary>
        /// Verifies the game name and creates the root and subfolders for the project.
        /// </summary>
        void CreateProjectFolders()
        {
            // Check if gameName is valid
            if (string.IsNullOrEmpty(gameName))
            {
                return;
            }

            // Warns the user if they are using the default name "Game"
            if (gameName == "Game")
            {
                if (!EditorUtility.DisplayDialog("Project Setup Warning", "Do you really want to call your project Game?", "Yes", "No"))
                {
                    return;
                }
            }

            // Create the root folder based on the gameName
            string assetPath = Application.dataPath;
            string rootPath = assetPath + "/" + gameName;
            DirectoryInfo rootInfo = Directory.CreateDirectory(rootPath);

            // Ensure the folder was created
            if (!rootInfo.Exists)
            {
                return;
            }

            //Creates SubFolders,refreshes database and closes window
            CreateSubFolders(rootPath);
            AssetDatabase.Refresh();
            CloseWindow();
        }

        /// <summary>
        /// Creates subfolders under the root directory.
        /// </summary>
        /// <param name="rootPath">Path to the root folder.</param>
        void CreateSubFolders(string rootPath)
        {
            DirectoryInfo rootInfo = null;
            List<string> folderNames = new List<string>();

            // Art folder and subfolders
            rootInfo = Directory.CreateDirectory(rootPath + "/Art");
            if (rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.AddRange(new string[] { "Animation", "Audio", "Fonts", "Objects", "Materials", "Textures" });
                CreateFolders(rootPath + "/Art", folderNames);
            }

            // Code folder and subfolders
            rootInfo = Directory.CreateDirectory(rootPath + "/Code");
            if (rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.AddRange(new string[] { "Editor", "Scripts", "Shaders" });
                CreateFolders(rootPath + "/Code", folderNames);
            }

            // Resources folder and subfolders
            rootInfo = Directory.CreateDirectory(rootPath + "/Resources");
            if (rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.AddRange(new string[] { "Characters", "Managers", "Props", "UI" });
                CreateFolders(rootPath + "/Resources", folderNames);
            }

            // Prefabs folder and subfolders
            rootInfo = Directory.CreateDirectory(rootPath + "/Prefabs");
            if (rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.AddRange(new string[] { "Characters", "Props", "UI" });
                CreateFolders(rootPath + "/Prefabs", folderNames);
            }

            // Create default scenes (GameScene, MainMenu, and LoadingScreen)
            DirectoryInfo sceneInfo = Directory.CreateDirectory(rootPath + "/Scenes");
            if (sceneInfo.Exists)
            {
                CreateScene(rootPath + "/Scenes", gameName + "_GameScene");
                CreateScene(rootPath + "/Scenes", gameName + "_MainMenu");
                CreateScene(rootPath + "/Scenes", gameName + "_LoadingScreen");
            }
        }

        /// <summary>
        /// Creates a new scene and saves it in the specified path.
        /// </summary>
        /// <param name="aPath">Path to save the scene.</param>
        /// <param name="aName">Name of the scene.</param>
        void CreateScene(string aPath, string aName)
        {
            // Create a new scene with default game objects
            Scene actScene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
            // Save the scene in the specified path
            EditorSceneManager.SaveScene(actScene, aPath + "/" + aName + ".unity", true);
        }

        /// <summary>
        /// Helper method to create multiple subfolders within a given path.
        /// </summary>
        /// <param name="aPath">The root path for the subfolders.</param>
        /// <param name="folders">A list of folder names to create.</param>
        void CreateFolders(string aPath, List<string> folders)
        {
            foreach (string folder in folders)
            {
                Directory.CreateDirectory(aPath + "/" + folder);
            }
        }

        /// <summary>
        /// Closes the Project Setup window.
        /// </summary>
        void CloseWindow()
        {
            if (win)
            {
                win.Close();
            }
        }
        #endregion
    }

}
