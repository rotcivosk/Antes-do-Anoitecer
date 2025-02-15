using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

public class ResourcesHandler : MonoBehaviour
{
    private int food = 3;
    private int maxFood = 10;

    void Start()
    {

    }



    public int getFoodValue(){
        return food;
    }

    public void updateFood(int changedValue){
        if (food > 0 || food<maxFood){    
            food = food + changedValue;
        }
    }






    
}
