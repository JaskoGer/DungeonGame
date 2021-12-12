using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_Scene2 : MonoBehaviour
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
        act.PlayDialog();
    }

    private Vector3[,] setTriggers()
    {
        Vector3[,] pos = new Vector3[2, 2];
        pos[0, 0] = new Vector3(-16, -11, -211);
        pos[0, 1] = new Vector3(4, -10, -197);
        pos[1, 0] = new Vector3();
        pos[1, 1] = new Vector3();
        pos[1, 0] = new Vector3();
        pos[1, 1] = new Vector3();
        pos[1, 0] = new Vector3();
        pos[1, 1] = new Vector3();

        return pos;
    }

    private string[,] setText()
    {
        string[,] text = new string[10, 2];
        text[0, 0] = "Hallo Randy, hier drüben bin ich! Ich hätte mich hier nicht einfach reingetraut, aber das muss jeder selbst mit sich vereinbaren.";
        text[0, 1] = "Earl";
        text[1, 0] = "...";
        text[1, 1] = "Randy";
        text[2, 0] = "Jetzt sind wir in dem Dungeon von dem ich gesprochen habe... \n Hier laufen ziemlich viele komische Monster rum. Die sehen aus wie kleine Schleimkugeln. \n Aber lass dich nicht täuschen! \n Wenn du ihnen zu nahe kommst, rennen sie dir hinterher und greifen dich an. \n Irgendwo hier, habe ich auch meinen Ring verloren.Ich weiß aber leider nicht mehr genau wo. \n Tut mir leid!";
        text[2, 1] = "Earl";
        text[3, 0] = "...";
        text[3, 1] = "Randy";
        text[4, 0] = "Angeblich soll es hier auch einen riesigen Schleim geben. \n Vor dem solltest du dich in Acht nehmen. \n An dem ist sogar Olaf E. gescheitert und der hatte sonst vor nichts und niemandem Angst. Du scheinst heute ein bisschen wortkarg zu sein. \n Naja egal, nichts wie los!";
        text[4, 1] = "Earl";
        text[5, 0] = "Mir fällt gerade eine Möglichkeit ein, wie du dir gutes Karma verdienen könntest. Ich habe vor ein paar Tagen, als ich die Höhle erkundet habe, meinen Ring verloren. \n Seitdem habe ich das Gefühl, dass meine spirituellen Energien etwas gehemmt sind. \n Kannst du mir helfen den Ring wiederzubekommen?";
        text[5, 1] = "Earl";
        text[6, 0] = "...";
        text[6, 1] = "Randy";

        return text;
    }
}
