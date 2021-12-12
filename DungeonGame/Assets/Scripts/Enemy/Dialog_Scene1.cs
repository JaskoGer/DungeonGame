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
        string[,] text = new string[10,2];
        text[0,0] = "Hallo Reisender \n Ich bin Earl! \n Manche w�rden mich als komischen Exzentriker beschreiben, der eventuell auch fanatische Z�ge aufweist, aber ich selbst betrachte mich als einen sehr ausgeglichenen und ruhigen Menschen. \nWie hei�t du denn?";
        text[0,1] = "Earl";
        text[1,0] = "Randy";
        text[1,1] = "Randy";
        text[2, 0] = "Wei�t du Randy, ich bin ja der Meinung, dass alles was man im Leben macht eine direkte R�ckmeldung hat. Wenn du also Gutes tust, wird dir auch Gutes widerfahren. Achso �brigens! \n Weiter hinten gibt, es einen Eingang zu einer H�hle und einem Art Dungeon.Du siehst so aus, als w�rdest du dort hin wollen? \n Was willst du denn da?";
        text[2, 1] = "Earl";
        text[3, 0] = "Mein Traktor wurde gestohlen.";
        text[3, 1] = "Randy";
        text[4, 0] = "Hmm, also ich pers�nlich w�rde mich da nicht reintrauen, aber das muss jeder selbst mit sich vereinbaren. Wenn du damit im Reinen bist, ist das okay. \n Ich pers�nlich kann dir nur empfehlen eine Waffe oder �hnliches mitzunehmen. Hast du vielleicht eine Heugabel? \n Die w�re perfekt!";
        text[4, 1] = "Earl";
        text[5, 0] = "...";
        text[5, 1] = "Randy";
        text[6, 0] = "Mir f�llt gerade eine M�glichkeit ein, wie du dir gutes Karma verdienen k�nntest. Ich habe vor ein paar Tagen, als ich die H�hle erkundet habe, meinen Ring verloren. \n Seitdem habe ich das Gef�hl, dass meine spirituellen Energien etwas gehemmt sind.Kannst du mir helfen den Ring wiederzubekommen? \n Und wenn wir schon drin sind, kannst du ja gleich nach deinem Traktor suchen. Win - Win f�r beide Personen.Vielleicht bekomme ich dann auch etwas positives Karma...";
        text[6, 1] = "Earl";
        text[7, 0] = "...";
        text[7, 1] = "Randy";

        return text;
    }
}
