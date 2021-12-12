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
        text[0,0] = "Hallo Reisender \n Ich bin Earl! \n Manche w�rden mich als komischen Exzentriker beschreiben, der eventuell auch fanatische Z�ge aufweist, aber ich selbst betrachte mich als einen sehr ausgeglichenen und ruhigen Menschen. \nWie hei�t du denn?";
        text[0,1] = "Earl";
        text[1,0] = "Randy";
        text[1,1] = "Randy";
        text[2, 0] = "Wei�t du Randy, ich bin ja der Meinung, dass alles was man im Leben macht eine direkte R�ckmeldung hat. Wenn du also Gutes tust, wird dir auch Gutes widerfahren. Achso �brigens! \n Weiter hinten gibt, es einen Eingang zu einer H�hle und einem Art Dungeon.Du siehst so aus, als w�rdest du dort hin wollen? \n Was willst du denn da?";
        text[2, 1] = "Earl";
        text[3, 0] = "Mein Traktor wurde gestohlen.";
        text[3, 1] = "Randy";
        text[4, 0] = "An deiner Stelle w�rde ich eine Waffe oder etwas �hnliches mitnehmen. \n Hast du vielleicht eine Heugabel? \n Die w�re perfekt!";
        text[4, 1] = "Earl";
        text[5, 0] = "...";
        text[5, 1] = "Randy";
        

        return text;
    }
}
