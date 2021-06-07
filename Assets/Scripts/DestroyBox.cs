using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                int splitPos = hit.collider.gameObject.name.IndexOf("(");
                string Colorname = hit.collider.gameObject.name.Substring(0, splitPos);
                Debug.Log("Color: " + Colorname);
                DestroyObj(hit.collider.gameObject, Colorname);
            }
        }
    }

    private void DestroyObj(GameObject obj, string color)
    {
        List<GameObject> BoxList = obj.GetComponent<Box>().neighbourList;
        if (obj.name.Contains(color))
        {
            Destroy(obj);
        }
        for (int i =0; i < BoxList.Count; i++)
        {
            try
            {
                if (BoxList[i].name.Contains(color))
                {
                    Destroy(BoxList[i]);
                }
            }
            catch (System.Exception e) { }
        }
        
    }

    
}
