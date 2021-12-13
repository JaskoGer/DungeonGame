using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @Author Jonas
 * stellt die Bedingung für den Dialog und den Dialog an sich mit Earl im Outro
 */
public class Dialog_Outro : MonoBehaviour
{
    EarlInteraction act;
    private GameObject interactionField;

    // Start is called before the first frame update
    void Start()
    {
        interactionField = ObjectManager.instance.earlTextField.gameObject;
        act = new EarlInteraction(setTriggers(), setText(), interactionField);
    }

    // Update is called once per frame
    void Update()
    {
        act.PlayDialog();
    }

    private Vector3[,] setTriggers()
    {
        Vector3[,] pos = new Vector3[8,2];
        pos[0,0] = new Vector3(10, 5, -57);
        pos[0,1] = new Vector3(-24, -3, -105);
        pos[1, 0] = new Vector3(-24, -3, -105);
        pos[1, 1] = new Vector3(40, -10, -140);
        pos[2, 0] = new Vector3(40, -10, -140);
        pos[2, 1] = new Vector3(-40, -11, -180);
        pos[3, 0] = new Vector3(-40, -11, -180);
        pos[3, 1] = new Vector3(20, -10, -218);
        pos[4, 0] = new Vector3(20, -10, -218);
        pos[4, 1] = new Vector3(-48, -11, -223);
        pos[5, 0] = new Vector3(-48, -11, -223);
        pos[5, 1] = new Vector3(33, -3, -240);
        pos[6, 0] = new Vector3(33, -3, -240);
        pos[6, 1] = new Vector3(-41, -11, -270);
        pos[7, 0] = new Vector3(-41, -11, -270);
        pos[7, 1] = new Vector3(20, -10, -280);

        return pos;
    }

    private string[,] setText()
    {
        string[,] text = new string[10, 2];
        text[0, 0] = "Boah Randy... \n Das war ein Abenteuer! \n Ist ja aber alles zum Glück gut ausgegangen";
        text[0, 1] = "Earl";
        text[1, 0] = "...";
        text[1, 1] = "Ich";
        text[2, 0] = "Nach unserem Abschied dachte ich, dass ich dich nicht mehr wieder sehen würde...";
        text[2, 1] = "Earl";
        text[3, 0] = "...";
        text[3, 1] = "Ich";
        text[4, 0] = "Ouh! \n Ist das etwa dein Traktor? \n Ich habe es dir ja gesagt. Wenn du Gutes tust, wird dir auch Gutes widerfahren.";
        text[4, 1] = "Earl";
        text[5, 0] = "Ja, das ist mein Traktor";
        text[5, 1] = "Ich";
        text[6, 0] = "Naja dann mein Freund... \n Wir sehen uns beim nächsten Abenteuer!";
        text[6, 1] = "Earl";
        text[7, 0] = "[Grunz...]";
        text[7, 1] = "Ich";  

        return text;
    }
}