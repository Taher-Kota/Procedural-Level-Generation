using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class offsetingTiles : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (!GeometryUtility.TestPlanesAABB(planes, spriteRenderer.bounds))
        {
            if ((transform.position.x - Camera.main.transform.position.x) <= 0f)
            {
                CheckTile();
            }
        }
    }

    void CheckTile()
    {
        if (this.tag == MyTags.ROAD)
        {
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Road_Tile, 1.5f,
                ref MapGenerator.instance.last_Order_Of_Road);
        }
        else if (this.tag == MyTags.TOP_FAR_GRASS)
        {
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Top_Far_Grass, 1.5f,
                ref MapGenerator.instance.last_Order_Of_Road);
        }
        else if (this.tag == MyTags.Top_Far_Tree)
        {
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Top_Far_Grass,1.5f,
                ref MapGenerator.instance.last_Order_Of_Road);
        }
        else if(this.tag == MyTags.BOTTOM_NEAR_GRASS)
        {
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Top_Near_Grass, 1.5f,
                ref MapGenerator.instance.last_Order_Of_Road);
        }
        else if(this.tag == MyTags.BOTTOM_FAR_LAND_1)
        {
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Botom_Far_Land_F1, 1.5f,
                ref MapGenerator.instance.last_Order_Of_Road);
        }
        else if (this.tag == MyTags.BOTTOM_FAR_LAND_2)
        {
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Botom_Far_Land_F2, 1.5f,
                ref MapGenerator.instance.last_Order_Of_Road);
        }
        else if (this.tag == MyTags.BOTTOM_FAR_LAND_3)
        {
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Botom_Far_Land_F3, 1.5f,
                ref MapGenerator.instance.last_Order_Of_Road);
        }
        else if (this.tag == MyTags.BOTTOM_FAR_LAND_4)
        {
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Botom_Far_Land_F4, 1.5f,
                ref MapGenerator.instance.last_Order_Of_Road);
        }
        else if (this.tag == MyTags.BOTTOM_FAR_LAND_5)
        {
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Botom_Far_Land_F5, 1.5f,
                ref MapGenerator.instance.last_Order_Of_Road);
        }
        else if(this.tag == MyTags.Big_Tree)
        {
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Far_Tree, 35f,
                ref MapGenerator.instance.last_Order_Of_Road);
        }
        else if(this.tag == MyTags.TopFarHouse)
        {
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Far_House,4.9f,
                ref MapGenerator.instance.last_Order_Of_Road);
        }
        else if(this.tag == MyTags.Small_Tree)
        {
            ChangePos(ref MapGenerator.instance.last_Pos_Of_Far_House, 0f,
                ref MapGenerator.instance.last_Order_Of_Road);
        }

    }

    void ChangePos(ref Vector3 lastpos, float offset,ref int orderInLayer)
    {   if (this.tag == MyTags.Top_Far_Tree)
        {
            orderInLayer++;
            transform.position = new Vector3(lastpos.x,4.9f,0f);
            lastpos.x += offset;
            spriteRenderer.sortingOrder = orderInLayer;
        }
        else if (this.tag == MyTags.Small_Tree)
        {
            transform.position = new Vector3(lastpos.x-1.3f, this.gameObject.transform.position.y, 0f);
        }
        else
        {
            orderInLayer++;
            transform.position = lastpos;
            lastpos.x += offset;
            spriteRenderer.sortingOrder = orderInLayer;
        }
               
    }
}
