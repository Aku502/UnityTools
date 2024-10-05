using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MyTools
{
    public class IP_ReplaceObject_Editors : EditorWindow
    {
        #region Variables
        int objectSelectionCount = 0;  
        GameObject replacementObject;  

        #endregion

        #region Builtin Methods
        public static void LaunchEditor()
        {
            var editorWin = GetWindow<IP_ReplaceObject_Editors>("Replace Objects");
            editorWin.Show();
        }

        private void OnGUI()
        {
            // Check the amount of selected objects
            GetSelection();

            EditorGUILayout.BeginVertical();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Selection Count: " + objectSelectionCount.ToString(), EditorStyles.boldLabel);
            EditorGUILayout.Space();

            replacementObject = (GameObject)EditorGUILayout.ObjectField("Object Replacement: ", replacementObject, typeof(GameObject), true);
            
            if(GUILayout.Button("Replace Selected Objects", GUILayout.ExpandWidth(true), GUILayout.Height(40)))
            { 
                ReplaceSelectedObjects();
            }

            EditorGUILayout.Space();
            EditorGUILayout.EndVertical();

            Repaint();
        }
        #endregion

        #region Custom Methods
        void GetSelection()
        {
            // Directly assign the selected objects count
            objectSelectionCount = Selection.gameObjects.Length;
        }

        void ReplaceSelectedObjects()
        {
            // Check for selection count
            if(objectSelectionCount == 0)
            {
                CustomDialog("At least one object must be selected to be replaced!");
                return;
            }

            // Check for replacement object
            if(!replacementObject)
            {
                CustomDialog("The Object Replacement is empty, please assign an object to replace your selected items!");
                return;
            }

            // Replace Objects
            GameObject[] selectedObjects = Selection.gameObjects;
            for(int i = 0; i < selectedObjects.Length; i++)
            {
                Transform selectTransform = selectedObjects[i].transform;

                // Instantiate the new object with the same position, rotation, and scale
                GameObject newObject = Instantiate(replacementObject, selectTransform.position, selectTransform.rotation);
                newObject.transform.localScale = selectTransform.localScale;

                // Keep the parent of the original object
                newObject.transform.SetParent(selectTransform.parent);

                // Register undo functionality
                Undo.RegisterCreatedObjectUndo(newObject, "Replace Object");
                Undo.DestroyObjectImmediate(selectedObjects[i]);
            }
        }   
        
        void CustomDialog(string aMessage)
        {
            EditorUtility.DisplayDialog("Replace Objects Warning: ", aMessage, "OK");
        }
        #endregion
    }
}
