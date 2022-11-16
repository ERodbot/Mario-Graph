using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _tilePrefab;

    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, Tile> _tiles;

    void Start()
    {
        generateGrid();
    }


    void generateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                
            
                var spawnedTile = Instantiate(_tilePrefab, new Vector3( x*0.4f+0.23f, y*0.4f+0.27f), Quaternion.identity);
                spawnedTile.name = $"Tile{x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
                _tiles[new Vector2(x,y)] = spawnedTile;
            }
        }

        _cam.transform.position = new Vector3((float)_width/5+(float)_width/6-0.30f, (float)_height/5, -10);
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos,out var tile))
        {
            return tile;
        }
        return null;
    }

}
