using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MyTools
{
    public class IP_ReplaceObject_Editors : EditorWindow
    {
        #region Variables
        int currentSelectionCount = 0;

        #endregion

        #region Builtin Methods
        public static void LaunchEditor()
        {
            var editorWin = GetWindow<IP_ReplaceObject_Editors>("Replace Objects");
            editorWin.Show();
        }

        private void OnGUI()
        {
            //Check amount of selected objects
            GetSelection();

            EditorGUILayout.BeginVertical();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Selection Count:" + currentSelectionCount.ToString(), EditorStyles.boldLabel);

            EditorGUILayout.Space();
            EditorGUILayout.EndVertical();

            Repaint();
        }
        #endregion

        #region Custom Methods
        void GetSelection()
        {
            currentSelectionCount = 0;
            currentSelectionCount = Selection.gameObjects.Length;
        }
        #endregion

    }
}

