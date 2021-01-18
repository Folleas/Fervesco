using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelBuilder : EditorWindow {
    GameObject floor;
    List<GameObject> gameObjects = new List<GameObject>();
    bool showPrefabPoolWindow = false;
    bool showPrefabPreview = false;
    int prefabPoolSize = 0;
    [SerializeField]
    private int paletteIndex;

    // The window is selected if it already exists, else it's create d.
    [MenuItem("Window/LevelBuilder")]
    private static void ShowWindow() {
        EditorWindow.GetWindow(typeof(LevelBuilder));
    }

    // Called to draw the MapEditor windows.
    private void OnGUI() {
        floor = (GameObject)EditorGUILayout.ObjectField(floor, typeof(GameObject), true);
        prefabPoolSize = EditorGUILayout.IntField("Prefab Pool Size", prefabPoolSize);
        showPrefabPoolWindow = EditorGUILayout.Toggle("Show Prefab Pool", showPrefabPoolWindow);
        if (showPrefabPoolWindow)
            ShowPrefabPool();
        showPrefabPreview = EditorGUILayout.Toggle("Show Prefab Preview", showPrefabPreview);
        if (showPrefabPreview)
            ShowPrefabPreview();
    }

    void ShowPrefabPreview() {
        // Get a list of previews, one for each of our prefabs
        List<GUIContent> paletteIcons = new List<GUIContent>();
        foreach (GameObject prefab in gameObjects) {
            // Get a preview for the prefab
            Texture2D texture = AssetPreview.GetAssetPreview(prefab);
            paletteIcons.Add(new GUIContent(texture));
        }

        // Display the grid
        paletteIndex = GUILayout.SelectionGrid(paletteIndex, paletteIcons.ToArray(), 6);
    }

    void ShowPrefabPool() {
        while (gameObjects.Count < prefabPoolSize)
            gameObjects.Add(null);
        while (gameObjects.Count > prefabPoolSize)
            gameObjects.RemoveAt(gameObjects.Count - 1);
        for (int i = 0; i < gameObjects.Count; i++) {
            gameObjects[i] = (GameObject)EditorGUILayout.ObjectField(gameObjects[i], typeof(GameObject), true);
        }
    }
}