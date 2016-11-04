#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Firefly))]
public class FireflyEditor : Editor {

  public override void OnInspectorGUI() {
    Firefly t = (Firefly)target;

    t.size = EditorGUILayout.FloatField("Size", t.size);
    t.color = EditorGUILayout.ColorField("Color", t.color);

    if (GUI.changed) {
      EditorUtility.SetDirty(target);
    }
  }
}
#endif