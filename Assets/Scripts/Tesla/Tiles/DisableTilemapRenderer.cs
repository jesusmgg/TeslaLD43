using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tesla.Tiles
{
    public class DisableTilemapRenderer : MonoBehaviour
    {
        void Start()
        {
            GetComponent<TilemapRenderer>().enabled = false;
        }
    }
}