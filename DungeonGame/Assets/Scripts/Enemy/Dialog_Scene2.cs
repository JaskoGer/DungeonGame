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
        text[0, 0] = "Hallo Randy, hier dr�ben bin ich!";
        text[0, 1] = "Earl";
        text[1, 0] = "...";
        text[1, 1] = "Randy";
        text[2, 0] = "Jetzt sind wir in dem Dungeon von dem ich gesprochen habe... \n Hier laufen ziemlich viele komische Monster rum.Die sehen aus wie kleine Schleimkugeln. \n Aber lass dich nicht t�uschen! \n Wenn du ihnen zu nahe kommst, rennen sie dir hinterher und greifen dich an. \n Irgendwo hier, habe ich auch meinen Ring verloren.Ich wei� aber leider nicht mehr genau wo. \n Tut mir leid!";
        text[2, 1] = "Earl";
        text[3, 0] = "...";
        text[3, 1] = "Randy";
        text[4, 0] = "Angeblich soll es hier auch einen riesigen Schleim geben. \n Vor dem solltest du dich in Acht nehmen. \n An dem ist sogar Olaf E. gescheitert und der hatte sonst vor nichts und niemandem Angst. Du scheinst heute ein bisschen wortkarg zu sein. \n Naja egal, nichts wie los!";
        text[4, 1] = "Earl";

        return text;
    }
}