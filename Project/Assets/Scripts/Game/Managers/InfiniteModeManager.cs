using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteModeManager : MonoBehaviour
{
    GameObject parametersGameObject;
    void Start()
    {
        if (GameObject.Find("Parameters") != null)
        {
            parametersGameObject = GameObject.Find("Parameters");
        }
        else
        {
            Debug.LogError("No 'Parameters' game object found.");
            return;
        }
    }

    public void GiveParametersToLevelClass()
    {
        Transform parameterTransform = parametersGameObject.transform;
        Level.Level_Number = 0;

        for (int i = 0; i < parameterTransform.childCount; i++)
        {
            switch (i)
            {
                case 0:
                    Level.Tessitura = (int) parameterTransform.GetChild(i).GetComponentInChildren<Slider>().value;
                    break;
                case 1:
                    Level.Max_Interval = (int) parameterTransform.GetChild(i).GetComponentInChildren<Slider>().value;
                    break;
                case 2:
                    Level.Speed = parameterTransform.GetChild(i).GetComponentInChildren<Slider>().value;
                    break;
                case 3:
                    Level.Time_Before_Next_Note = parameterTransform.GetChild(i).GetComponentInChildren<Slider>().value;
                    break;
            }
        }

        GameManager.infiniteMode = true;

        Manager.LoadInfiniteMode();
    }
}
