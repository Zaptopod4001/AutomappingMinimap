using System.Collections.Generic;
using UnityEngine;

namespace Eses.AutoMapper
{

    // Copyright 
    // Created by Sami S. 

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.

    // WHY?
    // This piece of code is here only to show my coding skills

    public class Automap : MonoBehaviour
    {

        [Header("Map Renderer")]
        public AutomapRenderer mapRenderer;
        IAutomapRenderer mapRend;

        [Header("Player Settings")]
        public float sightArea = 2.2f;
        public Vector2Int PlayerPosition { get => playerPosition; }
        Vector2Int playerPosition;


        // Mapdata
        int[,] data;
        Cell[,] cells;
        public Cell[,] Cells { get => cells; }

        int width;
        int height;




        // Init -----

        void Awake()
        {
            mapRend = mapRenderer;
        }

        public void Init(int[,] mapData)
        {
            // Shorthands to avoid messing values
            this.width = mapData.GetLength(1);
            this.height = mapData.GetLength(0);

            // Store mapdata
            this.data = mapData;
            cells = CreateMinimap(mapData);


            // Update mapped in start
            UpdateMapDataAround(playerPosition);

            // View
            mapRend.Init(this);
        }

        Cell[,] CreateMinimap(int[,] map)
        {
            Cell[,] newMiniMap = new Cell[map.GetLength(0), map.GetLength(1)];

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    var cell = new Cell();
                    cell.type = map[y, x];

                    newMiniMap[y, x] = cell;
                }
            }

            return newMiniMap;
        }



        // Update ----

        void Update()
        {
            if (Input.GetKeyUp(KeyCode.L))
            {
                cells = Save.LoadMinimap();

                if (cells != null)
                    mapRend.Render();
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                Save.SaveMinimap(cells);
            }
        }



        // Data -------

        public void UpdateMapData(int[,] data)
        {
            this.data = data;
            var w = this.data.GetLength(1);
            var h = this.data.GetLength(0);

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    cells[y, x].type = this.data[y, x];
                }
            }

            mapRend.Render();
        }

        public void SetPlayerTo(int x, int y)
        {
            playerPosition.x = x;
            playerPosition.y = y;
            UpdateMapDataAround(playerPosition);
        }



        // Helpers ----

        void UpdateMapDataAround(Vector2Int pos)
        {
            List<Cell> circle = GetTilesInCircle(pos);

            foreach (var cell in circle)
            {
                cell.mapped = true;
            }
        }

        List<Cell> GetTilesInCircle(Vector2Int pos)
        {
            var w = data.GetLength(1);
            var h = data.GetLength(0);

            List<Cell> inCircle = new List<Cell>();

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Vector2 pos1 = new Vector2(x, y);
                    Vector2 pos2 = new Vector2(pos.x, pos.y);

                    if (Vector2.Distance(pos1, pos2) < sightArea)
                    {
                        inCircle.Add(cells[y, x]);
                    }
                }
            }

            return inCircle;
        }

    }

}