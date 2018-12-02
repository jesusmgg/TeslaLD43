using UnityEngine.Tilemaps;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Tesla.Tiles
{
    public class WaterTile : Tile
    {
    #if UNITY_EDITOR
        [MenuItem("Assets/Create/Water Tile")]
        public static void CreateWaterTile()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Water Tile", "New water tile", "asset",
                "Save Water Tile", "Assets");
            if (path == "")
                return;
            AssetDatabase.CreateAsset(CreateInstance<WaterTile>(), path);
        }
    #endif
    }
}