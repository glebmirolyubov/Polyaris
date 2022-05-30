using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRaycast : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.CompareTag("Padlock"))
                {
                    //Debug.Log("Touched padlock!");
                }

                //Debug.Log(hit.transform.gameObject.name);
            }
        }
    }
}
