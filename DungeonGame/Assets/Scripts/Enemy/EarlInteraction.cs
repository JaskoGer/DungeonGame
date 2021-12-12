using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * @Author Jasko
 * Printed die Earlinteraction
 * Bearbeitet von Tobias
 */
public class EarlInteraction
{
    private Vector3[,] positionTriggers;
    private string[,] dialogText;
    private int j = 0;
    private float maxDistance;

    Transform target = ObjectManager.instance.player.transform;
    private GameObject interaction;

    public EarlInteraction(Vector3[,] newTriggers, string[,] newDialog, GameObject interactionField)
    {
        positionTriggers = newTriggers;
        dialogText = newDialog;
        maxDistance = Vector3.Distance(positionTriggers[0, 0], positionTriggers[0, 1]);
        interaction = interactionField;
    }

    public void PlayDialog()
    {
        if(j < positionTriggers.Length && CheckPosition())
        {
            ObjectManager.instance.canvasMessenger.EarlMeassage(dialogText[j, 1] + ": " + dialogText[j, 0]);
            j++;
            maxDistance = Vector3.Distance(positionTriggers[j, 0], positionTriggers[j, 1]);
        }
    }

    private bool CheckPosition()
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
