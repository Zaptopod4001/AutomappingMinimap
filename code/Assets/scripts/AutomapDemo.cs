using System.Collections;
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

    public class AutomapDemo : MonoBehaviour
    {

        [Header("Assign")]
        public Automap mapper;


        // mapdata ------

        readonly int empty = 0;
        readonly int walls = 1;
        readonly int stairs_dn = 2;
        readonly int stairs_up = 3;
        readonly int door = 4;
        readonly int npc = 5;

        int[,] map = new int[,]
        {
            {2,0,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,1,0,0,0,0,1,0,0,1},
            {1,0,1,0,0,0,1,3,0,0,0,1,1},
            {1,0,1,1,1,1,1,1,0,1,0,0,1},
            {1,0,0,0,0,4,0,1,1,1,1,0,1},
            {1,0,0,1,1,1,0,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1}
        };

        int[,] compositeMap;
        int height;
        int width;

        // Player
        Vector2Int playerPos;

        // NPCs
        Vector2Int e1 = new Vector2Int(3, 4);
        Vector2Int e2 = new Vector2Int(6, 5);



        // Init --------

        void Start()
        {
            // Set size
            height = map.GetLength(1);
            width = map.GetLength(0);

            // For moving objects and static bg composite
            compositeMap = new int[width, height];

            // Set player pos here
            playerPos = new Vector2Int(0, 0);
            playerPos.x = 0;
            playerPos.y = 0;

            // Create minimap
            mapper.Init(map);
            mapper.SetPlayerTo(0, 0);

            // Test agents 
            StartCoroutine(MovingNPCs());
        }




        // Main update loop ------------

        void Update()
        {
            PlayerInput();

            // don't do every frame in real world
            UpdateMapdata();
        }




        // Character movement demo -----

        void PlayerInput()
        {
            var nextPos = new Vector2Int(playerPos.x, playerPos.y);

            if (Input.GetKeyDown(KeyCode.UpArrow))
                nextPos.y -= 1;

            if (Input.GetKeyDown(KeyCode.DownArrow))
                nextPos.y += 1;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
                nextPos.x -= 1;

            if (Input.GetKeyDown(KeyCode.RightArrow))
                nextPos.x += 1;

            if (nextPos.magnitude > 0 && CanWalk(nextPos.x, nextPos.y))
            {
                MovePlayer(nextPos.x, nextPos.y);
            }
        }

        void MovePlayer(int x, int y)
        {
            playerPos.x = x;
            playerPos.y = y;
        }

        bool CanWalk(int x, int y)
        {
            return x >= 0 && x < height && y >= 0 && y < width && map[y, x] != 1;
        }

        IEnumerator MovingNPCs()
        {
            while (true)
            {
                // Set moving
                e1 = new Vector2Int(3, 4);
                e2 = new Vector2Int(8, 2);
                yield return new WaitForSeconds(2f);

                e1 = new Vector2Int(4, 4);
                e2 = new Vector2Int(9, 2);
                yield return new WaitForSeconds(2f);
            }
        }



        // View update demo ------------

        void UpdateMapdata()
        {
            // Static tiles
            compositeMap = new int[width, height];

            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    compositeMap[y, x] = map[y, x];
                }
            }

            // NPCs
            compositeMap[e1.y, e1.x] = npc;
            compositeMap[e2.y, e2.x] = npc;

            // Set player
            mapper.SetPlayerTo(playerPos.x, playerPos.y);
            mapper.UpdateMapData(compositeMap);
        }

    }

}