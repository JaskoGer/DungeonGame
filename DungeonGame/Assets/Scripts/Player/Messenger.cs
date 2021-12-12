using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messenger : MonoBehaviour
{
	public Text errorTextField;
	public GameObject earlTextField;

	public void ErrorMessage(string pM)
	{
		errorTextField = ObjectManager.instance.errorTextField;
		StartCoroutine(ErrorMessageUI(pM));
	}

	/**
	* @Author Tobias
	* setzt einen error
	*/
	IEnumerator ErrorMessageUI(string pM)
	{
		errorTextField.text = pM;
		errorTextField.gameObject.SetActive(true);
		yield return new WaitForSeconds(4f);
		errorTextField.gameObject.SetActive(false);
	}

	public void EarlMeassage(string pM)
	{
		earlTextField = ObjectManager.instance.earlTextField;
		StartCoroutine(EarlMessage(pM));
	}

	/**
	* @Author Tobias
	* setzt einen Earl
	*/
	IEnumerator EarlMessage(string pM)
	{
		earlTextField.GetComponentInChildren<Text>().text = pM;
		earlTextField.gameObject.SetActive(true);
		float timer = pM.Length / 40f + 2f;
		yield return new WaitForSeconds(timer);
		earlTextField.gameObject.SetActive(false);
	}
}
