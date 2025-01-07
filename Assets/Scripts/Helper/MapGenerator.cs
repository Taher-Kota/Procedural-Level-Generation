
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public static MapGenerator instance;
    public GameObject
         roadPrefab,
         grass_Prefab,
         groundPrefab_1,
         groundPrefab_3,
         grass_Far_Prefab,
         grass_Bottom_Prefab,
         land_Prefab_1,
         land_Prefab_2,
         land_Prefab_3,
         land_Prefab_4,
         land_Prefab_5,
         big_Grass_Prefab,
         big_Grass_Bottom_Prefab,
         treePrefab_1,
         treePrefab_2,
         big_Tree_Prefab,
         small_Tree_Prefab;


    public GameObject
            road_Holder,
            land_Holder,
            grass_Holder,
            grass_Far_Holder,
            house_Holder,
            big_Tree_Holder;


    public int
       start_Road_Tile;     // initialization number of road tiles,


    public List<GameObject>
            road_Tiles;
            //top_Near_Grass_Tiles,
            //top_Far_Grass_Tiles,
            //bottom_Near_Grass_Tiles,
            //bottom_Far_Land_F1_Tiles,
            //bottom_Far_Land_F2_Tiles,
            //bottom_Far_Land_F3_Tiles,
            //bottom_Far_Land_F4_Tiles,
            //bottom_Far_Land_F5_Tiles;

    // positions for ground1 on top from 0 to startGround3Tile
    //public int[] pos_For_Top_Ground_1;
    // positions for ground2 on top from 0 to startGround3Tile
    //public int[] pos_For_Top_Ground_2;
    // positions for ground4 on top from 0 to startGround3Tile
    //public int[] pos_For_Top_Ground_4;
    // positions for big grass with tree on top near grass from 0 to startGrass Tile
    //public int[] pos_For_Top_Big_Grass;
    // positions for treel on top near grass from 0 to startGrass Tile
    //public int[] pos_For_Top_Tree_1;
    // positions for tree2 on top near grass from 0 to startGrass Tile
    //public int[] pos_For_Top_Tree_2;
    // positions for tree3 on top near grass from 0 to startGrassTile
    //public int[] pos_For_Top_Tree_3;
    // position for road tile on road from 0 to startRoadTile
    //public int pos_For_Road_Tile_1;
    // position for road tile on road from 0 to startRoadTile
    //public int pos_For_Road_Tile_2;
    // position for road tile on road from 0 to startRoadTile
    //public int pos_For_Road_Tile_3;
    // positions for big grass with tree on bottom near grass from 0 to startGrass Tile
    //public int[] pos_For_Bottom_Big_Grass;
    // positions for treel on bottom near grass from 0 to startGrass Tile
    //public int[] pos_For_Bottom_Tree1;
    // positions for tree2 on bottom near grass from 0 to startGrass Tile
    //public int[] pos_For_Bottom_Tree2;
    // positions for tree3 on bottom near grass from 0 to startGrass Tile
    //public int[] pos_For_Bottom_Tree3;

    [HideInInspector]
    public Vector3
        last_Pos_Of_Road_Tile,
        last_Pos_Of_Top_Near_Grass,
        last_Pos_Of_Top_Far_Grass,
        last_Pos_Of_Far_House,     
        last_Pos_Of_Far_Tree,
        last_Pos_Of_Botom_Far_Land_F1,
        last_Pos_Of_Botom_Far_Land_F2,
        last_Pos_Of_Botom_Far_Land_F3,
        last_Pos_Of_Botom_Far_Land_F4,
        last_Pos_Of_Botom_Far_Land_F5;
    [HideInInspector]
    public int
            last_Order_Of_Road,
            last_Order_Of_Top_Near_Grass,
            last_Order_Of_Top_Far_Grass,
            last_Order_Of_Bottom_Near_Grass,
            last_Order_Of_Bottom_Far_Land_F1,
            last_Order_Of_Bottom_Far_Land_F2,
            last_Order_Of_Bottom_Far_Land_F3,
            last_Order_Of_Bottom_Far_Land_F4,
            last_Order_Of_Bottom_Far_Land_F5;

    void Awake()
    {
        MakeInstance();
    }
    void Start()
    {
        Initialize();
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Initialize()
    {
        InitializePlatform(roadPrefab, ref last_Pos_Of_Road_Tile, roadPrefab.transform.position,
            start_Road_Tile, road_Holder, ref road_Tiles, ref last_Order_Of_Road, new Vector3(1.5f, 0f, 0f));
        //InitializePlatform(grass_Prefab, ref last_Pos_Of_Top_Near_Grass, grass_Prefab.transform.position,
        //    start_Grass_Tile, top_Near_Side_Walk_Holder, ref top_Near_Grass_Tiles, ref last_Order_Of_Top_Near_Grass, new Vector3(1.2f, 0f, 0f));
        //InitializePlatform(groundPrefab_3, ref last_Pos_Of_Top_Far_Grass, groundPrefab_3.transform.position,
        //    start_Ground3_Tile, top_Far_Side_Walk_Holder, ref top_Far_Grass_Tiles, ref last_Order_Of_Top_Far_Grass, new Vector3(4.8f, 0f, 0f));
        //InitializePlatform(grass_Bottom_Prefab, ref last_Pos_Of_Bottom_Near_Grass, new Vector3(2.0f, grass_Bottom_Prefab.transform.position.y, 0f)
        //    , start_Grass_Tile, bottom_Near_Side_Walk_Holder, ref bottom_Near_Grass_Tiles, ref last_Order_Of_Bottom_Near_Grass, new Vector3(1.2f, 0f, 0f));
    }

    void InitializePlatform(GameObject prefab, ref Vector3 last_pos, Vector3 last_pos_of_tile,
        int NumberOfTiles, GameObject holder, ref List<GameObject> list_tiles, ref int last_order, Vector3 offset)
    {
        int orderInLayer = 0;
        last_pos = last_pos_of_tile;

        for (int i = 0; i < NumberOfTiles; i++)
        {
            GameObject clone = Instantiate(prefab, last_pos, prefab.transform.rotation) as GameObject;
            clone.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
            //CreateLand(land_Prefab_1, ref last_Pos_Of_Botom_Far_Land_F1, 
            //    new Vector3(clone.transform.position.x -1f, land_Prefab_1.transform.position.y, 0f),land_Holder);
            CreateGrass(grass_Bottom_Prefab, ref last_Pos_Of_Top_Near_Grass,
                new Vector3(clone.transform.position.x , grass_Bottom_Prefab.transform.position.y, 0f), grass_Holder, orderInLayer);
            CreateGrassWithTree(grass_Far_Prefab, treePrefab_1, ref last_Pos_Of_Top_Far_Grass,
                new Vector3(clone.transform.position.x, grass_Far_Prefab.transform.position.y, 0f), grass_Far_Holder, orderInLayer);
            CreateHouse(groundPrefab_1, groundPrefab_3, small_Tree_Prefab, ref last_Pos_Of_Far_House,
                new Vector3(clone.transform.position.x, groundPrefab_1.transform.position.y, 0f),house_Holder, orderInLayer);
            CreateLand(land_Prefab_1, ref last_Pos_Of_Botom_Far_Land_F1,
                new Vector3(clone.transform.position.x, land_Prefab_1.transform.position.y, 0f), land_Holder); 
            CreateLand(land_Prefab_2, ref last_Pos_Of_Botom_Far_Land_F2,
                new Vector3(clone.transform.position.x, land_Prefab_2.transform.position.y, 0f), land_Holder);
            CreateLand(land_Prefab_3, ref last_Pos_Of_Botom_Far_Land_F3,
                new Vector3(clone.transform.position.x, land_Prefab_3.transform.position.y, 0f), land_Holder);
            CreateLand(land_Prefab_4, ref last_Pos_Of_Botom_Far_Land_F4,
                new Vector3(clone.transform.position.x, land_Prefab_4.transform.position.y, 0f), land_Holder);
            CreateLand(land_Prefab_5, ref last_Pos_Of_Botom_Far_Land_F5,
                new Vector3(clone.transform.position.x, land_Prefab_5.transform.position.y, 0f), land_Holder);
            if (orderInLayer == 6)
            {
                CreateBigTree(big_Tree_Prefab, ref last_Pos_Of_Far_Tree,
                    new Vector3(clone.transform.position.x, big_Tree_Prefab.transform.position.y, 0f), big_Tree_Holder);
            }
            clone.transform.SetParent(holder.transform);
            list_tiles.Add(clone);
            orderInLayer++;
            last_order = orderInLayer;
            last_pos += offset;
        }
    }  

    void CreateGrass(GameObject prefab, ref Vector3 last_pos, Vector3 current_pos, GameObject holder, int orderInLayer)
    {
        last_pos = current_pos;
        orderInLayer++;
        if (orderInLayer % 4 == 0)
        {
            GameObject clone2 = Instantiate(big_Grass_Bottom_Prefab) as GameObject;
            clone2.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
            clone2.transform.position = new Vector3(last_pos.x, grass_Bottom_Prefab.transform.position.y, 0f);
            clone2.transform.SetParent(holder.transform);
        }
        else
        {
            GameObject clone = Instantiate(prefab, last_pos, prefab.transform.rotation) as GameObject;
            clone.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
            clone.transform.SetParent(holder.transform);
        }
        last_pos.x += 1.5f;
    }

    void CreateGrassWithTree(GameObject grass, GameObject tree1, ref Vector3 last_pos,
        Vector3 current_pos, GameObject holder, int orderInLayer)
    {

        last_pos = current_pos;
        if (orderInLayer % 4 == 0)
        {
            GameObject grassclone = Instantiate(big_Grass_Prefab) as GameObject;
            grassclone.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
            grassclone.transform.position = new Vector3(last_pos.x, big_Grass_Prefab.transform.position.y, 0f);
            grassclone.transform.SetParent(holder.transform);
            GameObject treeClone = Instantiate(tree1,
                new Vector3(grassclone.transform.position.x - 1.6f,tree1.transform.position.y, 0f), tree1.transform.rotation) as GameObject;
            treeClone.transform.SetParent(holder.transform);
        }
        else
        {
            GameObject grassClone2 = Instantiate(grass, last_pos, grass.transform.rotation) as GameObject;
            grassClone2.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
            grassClone2.transform.SetParent(holder.transform);
        }
        last_pos.x += 1.5f;
    }

    void CreateHouse(GameObject house, GameObject ground, GameObject tree, ref Vector3 last_pos, Vector3 current_pos, GameObject holder, int orderInLayer)
    {
        last_pos = current_pos;
        if (orderInLayer % 3 == 0)
        {
            orderInLayer++;
            if (orderInLayer % 2 == 0)
            {
                GameObject clone = Instantiate(house, new Vector3(last_pos.x + .8f, last_pos.y, last_pos.z), house.transform.rotation) as GameObject;
                clone.transform.SetParent(holder.transform);
                clone.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
            }
            else
            {
                GameObject clone = Instantiate(ground, new Vector3(last_pos.x + .8f, last_pos.y, last_pos.z), ground.transform.rotation) as GameObject;
                clone.transform.SetParent(holder.transform);
                clone.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
                GameObject treeclone = Instantiate(tree,
                  new Vector3(clone.transform.position.x - 1.6f, tree.transform.position.y, 0f), tree.transform.rotation) as GameObject;
                treeclone.transform.SetParent(holder.transform);
            }
        }
        last_pos.x += 1.5f;
    }

    void CreateLand(GameObject prefab, ref Vector3 last_pos, Vector3 current_pos, GameObject holder)
    {
        last_pos = current_pos;
        GameObject clone = Instantiate(prefab, last_pos, prefab.transform.rotation) as GameObject;
        clone.transform.SetParent(holder.transform);
        last_pos.x+=1.5f;
    }

    void CreateBigTree(GameObject prefab, ref Vector3 last_pos ,  Vector3 current_pos, GameObject holder)
    {
        last_pos = current_pos;
        GameObject clone = Instantiate(prefab, last_pos, prefab.transform.rotation) as GameObject;
        clone.transform.SetParent (holder.transform);
    }

    //void CreateScene(GameObject bigGrassPrefab, ref GameObject tileClone, int orderInLayer)
    //{
    //    GameObject clone = Instantiate(bigGrassPrefab, tileClone.transform.position, bigGrassPrefab.transform.rotation) as GameObject;
    //    clone.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
    //    clone.transform.SetParent(tileClone.transform);
    //    clone.transform.localPosition = new Vector3(-0.183f, -0.106f, 0f);
    //    CreateTreeOrGround(treePrefab_1, ref clone, new Vector3(0f, 1.52f, 0f));
    //    tileClone.GetComponent<SpriteRenderer>().enabled = false;
    //}

    //void CreateTreeOrGround(GameObject prefab, ref GameObject tileClone, Vector3 local_pos)
    //{
    //    GameObject clone = Instantiate(prefab, tileClone.transform.position, prefab.transform.rotation) as GameObject;
    //    SpriteRenderer tilecloneRenderer = tileClone.GetComponent<SpriteRenderer>();
    //    SpriteRenderer cloneRenderer = clone.GetComponent<SpriteRenderer>();

    //    cloneRenderer.sortingOrder = tilecloneRenderer.sortingOrder;
    //    clone.transform.SetParent(tileClone.transform);
    //    clone.transform.localPosition = local_pos;

    //    if (prefab == groundPrefab_1 || prefab == groundPrefab_2 || prefab == groundPrefab_4)
    //    {
    //        tilecloneRenderer.enabled = false;
    //    }
    //}

    //void CreateGround(ref GameObject clone, ref int orderInLayer)
    //{
    //    for (int i = 0; i < pos_For_Top_Ground_1.Length; i++)
    //    {
    //        if (orderInLayer == pos_For_Top_Ground_1[i])
    //        {
    //            CreateTreeOrGround(groundPrefab_1, ref clone, Vector3.zero);
    //            break;
    //        }
    //    }
    //    for (int i = 0; i < pos_For_Top_Ground_2.Length; i++)
    //    {
    //        if (orderInLayer == pos_For_Top_Ground_2[i])
    //        {
    //            CreateTreeOrGround(groundPrefab_2, ref clone, Vector3.zero);
    //            break;
    //        }
    //    }
    //    for (int i = 0; i < pos_For_Top_Ground_4.Length; i++)
    //    {
    //        if (orderInLayer == pos_For_Top_Ground_4[i])
    //        {
    //            CreateTreeOrGround(groundPrefab_4, ref clone, Vector3.zero);
    //            break;
    //        }
    //    }
    //}

    //void SetNearScene(GameObject bigGrassPrefab, ref GameObject clone, ref int orderInLayer, int[] pos_for_bigGrass
    //    , int[] pos_for_Tree1, int[] pos_for_Tree2, int[] pos_for_Tree3)
    //{
    //    for (int i = 0; i < pos_for_bigGrass.Length; i++)
    //    {
    //        if (orderInLayer == pos_for_bigGrass[i])
    //        {
    //            CreateScene(big_Grass_Prefab, ref clone, orderInLayer);
    //            break;
    //        }
    //    }

    //    for (int i = 0; i < pos_for_Tree1.Length; i++)
    //    {
    //        if (orderInLayer == pos_for_Tree1[i])
    //        {
    //            CreateTreeOrGround(treePrefab_1, ref clone, new Vector3(0f, 1.15f, 0f));
    //            break;
    //        }
    //    }
    //    for (int i = 0; i < pos_for_Tree2.Length; i++)
    //    {
    //        if (orderInLayer == pos_for_Tree2[i])
    //        {
    //            CreateTreeOrGround(treePrefab_2, ref clone, new Vector3(0f, 1.15f, 0f));
    //            break;
    //        }
    //    }
    //    for (int i = 0; i < pos_for_Tree3.Length; i++)
    //    {
    //        if (orderInLayer == pos_for_Tree3[i])
    //        {
    //            CreateTreeOrGround(treePrefab_3, ref clone, new Vector3(0f, 1.15f, 0f));
    //            break;
    //        }
    //    }
    //}
}
