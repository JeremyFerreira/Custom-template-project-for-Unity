using System;
using UnityEngine;
using System.Reflection;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DraggablePoint : PropertyAttribute { }

#if UNITY_EDITOR
[CustomEditor(typeof(MonoBehaviour), true)]
public class DraggablePointDrawer : Editor
{

   /* readonly GUIStyle style = new GUIStyle();

    void OnEnable()
    {
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.white;
    }
    bool editMode;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Color oldColor = GUI.color;
        if (editMode)
        {
            GUI.color = Color.red;
            if (GUILayout.Button("Stop Edit"))
            {
                editMode = false;
            }
        }
        else
        {
            GUI.color = Color.green;
            if (GUILayout.Button("Edit"))
            {
                editMode = true;
            }
        }
        GUI.color = oldColor;
    }

    public void OnSceneGUI()
    {
        if(editMode)
        {
            var property = serializedObject.GetIterator();
            while (property.Next(true))
            {
                if (property.propertyType == SerializedPropertyType.Vector3)
                {
                    var field = serializedObject.targetObject.GetType().GetField(property.name,
                        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    if (field == null)
                    {
                        continue;
                    }

                    var draggablePoints = field.GetCustomAttributes(typeof(DraggablePoint), false);
                    if (draggablePoints.Length > 0)
                    {
                        Handles.Label(property.vector3Value, property.name);
                        property.vector3Value = Handles.PositionHandle(property.vector3Value, Quaternion.identity);
                        serializedObject.ApplyModifiedProperties();
                    }
                }
            }
        }
    }*/
}
#endif
