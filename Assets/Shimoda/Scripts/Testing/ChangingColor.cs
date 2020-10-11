using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingColor : MonoBehaviour
{
    public Material[] materialList;
    private bool activeMaterial = false;
    public void ChangeColor(){
        Debug.Log("test");
        if(activeMaterial){
            activeMaterial = false;
            this.GetComponent<Renderer>().material = materialList[0];
        } else {
            activeMaterial = true;
            this.GetComponent<Renderer>().material = materialList[1];

        }
    }
}
