using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 * @Author Tobias
 * Ort um auf die wichtigsten Objekte zuzugreifen
 */
public class ObjectManager : MonoBehaviour
{

    #region Singleton

    public static ObjectManager instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	#endregion

	public GameObject playerCharacter;
    public Transform player;
    public Transform mainCam;
    public Transform camRotator;
	public Transform earl;
    public GameObject fadeOutScene;
	public Text errorTextField;
    public GameObject inventory;
	public GameObject crossBow;
    public GameObject pitchFork;
	public GameObject metalFork;
	public GameObject pickUpFx;
	public GameObject armor;
    public GameObject GetGameManager()
    {
		return GameObject.Find("GameManager");
    }

    public void ErrorMessage(string pM)
    {
		StartCoroutine(ErrorMessageUI(pM));
    }

	/**
	* @Author Tobias
	* setzt einen error
	*/
	IEnumerator ErrorMessageUI(string pM)
	{
		errorTextField.text = pM;
		errorTextField.enabled = true;
		yield return new WaitForSeconds(4f);
		errorTextField.enabled = false;
	}
}
