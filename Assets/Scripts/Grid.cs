using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grid : MonoBehaviour
{
    [SerializeField] private int m_Width, m_Height;
    [SerializeField] private Tile m_TilePreFab;
    [SerializeField] private Transform m_Cam;

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < m_Width; x++)
        {
            for (int y = 0; y < m_Height; y++)
            {
                //spawnsystem
                var spawnedTile = Instantiate(m_TilePreFab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile{x}{y}";

                //sprite offeset setting
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);//spritCollorSystem
                spawnedTile.Init(isOffset);

            }
        }

        //change offset
        m_Cam.transform.position = new Vector3((float)m_Width / 2 - 0.5f, (float)m_Height / 2 - 0.5f, -10);
    }

}
