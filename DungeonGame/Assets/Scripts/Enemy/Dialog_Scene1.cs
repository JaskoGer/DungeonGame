using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_Scene1 : MonoBehaviour
{
    // Start is called before the first frame update
    EarlInteraction act;

    void Start()
    {
        act = new EarlInteraction(setTriggers(), setText());
    }

    // Update is called once per frame
    void Update()
    {
        act.playDialog();
    }

    private Vector3[,] setTriggers()
    {
        Vector3[,] pos = new Vector3[2,2];
        pos[0, 0] = new Vector3(-16, -11, -211);
        pos[0, 1] = new Vector3(4, -10, -197);
        pos[1, 0] = new Vector3();
        pos[1, 1] = new Vector3();
        pos[2, 0] = new Vector3();
        pos[2, 1] = new Vector3();
        pos[3, 0] = new Vector3();
        pos[3, 1] = new Vector3();
        pos[4, 0] = new Vector3();
        pos[4, 1] = new Vector3();
        pos[5, 0] = new Vector3();
        pos[5, 1] = new Vector3();


        return pos;
    }

    private string[,] setText()
    {
        string[,] text = new string[10,2];
        text[0,0] = "Hallo Reisender \n Ich bin Earl! \n Manche würden mich als komischen Exzentriker beschreiben, der eventuell auch fanatische Züge aufweist, aber ich selbst betrachte mich als einen sehr ausgeglichenen und ruhigen Menschen. \nWie heißt du denn?";
        text[0,1] = "Earl";
        text[1,0] = "Randy";
        text[1,1] = "Randy";
        text[2, 0] = "Weißt du Randy, ich bin ja der Meinung, dass alles was man im Leben macht eine direkte Rückmeldung hat. Wenn du also Gutes tust, wird dir auch Gutes widerfahren. Achso Übrigens! \n Weiter hinten gibt, es einen Eingang zu einer Höhle und einem Art Dungeon.Du siehst so aus, als würdest du dort hin wollen? \n Was willst du denn da?";
        text[2, 1] = "Earl";
        text[3, 0] = "Mein Traktor wurde gestohlen.";
        text[3, 1] = "Randy";
        text[4, 0] = "An deiner Stelle würde ich eine Waffe oder etwas Ähnliches mitnehmen. \n Hast du vielleicht eine Heugabel? \n Die wäre perfekt!";
        text[4, 1] = "Earl";
        text[5, 0] = "...";
        text[5, 1] = "Randy";
        

        return text;
    }
}
