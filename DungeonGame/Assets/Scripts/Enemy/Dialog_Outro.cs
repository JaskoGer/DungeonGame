using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_Outro : MonoBehaviour
{
    EarlInteraction act;

    // Start is called before the first frame update
    void Start()
    {
        act = new EarlInteraction(setTriggers(), setText());
    }

    // Update is called once per frame
    void Update()
    {
        act.checkPosition();
    }

    private Vector3[] setTriggers()
    {
        Vector3[] pos = new Vector3[2];
        pos[0] = new Vector3(18, -10, -145);
        pos[1] = new Vector3(30, 5, 10);

        return pos;
    }

    private string[,] setText()
    {
        string[,] text = new string[10, 2];
        text[0, 0] = "Boah Randy... \n Das war ein Abenteuer! \n Ist ja aber alles zum Glück gut ausgegangen";
        text[0, 1] = "Earl";
        text[1, 0] = "...";
        text[1, 1] = "Randy";
        text[2, 0] = "Nach unserem Abschied dachte ich, dass ich dich nicht mehr wieder sehen würde...";
        text[2, 1] = "Earl";
        text[3, 0] = "...";
        text[3, 1] = "Randy";
        text[4, 0] = "Ouh! \n Ist das etwa dein Traktor? \n Ich habe es dir ja gesagt. Wenn du Gutes tust, wird dir auch Gutes widerfahren.";
        text[4, 1] = "Earl";
        text[5, 0] = "Ja, das ist mein Traktor";
        text[5, 1] = "Randy";
        text[6, 0] = "Naja dann mein Freund... \n Wir sehen uns beim nächsten Abenteuer!";
        text[6, 1] = "Earl";
        text[7, 0] = "[Grunz...]";
        text[7, 1] = "Randy";


        return text;
    }
}