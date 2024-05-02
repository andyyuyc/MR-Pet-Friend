using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerZone : MonoBehaviour
{

    public GameObject Player;
    public GameObject LocomotionSystem;
    public GameObject UIInteractor;
    public GameObject endPosition;
    public GameObject startPosition;
    public GameObject startRoom;
    public ObjectCounter objectCounter;
    public Ts textSetter;
    public Ts gN1;
    public Ts gN2;
    public string winText = "You Win!";
    public string loseText = "You Lose!";
    public string gameName = "Your Game Name";
    public static BoolManager boolManager;
    private XRRig playerRig;



    private void Start()
    {
        if (boolManager.isStartup)
        {
            Player.transform.position = new Vector3(startRoom.transform.position.x, startRoom.transform.position.y, startRoom.transform.position.z);
            Player.transform.rotation = Quaternion.Euler(0, 180, 0);
            LocomotionSystem.SetActive(false);
            UIInteractor.SetActive(true);

        }

        else
        {
            Player.transform.position = new Vector3(startPosition.transform.position.x, startPosition.transform.position.y, startPosition.transform.position.z);
            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 0.481327f, Player.transform.position.z);
        }

        playerRig = Player.GetComponent<XRRig>();

        gN1.SetText(gameName);
        gN2.SetText(gameName);
    }



    void FixedUpdate()
    {
        //Debug.Log(Player.transform.position);

        if (objectCounter.GetCount() == objectCounter.GetNeededToWin())
        {
            Win();
        }

        playerRig.cameraYOffset.Equals(0);
        playerRig.cameraYOffset.Equals(.75);
    }

    public BoolManager GetBoolManager()
    {
        return boolManager;
    }

    public void SetBoolManager(BoolManager bM)
    {
        boolManager = bM;
    }
    
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.transform.CompareTag("Creature"))
        {
            Lose();
        }
    }

    void GameOver()
    {
        Player.transform.position = endPosition.transform.position;
        Player.transform.rotation = Quaternion.Euler(0, 180, 0);
        LocomotionSystem.SetActive(false);
        UIInteractor.SetActive(true);
    }

    void Win()
    {
        GameOver();
        textSetter.SetText(winText);
    }
    
    void Lose()
    {
        GameOver();
        textSetter.SetText(loseText);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        boolManager.isStartup = false;
    }


    void SetLose()
    {
        //SceneManager.LoadScene("PrototypeScene");
    }
}
