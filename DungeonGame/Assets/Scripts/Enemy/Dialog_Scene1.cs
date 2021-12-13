using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @Author Jasko
 * Texte von Jonas
 * stellt die Bedingung für den Dialog und den Dialog an sich mit Earl in Scene001
 */
public class Dialog_Scene1 : MonoBehaviour
{
    EarlInteraction act;
    private GameObject interactionField;

    
    void Start()
    {
        interactionField = ObjectManager.instance.earlTextField.gameObject;
        act = new EarlInteraction(getTriggers(), getText(), interactionField);
    }

    
    void Update()
    {
        act.PlayDialog();
    }


    /**
    * @Author Jasko
    * gibt die Bereiche zurueck, wo die Texte ausgedruckt werden sollen
    */
    private Vector3[,] getTriggers()
    {
        Vector3[,] pos = new Vector3[6,2];
        pos[0, 0] = new Vector3(-16, -11, -211);
        pos[0, 1] = new Vector3(4, -10, -197);
        pos[1, 0] = new Vector3(-12,-11,-173);
        pos[1, 1] = new Vector3(17,-12,-166);
        pos[2, 0] = new Vector3(-14, -8, -144);
        pos[2, 1] = new Vector3(40, -10, -138);
        pos[3, 0] = new Vector3(-31,-115);
        pos[3, 1] = new Vector3(21,-9, -104);
        pos[4, 0] = new Vector3(-8, 0, -67);
        pos[4, 1] = new Vector3(3,-2,-60);
        pos[5, 0] = new Vector3(32,43,54);
        pos[5, 1] = new Vector3(32,12,32);

        return pos;
    }


    /**
    * @Author Jasko
    * gibt den Auszudruckenden Text und die Person die es sagt zurueck
    */
    private string[,] getText()
    {
        string[,] text = new string[10,2];
        text[0,0] = "Hallo Reisender \n Ich bin Earl! \n Manche würden mich als komischen Exzentriker beschreiben, der eventuell auch fanatische Züge aufweist, aber ich selbst betrachte mich als einen sehr ausgeglichenen und ruhigen Menschen. \nWie heißt du denn?";
        text[0,1] = "Earl";
        text[1,0] = "Randy";
        text[1,1] = "Ich";
        text[2, 0] = "Weißt du Randy, ich bin ja der Meinung, dass alles was man im Leben macht eine direkte Rückmeldung hat. Wenn du also Gutes tust, wird dir auch Gutes widerfahren. Achso Übrigens! \n Weiter hinten gibt, es einen Eingang zu einer Höhle und einem Art Dungeon.Du siehst so aus, als würdest du dort hin wollen? \n Was willst du denn da?";
        text[2, 1] = "Earl";
        text[3, 0] = "Mein Traktor wurde gestohlen.";
        text[3, 1] = "Ich";
        text[4, 0] = "An deiner Stelle würde ich eine Waffe oder etwas Ähnliches mitnehmen. \n Hast du vielleicht eine Heugabel? \n Die wäre perfekt!";
        text[4, 1] = "Earl";
        text[5, 0] = "...";
        text[5, 1] = "Ich";
       
        return text;
    }
}
