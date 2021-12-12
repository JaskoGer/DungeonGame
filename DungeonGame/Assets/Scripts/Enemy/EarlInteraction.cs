using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarlInteraction : MonoBehaviour
{
    private Vector3[,] positionTriggers;
    private string[,] dialogText;
    private int j = 0;
    private float maxDistance;

    Transform target = ObjectManager.instance.player.transform;

    public EarlInteraction(Vector3[,] newTriggers, string[,] newDialog)
    {
        positionTriggers = newTriggers;
        dialogText = newDialog;
        maxDistance = Vector3.Distance(positionTriggers[0, 0], positionTriggers[0, 1]);
    }

    public void playDialog()
    {
        if(j < positionTriggers.Length && checkPosition())
        {
            print(dialogText[j, 1] + " sagt: " + dialogText[j, 0]);
            j++;
            maxDistance = Vector3.Distance(positionTriggers[j, 0], positionTriggers[j, 1]);
        }
    }

    private bool checkPosition()
    {
        if (maxDistance >= Vector3.Distance(positionTriggers[j, 0], target.position) && maxDistance >= Vector3.Distance(positionTriggers[j, 1], target.position))
        {
            return true;
        }
        else
        {
            return false;
        }

        
     }
}
