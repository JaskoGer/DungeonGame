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
        text[0, 0] = "Text1";
        text[0, 1] = "Earl";
        text[1, 0] = "Text2";
        text[1, 1] = "Randy";
        

        return text;
    }
}
