using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{

    public Material playerUnlit;
    public Material playerMiddle;
    public Material playerLit;
    public Material swordUnlit;
    public Material swordLit;

    public void changePlayerColor()
    {
        GetComponent<MeshRenderer>().material = playerUnlit;
        GameObject.Find("sword").GetComponent<MeshRenderer>().material = swordUnlit;
    }

    public void changePlayerColorBack()
    {
        GetComponent<MeshRenderer>().material = playerLit;
        GameObject.Find("sword").GetComponent<MeshRenderer>().material = swordLit;
    }

    public void changePlayerColorMiddle()
    {
        GetComponent<MeshRenderer>().material = playerLit;
        GetComponent<MeshRenderer>().material = playerMiddle;
    }
}