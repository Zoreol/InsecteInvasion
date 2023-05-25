using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutoriel : MonoBehaviour
{
    public bool _cameraMouvment = false;        // 1
    public bool _zoom = false;                  // 2
    public bool _unitCreation = false;          // 3
    public bool _selectUnit = false;            // 4
    public bool _moveUnit = false;              // 11
    public bool _recolteBuilding = false;       // 21   a faire
    public bool _equipeManteRecolte = false;    // 31   a faire
    public bool _recolterPucerons = false;      // 41   a faire
    public bool _createFiveUnit = false;        // 122
    public bool _gendarmeDiscover = false;      // 222  a faire
    public bool _gendarmeKill = false;          // 322  a faire
    public bool _gendarmeTownCapture = false;   // 422
    public bool _tankBuilding = false;          // 1333 a faire
    public bool _manteTank = false;             // 2333 a faire
    public bool _spiderCapture = false;         
    public bool _coleoptereCapture = false;     

    [SerializeField] private TMP_Text _panelTuto_1;
    [SerializeField] private TMP_Text _panelTuto_2;
    [SerializeField] private TMP_Text _panelTuto_3;
    [SerializeField] private TMP_Text _panelTuto_4;

    [SerializeField] private TMP_Text[] _manteTalking;

    [SerializeField] private GameObject[] _manteDialogues;

    [SerializeField] private float timer = 1;
    [SerializeField] private int securityPanel1 = 0;
    [SerializeField] private int securityPanel2 = 0;
    [SerializeField] private int securityPanel3 = 0;
    [SerializeField] private int securityPanel4 = 0;
    [SerializeField] private int securityDialogues = 0;

    public int dialogueNumtest = 0;
    // Start is called before the first frame update
    void Start()
    {
        _panelTuto_1.text = "D�placez la cam�ra avec les fl�ches directionnelles.";
        _panelTuto_2.text = "A l'aide de la molette et de votre souris, zoomer et d�zoomer.";
        _panelTuto_3.text = "Cr�ez une mante gr�ce � votre tribu.";
        _panelTuto_4.text = "maintenir clic gauche pour former un rectangle de s�lection afin de s�lectionner des mantes.";

        FirstsTextsMante();
        _manteDialogues[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        ActivateDialogue();
        Panel_Info();

    }
    void Panel_Info()
    {
        Panel_1_Following();
        Panel_2_Following();
        Panel_3_Following();
        Panel_4_Following();
    }
    void Panel_1_Following()
    {
        if (_unitCreation && securityPanel1 == 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                _panelTuto_1.text = "Clic droit pour d�placer toutes les unit�s s�lectionn�es.";
                securityPanel1 = 1;
                timer = 1;
            }
        }
        if (_equipeManteRecolte && securityPanel1 == 1)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _panelTuto_1.text = "Cr�er 5 unit�s de mante.";
                securityPanel1 = 2;
                timer = 1;
            }
        }
        if (_gendarmeKill && securityPanel1 == 2)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _panelTuto_1.text = "Construire la caserne des gendarmes dans la colonie alli�e.";
                securityPanel1 = 3;
                timer = 1;
            }
        }
    }
    void Panel_2_Following()
    {
        if (_selectUnit && securityPanel2 == 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _panelTuto_2.text = "Depuis le village, construire une Puceronni�re en cliquand sur l'ic�ne du marteau.";
                securityPanel2 = 1;
                timer = 1;
            }
        }
        if (_recolterPucerons && securityPanel2 == 1)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _panelTuto_2.text = "D�placer au moins une mante vers le sud-ouest.";
                securityPanel2 = 2;
                timer = 1;
            }
        }
        if (_gendarmeTownCapture && securityPanel2 == 2)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _panelTuto_2.text = "Supprimer une mante et en �quiper une avec une armure de gendarme.";
                securityPanel2 = 3;
                timer = 1;
            }
        }
    }
    void Panel_3_Following()
    {
        if (_moveUnit && securityPanel3 == 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _panelTuto_3.text = "S�lectionner une mante et faire un clic droit sur le b�timent pour �quiper la mante.";
                securityPanel3 = 1;
                timer = 1;
            }
        }
        if (_createFiveUnit && securityPanel3 == 1)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _panelTuto_3.text = "Tuer 1 gendarme.";
                securityPanel3 = 2;
                timer = 1;
            }
        }
    }
    void Panel_4_Following()
    {
        if (_recolteBuilding && securityPanel4 == 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _panelTuto_4.text = "Allez r�colter des pucerons pour r�aprovisionner le campement.";
                securityPanel4 = 1;
                timer = 1;
            }
        }
        if (_gendarmeDiscover && securityPanel4 == 1)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _panelTuto_4.text = "Capturer la tribu des gendarmes en positionnant au moins une mante � l'int�rieur de celui-ci en attendant sa prise.";
                securityPanel4 = 2;
                timer = 1;
            }
        }
    }
    void ActivateDialogue()
    {
        if (_cameraMouvment && _zoom && securityDialogues == 0)
        {
            _manteDialogues[1].SetActive(true);
            securityDialogues++;
        }
        if (_unitCreation && securityDialogues == 1)
        {
            _manteDialogues[2].SetActive(true);
            securityDialogues++;
        }
        if (_selectUnit && _moveUnit && securityDialogues == 2)
        {
            _manteDialogues[3].SetActive(true);
            securityDialogues++;
        }
        if (_recolteBuilding && securityDialogues == 3)
        {
            _manteDialogues[4].SetActive(true);
            securityDialogues++;
        }
        if (_equipeManteRecolte && securityDialogues == 4)
        {
            _manteDialogues[5].SetActive(true);
            securityDialogues++;
        }
        if (_recolterPucerons && securityDialogues == 5)
        {
            _manteDialogues[6].SetActive(true);
            securityDialogues++;
        }
        if (_createFiveUnit && securityDialogues == 6)
        {
            _manteDialogues[7].SetActive(true);
            securityDialogues++;
        }
        if (_gendarmeDiscover && securityDialogues == 7)
        {
            _manteDialogues[8].SetActive(true);
            securityDialogues++;
        }
        if (_gendarmeKill && securityDialogues == 8)
        {
            _manteDialogues[9].SetActive(true);
            securityDialogues++;
        }
        if (_gendarmeTownCapture && securityDialogues == 9)
        {
            _manteDialogues[10].SetActive(true);
            securityDialogues++;
        }
        if (_tankBuilding && securityDialogues == 10)
        {
            _manteDialogues[11].SetActive(true);
            securityDialogues++;
        }
        if (_manteTank && securityDialogues == 11)
        {
            _manteDialogues[12].SetActive(true);
            securityDialogues++;
        }
        if (_spiderCapture && _coleoptereCapture && securityDialogues == 12)
        {
            _manteDialogues[13].SetActive(true);
            securityDialogues++;
        }
    }


    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Mante qui parle

    void FirstsTextsMante()
    {
        _manteTalking[0].text = "Bienvenu � cette initiation jeune mante !";
        _manteTalking[1].text = "Excellent ! Vous savez maintenant comment vous orrienter dans ce monde minuscule mais passionnant";
        _manteTalking[2].text = "Parfait! Cette mante est n�e pour vous servir. Voyons si elle r�agit bien � nos ordres." +
            " Pour tester, s�lectionnez des unit�s en maintenant clic gauche par-dessus puis cliquez sur un point de la map.";
        _manteTalking[3].text = "Bien ! Elle semble savoir se d�placer sans probl�me. Attention, cependant, � v�rifier si vous poss�dez assez de ressources pour cr�er de nouvelles unit�s";
        _manteTalking[4].text = "Superbe, d�sormais, guidez vos mantes religieuses pour les �quiper d'attrape pucerons";
        _manteTalking[5].text = "Avec cet �quipement, nous pouvons enfin r�colter des pucerons";
        _manteTalking[6].text = "Parfait ! Cet approvisionnement va nous permettre de faire croitre notre campement.";
        _manteTalking[7].text = "Tiens ?";
        _manteTalking[8].text = "Des gendarmes ! Parfait, ces sous-insectes n'ont aucun instinct de survie. Entra�nez-vous sur eux. " +
            "Pour ordonner d'attaquer, s�lectionnez vos troupes et dirigez-les vers le gendarme le plus proche.";
        _manteTalking[9].text = "Leurs carapaces semblent �trangement solides, nous devrions certainement nous rendre dans leur tribu " +
            "afin d'en prendre le contr�le. Nous pourrons ensuite les utiliser pour nous d�velopper.";
        _manteTalking[10].text = "Excellent ! Gr�ce � la capture de ce campement, nous pouvons les utiliser les gendarmes pour " +
            "nous renforcer. Voyons ce que nous pouvons construire � partir de le corps."; 
        _manteTalking[11].text = "Eur�ka ! Lors de l'�tude des gendarmes, nous avons pu construire une caserne dans laquelle nous " +
            "les d�coupons dans le but d'en faire des pi�ces d'armure.";
        _manteTalking[12].text = "Bien ! il me semble que vous avez toutes les clefs en main pour vous imposer face aux " +
            "autres insectes. Montrez-leur qui dirige !";
        _manteTalking[13].text = "F�licitations, vous avez domin� ce territoire d'une main de fer et avez donc termin� " +
            "cette phase d'initiation.";
    }
    public void ManteWelcome()
    {
        string text1 = "Avant de commencer votre croisade, apprenons les commandes de base.";
        string text2 = "Pour vous aider tout au long de votre aventure, des objectifs s'afficheront en haut a droite de votre �cran.";

        if (dialogueNumtest == 1)
        {
            _manteTalking[0].text = text1;
        }
        if (dialogueNumtest == 2)
        {
            _manteTalking[0].text = text2;
        }
        if (dialogueNumtest == 3)
        {
            _manteDialogues[0].SetActive(false);

        }
        dialogueNumtest++;
        if (dialogueNumtest > 3)
        {
            dialogueNumtest = 1;
        }
    }
    public void ManteTalking2()
    {
        string text1 = "Passons maintenant � la cr�ation de vos unit�s dont vous prendrez le contr�le.";
        string text2 = "Pour cela, survolez votre campement avec le curseur et cliquer sur l'ic�ne d'oeuf pour cr�er une mante.";

        if (dialogueNumtest == 1)
        {
            _manteTalking[1].text = text1;
        }
        if (dialogueNumtest == 2)
        {
            _manteTalking[1].text = text2;
        }
        if (dialogueNumtest == 3)
        {
            _manteDialogues[1].SetActive(false);
        }
        dialogueNumtest++;
        if (dialogueNumtest > 3)
        {
            dialogueNumtest = 1;
        }
    }
    public void ManteTalking3()
    {
        _manteDialogues[2].SetActive(false);
    }
    public void ManteTalking4()
    {
        string text1 = "Pour �viter une telle catastrophe, construisons une Puceronni�re et �quipons nos mantes " +
            "religiuses. Ensuite, indiquons-leur un point de ressource � r�colter tel que les nids de pucerons, " +
            "un atout majeur dans le d�veloppement de la colonie";

        if (dialogueNumtest == 1)
        {
            _manteTalking[3].text = text1;
        }
        if (dialogueNumtest == 2)
        {
            _manteDialogues[3].SetActive(false);
        }
        dialogueNumtest++;
        if (dialogueNumtest == 3)
        {
            dialogueNumtest = 1;
        }
    }
    public void ManteTalking5()
    {
        _manteDialogues[4].SetActive(false);
    }
    public void ManteTalking6()
    {
        string text1 = "Cap sur l'Ouest o� les �claireurs nous ont renseign� sur la pr�sence d'un nid de pucerons.";

        if (dialogueNumtest == 1)
        {
            _manteTalking[5].text = text1;
        }
        if (dialogueNumtest == 2)
        {
            _manteDialogues[5].SetActive(false);
        }
        dialogueNumtest++;
        if (dialogueNumtest == 3)
        {
            dialogueNumtest = 1;
        }
    }
    public void ManteTalking7()
    {
        string text1 = "Minces, nos ouvriers sont vuln�rables face aux ennemis. Cr�ez de nouvelles unit�s pour en faire des troupes.";

        if (dialogueNumtest == 1)
        {
            _manteTalking[6].text = text1;
        }
        if (dialogueNumtest == 2)
        {
            _manteDialogues[6].SetActive(false);
        }
        dialogueNumtest++;
        if (dialogueNumtest == 3)
        {
            dialogueNumtest = 1;
        }
    }
    public void ManteTalking8()
    {
        string text1 = "C'est bizarre.";
        string text2 = "J'ai cru voir du mouvement vers le sud_ouest, nous decrions s�rement envoyer nos mantes et d�couvrir qu'elle est l'origine de cette agitation.";

        if (dialogueNumtest == 1)
        {
            _manteTalking[7].text = text1;
        }
        if (dialogueNumtest == 2)
        {
            _manteTalking[7].text = text2;
        }
        if (dialogueNumtest == 3)
        {
            _manteDialogues[7].SetActive(false);
        }
        dialogueNumtest++;
        if (dialogueNumtest > 3)
        {
            dialogueNumtest = 1;
        }
    }
    public void ManteTalking9()
    {
        _manteDialogues[8].SetActive(false);
    }
    public void ManteTalking10()
    {
        _manteDialogues[9].SetActive(false);
    }
    public void ManteTalking11()
    {
        _manteDialogues[10].SetActive(false);
    }
    public void ManteTalking12()
    {
        string text1 = "Nous pouvons maintenant �quiper nos mantes et en faire des soldats plus robustes avec une meilleure d�fense. " +
            "N�anmoins, elles perdront aussi en force de frappe.";
        string text2 = "S'il y a trop de mante � votre go�t, vous pouvez aussi les supprimer. Ne vous en faites pas, ce ne sont que des insectes facilement rempla�ables.";

        if (dialogueNumtest == 1)
        {
            _manteTalking[11].text = text1;
        }
        if (dialogueNumtest == 2)
        {
            _manteTalking[11].text = text2;
        }
        if (dialogueNumtest == 3)
        {
            _manteDialogues[11].SetActive(false);
        }
        dialogueNumtest++;
        if (dialogueNumtest > 3)
        {
            dialogueNumtest = 1;
        }
    }
    public void ManteTalking13()
    {
        string text1 = "Je crois en vous, ne me d�cevez pas !";

        if (dialogueNumtest == 1)
        {
            _manteTalking[12].text = text1;
        }
        if (dialogueNumtest == 2)
        {
            _manteDialogues[12].SetActive(false);
        }
        dialogueNumtest++;
        if (dialogueNumtest == 3)
        {
            dialogueNumtest = 1;
        }
    }
    public void ManteTalking14End()
    {
        string text1 = "Le jeu �tant toujours en d�veloppement, seule la phase d'initiation peut �tre jou�e pour le moment. " +
            "Si vous avez aim� cette phase d'introduction ou que vous voulez nous soutenir, n'h�sitez pas � nous donner votre avis. ";

        if (dialogueNumtest == 1)
        {
            _manteTalking[13].text = text1;
        }
        if (dialogueNumtest == 2)
        {
            _manteDialogues[13].SetActive(false);
        }
        dialogueNumtest++;
        if (dialogueNumtest == 3)
        {
            dialogueNumtest = 1;
        }
    }

}
