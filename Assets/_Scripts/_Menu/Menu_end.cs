using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Menu_end : MonoBehaviour
{
    // Variable pour les boutons du menu de fin 

    [SerializeField] private TMP_Text textDialogue;

    [SerializeField] private GameObject[] cameraQueen;

    [SerializeField] private Image buttonCam;

    [SerializeField] private float timeBetwwennLetter;

    [SerializeField] private Animator animatorQueen;

    private GameObject buttonTextClicked;

    private GameObject buttonCamClicked;

    private Image spriteButtonCamClicked;

    private Image spriteTextButtonClicked;

    [SerializeField] private Sprite[] buttonVisual;

    private int timeBetweenTalk = 5;

    private bool textDeactived = false;

    private bool camDeactived = false;

    private bool typeText = true;

    private bool firstActivation = true;

    private bool lastActivation = true;

    private float time;
    
    void Start()
    {


        // Initialisation du texte
        textDialogue.text = "Connection ...";
        

        // Verification des fenetre affiché
        if (cameraQueen[0].activeSelf)
        {
            camDeactived = false;
            buttonCam.sprite = buttonVisual[3];
            Debug.Log("yes");
        }
        else
        {
            camDeactived = true;
            buttonCam.sprite = buttonVisual[2];
        }

    }

    
    void Update()
    {
        time += Time.deltaTime;

        // On désactive la fonction pour changer d'écran 
        if (time > 5 && cameraQueen[0].activeSelf && firstActivation)
        {
            firstActivation = false;
            cameraQueen[0].SetActive(false);
            cameraQueen[1].SetActive(true);
            camDeactived = true;
            buttonCam.sprite = buttonVisual[3];

        }

        // Texte qui défile 
        WriteDialogue(timeBetweenTalk, "Screeeeeeeeech");
        WriteDialogue(timeBetweenTalk + 5, " (Traduction du mante religieux : ) ");
        WriteDialogue(timeBetweenTalk + 10 , " Félicitation jeune mante ");
        WriteDialogue(timeBetweenTalk + 20, " Vous avez appris à détruire les autres ");
        WriteDialogue(timeBetweenTalk + 28, "Cependant, nous n'avons pas gagné la guerre");
        WriteDialogue(timeBetweenTalk + 39, "Des espèces autres que nous subsistent");
        WriteDialogue(timeBetweenTalk + 47, " Tenez vous prêt ! ");
        WriteDialogue(timeBetweenTalk + 52, " Le prochain combat est proche");
        WriteDialogue(timeBetweenTalk + 58, "Nous reviendrons vers vous");
        WriteDialogue(timeBetweenTalk + 65, " Fin de transmission");
        

        
        

    }

    // Bouton pour afficher le son
    public void ButtonHideText()
    {   
        // Recupération du bouton son
        buttonTextClicked = EventSystem.current.currentSelectedGameObject;
        spriteTextButtonClicked = buttonTextClicked.GetComponent<Image>();
        
        if (!textDeactived)
        {
            textDialogue.color = new Color(255, 255, 255, 0);
            textDeactived = true;
            spriteTextButtonClicked.sprite = buttonVisual[1];

        }
        else if (textDeactived)
        {
            textDialogue.color = new Color(255, 255, 255, 255);
            textDeactived = false;
            spriteTextButtonClicked.sprite = buttonVisual[0];
        }
    }

    // Bouton pour activer la camera ou non
    public void ButtonShowWindow()
    {
        buttonCamClicked = EventSystem.current.currentSelectedGameObject;
        spriteButtonCamClicked = buttonCamClicked.GetComponent<Image>();


        if (!camDeactived && firstActivation == false && lastActivation)
        {
            cameraQueen[0].SetActive(false);
            cameraQueen[1].SetActive(true);
            camDeactived = true;
            spriteButtonCamClicked.sprite = buttonVisual[3];

        }
        else if (camDeactived)
        {
            cameraQueen[1].SetActive(false);
            cameraQueen[0].SetActive(true);
            camDeactived = false;
            spriteButtonCamClicked.sprite = buttonVisual[2];
        }
    }


    
    // Fonction pour ecriture automatique
    IEnumerator TypeText(string message)
    {
        animatorQueen.SetBool("Talk", true);
        //typeText = false;
        textDialogue.text = " ";
        foreach (char letter in message.ToCharArray())
        {
            textDialogue.text += letter;
            
            yield return 0;
            yield return new WaitForSeconds(timeBetwwennLetter);
        }
        yield return new WaitForSeconds(2);

        textDialogue.text = " ";
        
        typeText = true;
        animatorQueen.SetBool("Talk", false);

    }

    // Fonction pour indiquer quand la mante parle 
    void WriteDialogue (float timeLimit, string message)
    {
        
        if (time >= timeLimit && time <timeLimit + 0.1  && typeText == true )
        { 
            
            typeText = false;
            StartCoroutine(TypeText(message));
            
            
        }
        else { return; }
    }
}
