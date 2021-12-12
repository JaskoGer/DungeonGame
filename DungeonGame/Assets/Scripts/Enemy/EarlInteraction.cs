using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarlInteraction : MonoBehaviour
{
    private Vector3[] positionTriggers;
    private string[,] dialogText;
    private int j = 0;

    Transform target = ObjectManager.instance.player.transform;

    public EarlInteraction(Vector3[] newTriggers, string[,] newDialog)
    {
        positionTriggers = newTriggers;
        dialogText = newDialog;
    }

    public void checkPosition()
    {
        if(j < positionTriggers.Length && Vector3.Distance(target.position, positionTriggers[j]) <= 3f)
        {
            print(dialogText[j, 1] + " sagt: " + dialogText[j, 0]);
            j++;
        }
    }
}
