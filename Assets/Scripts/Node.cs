using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hovercolor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;


    [Header("Optional")]
    public GameObject turret;

    

    private Renderer rend;
    private Color startcolor;

    BuildManager buildManager;

     void Start()
    {
      rend = GetComponent<Renderer>(); 
        startcolor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;



        if(turret != null)
        {
            Debug.Log("Cant Build");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hovercolor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

       
    }

    void OnMouseExit()
    {
        rend.material.color = startcolor;
    }
}
