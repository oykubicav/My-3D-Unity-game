using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIHandler : MonoBehaviour
{ private Transform player;
    public Button goOutButton;
    public Button stayInButton;
    public doorcontrol doorControl;
    public bool buttonclicked=false;
    public float interactionDistance = 6.0f;
public Transform door;
    

    private bool doorIsOpening = false; // Flag to prevent multiple door animations

 private void Start()
    {
        // Find the player GameObject based on its tag
         player = GameObject.FindGameObjectWithTag("Player").transform; 
        door = GameObject.FindGameObjectWithTag("door").transform; 


         goOutButton.gameObject.SetActive(true);
        stayInButton.gameObject.SetActive(true);
    }
    
 private void Update()
    {
        // Calculate the distance between the player and the door
        float distanceToDoor = Vector3.Distance(player.position, door.position);

        // Check if the player is within interaction distance
        if (distanceToDoor > interactionDistance)
        {buttonclicked=false;}}
        
    public void GoOutButtonClicked()

    {   buttonclicked=true;
        goOutButton.gameObject.SetActive(false);
        stayInButton.gameObject.SetActive(false);
        if (!doorIsOpening)
        {
            StartCoroutine(OpenDoorAndLoadNextLevel());
        }
    }

    private IEnumerator OpenDoorAndLoadNextLevel()
    {
        doorIsOpening = true;

        // Start the door opening animation
        yield return StartCoroutine(doorControl.OpenDoor());

        // Load the next level after the animation is complete
        doorControl.LoadNextLevel();

        doorIsOpening = false;
    }

    public void StayInButtonClicked()

    {    buttonclicked=true;
        goOutButton.gameObject.SetActive(false);
        stayInButton.gameObject.SetActive(false);
        

    }
}
