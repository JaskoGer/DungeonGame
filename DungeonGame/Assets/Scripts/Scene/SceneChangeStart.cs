using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Tobias
 * Description: Script welches immer beim Laden einer Scene aufgerufen wird
 */

public class SceneChangeStart : MonoBehaviour
{
    private GameObject fadeOutScene;
    private GameObject gameManager;
    private PlayerManager positionManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = ObjectManager.instance.GetGameManager();
        positionManager = gameManager.GetComponent<PlayerManager>();
        ObjectManager.instance.player.transform.position = new Vector3(positionManager.startPointx, positionManager.startPointy, positionManager.startPointz);
        ObjectManager.instance.camRotator.transform.rotation = positionManager.startRotation;
        ObjectManager.instance.playerCharacter.transform.rotation = positionManager.startRotation;
        fadeOutScene = ObjectManager.instance.fadeOutScene.gameObject;
        fadeOutScene.SetActive(false);
    }
}
