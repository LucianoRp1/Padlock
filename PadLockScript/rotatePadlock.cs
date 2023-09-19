using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

public class rotatePadlock : MonoBehaviour
{
    public static event System.Action<string, int> Rotate = delegate { };

    public static List<GameObject> rullers = new List<GameObject>();
    private bool isMouseOver = false;
    private int number;
    private float positionRuller = 36;
    public static rotatePadlock instance;

    private void Awake()
    {
        rullers.Add(GameObject.Find("Ruller1"));
        rullers.Add(GameObject.Find("Ruller2"));
        rullers.Add(GameObject.Find("Ruller3"));
        rullers.Add(GameObject.Find("Ruller4"));
        number = 0;
        instance= this;


    }

    public void Update()
    {
        if (isMouseOver && Input.GetMouseButtonDown(0))
        {
            RotateRuller();
            number += 1;
            Debug.Log( "click  " + number);
            if (number > 9)
            {
                number = 0;
                Debug.Log("supero el numero de click con   " + number);
            }
            Rotate(name, number);
        }
    }

    public void RotateRuller()
    {

transform.Rotate( 0 - positionRuller, 0, 0);
        
            

    }


    public void OnMouseEnter()
    {
        GameObject hoveredRuller = rullers.Find(ruller => ruller.name == gameObject.name);

        if (hoveredRuller != null)
        {
            var renderer = hoveredRuller.GetComponent<MeshRenderer>();
            renderer.material.color = Color.red;
            isMouseOver = true;
        }
    }

    private void OnMouseExit()
    {
        GameObject hoveredRuller = rullers.Find(ruller => ruller.name == gameObject.name);

        if (hoveredRuller != null)
        {
            var renderer = hoveredRuller.GetComponent<MeshRenderer>();
            renderer.material.color = Color.white;
            isMouseOver = false;
        }
    }




}


