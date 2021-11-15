using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugController : MonoBehaviour
{
    public Text MyText;
    private GameObject DevCanvas;
    private GameObject InputField;
/*@Author Laurin
 *Script für den Debug mode
 *
 */

    // Start is called before the first frame update
    void Start()
    {
        DevCanvas = GameObject.Find("DevCanvas");
        DevCanvas.gameObject.SetActive(false);
        InputField = GameObject.Find("DevChat");
        InputField.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            InputField.gameObject.SetActive(true);
        }
    }

    public void SendButton()
    {
        bool Temp;
        Temp = TextCheck(MyText);
        if(Temp == true)
        {
            print("You're now a Developer");
            DevCanvas.gameObject.SetActive(true);
        }
        else
        {
            print("MÖNKE RULEZ");
        }

        InputField.gameObject.SetActive(false);

    }

    public bool TextCheck(Text TheText)
    {
        if(TheText.text == "YUPIMADEV")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
