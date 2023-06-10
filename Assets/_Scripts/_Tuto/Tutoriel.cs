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
        _panelTuto_1.text = "Déplacez la caméra avec les flèches directionnelles.";
        _panelTuto_2.text = "A l'aide de la molette et de votre souris, zoomer et dézoomer.";
        _panelTuto_3.text = "Créez une mante grâce à votre tribu.";
        _panelTuto_4.text = "maintenir clic gauche pour former un rectangle de sélection afin de sélectionner des mantes.";

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
                _panelTuto_1.text = "Clic droit pour déplacer toutes les unités sélectionnées.";
                securityPanel1 = 1;
                timer = 1;
            }
        }
        if (_equipeManteRecolte && securityPanel1 == 1)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _panelTuto_1.text = "Créer 5 unités de mante.";
                securityPanel1 = 2;
                timer = 1;
            }
        }
        if (_gendarmeKill && securityPanel1 == 2)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _panelTuto_1.text = "Construire la caserne des gendarmes dans la colonie alliée.";
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
                _panelTuto_2.text = "Depuis le village, construire une Puceronnière en cliquand sur l'icône du marteau.";
                securityPanel2 = 1;
                timer = 1;
            }
        }
        if (_recolterPucerons && securityPanel2 == 1)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _panelTuto_2.text = "Déplacer au moins une mante vers le sud-ouest.";
                securityPanel2 = 2;
                timer = 1;
            }
        }
        if (_gendarmeTownCapture && securityPanel2 == 2)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _panelTuto_2.text = "Supprimer une mante et en équiper une avec une armure de gendarme.";
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
                _panelTuto_3.text = "Sélectionner une mante et faire un clic droit sur le bâtiment pour équiper la mante.";
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
                _panelTuto_4.text = "Allez récolter des pucerons pour réaprovisionner le campement.";
                securityPanel4 = 1;
                timer = 1;
            }
        }
        if (_gendarmeDiscover && securityPanel4 == 1)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _panelTuto_4.text = "Capturer la tribu des gendarmes en positionnant au moins une mante à l'intérieur de celui-ci en attendant sa prise.";
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
        _manteTalking[0].text = "Bienvenu à cette initiation jeune mante !";
        _manteTalking[1].text = "Excellent ! Vous savez maintenant comment vous orrienter dans ce monde minuscule mais passionnant";
        _manteTalking[2].text = "Parfait! Cette mante est née pour vous servir. Voyons si elle réagit bien à nos ordres." +
            " Pour tester, sélectionnez des unités en maintenant clic gauche par-dessus puis cliquez sur un point de la map.";
        _manteTalking[3].text = "Bien ! Elle semble savoir se déplacer sans problème. Attention, cependant, à vérifier si vous possédez assez de ressources pour créer de nouvelles unités";
        _manteTalking[4].text = "Superbe, désormais, guidez vos mantes religieuses pour les équiper d'attrape pucerons";
        _manteTalking[5].text = "Avec cet équipement, nous pouvons enfin récolter des pucerons";
        _manteTalking[6].text = "Parfait ! Cet approvisionnement va nous permettre de faire croitre notre campement.";
        _manteTalking[7].text = "Tiens ?";
        _manteTalking[8].text = "Des gendarmes ! Parfait, ces sous-insectes n'ont aucun instinct de survie. Entraînez-vous sur eux. " +
            "Pour ordonner d'attaquer, sélectionnez vos troupes et dirigez-les vers le gendarme le plus proche.";
        _manteTalking[9].text = "Leurs carapaces semblent étrangement solides, nous devrions certainement nous rendre dans leur tribu " +
            "afin d'en prendre le contrôle. Nous pourrons ensuite les utiliser pour nous développer.";
        _manteTalking[10].text = "Excellent ! Grâce à la capture de ce campement, nous pouvons les utiliser les gendarmes pour " +
            "nous renforcer. Voyons ce que nous pouvons construire à partir de le corps."; 
        _manteTalking[11].text = "Eurêka ! Lors de l'étude des gendarmes, nous avons pu construire une caserne dans laquelle nous " +
            "les découpons dans le but d'en faire des pièces d'armure.";
        _manteTalking[12].text = "Bien ! il me semble que vous avez toutes les clefs en main pour vous imposer face aux " +
            "autres insectes. Montrez-leur qui dirige !";
        _manteTalking[13].text = "Félicitations, vous avez dominé ce territoire d'une main de fer et avez donc terminé " +
            "cette phase d'initiation.";
    }
    public void ManteWelcome()
    {
        string text1 = "Avant de commencer votre croisade, apprenons les commandes de base.";
        string text2 = "Pour vous aider tout au long de votre aventure, des objectifs s'afficheront en haut a droite de votre écran.";

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
        string text1 = "Passons maintenant à la création de vos unités dont vous prendrez le contrôle.";
        string text2 = "Pour cela, survolez votre campement avec le curseur et cliquer sur l'icône d'oeuf pour créer une mante.";

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
        string text1 = "Pour éviter une telle catastrophe, construisons une Puceronnière et équipons nos mantes " +
            "religiuses. Ensuite, indiquons-leur un point de ressource à récolter tel que les nids de pucerons, " +
            "un atout majeur dans le développement de la colonie";

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
        string text1 = "Cap sur l'Ouest où les éclaireurs nous ont renseigné sur la présence d'un nid de pucerons.";

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
        string text1 = "Minces, nos ouvriers sont vulnérables face aux ennemis. Créez de nouvelles unités pour en faire des troupes.";

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
        string text2 = "J'ai cru voir du mouvement vers le sud_ouest, nous decrions sûrement envoyer nos mantes et découvrir qu'elle est l'origine de cette agitation.";

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
        string text1 = "Nous pouvons maintenant équiper nos mantes et en faire des soldats plus robustes avec une meilleure défense. " +
            "Néanmoins, elles perdront aussi en force de frappe.";
        string text2 = "S'il y a trop de mante à votre goût, vous pouvez aussi les supprimer. Ne vous en faites pas, ce ne sont que des insectes facilement remplaçables.";

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
        string text1 = "Je crois en vous, ne me décevez pas !";

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
        string text1 = "Le jeu étant toujours en développement, seule la phase d'initiation peut être jouée pour le moment. " +
            "Si vous avez aimé cette phase d'introduction ou que vous voulez nous soutenir, n'hésitez pas à nous donner votre avis. ";

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
