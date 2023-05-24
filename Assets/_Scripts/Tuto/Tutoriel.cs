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
    public bool _recolteBuilding = false;       // 21
    public bool _equipeManteRecolte = false;    // 31
    public bool _recolterPucerons = false;      // 41
    public bool _createFiveUnit = false;        // 122
    public bool _gendarmeDiscover = false;      // 222
    public bool _gendarmeKill = false;          // 322
    public bool _gendarmeTownCapture = false;   // 422
    public bool _tankBuilding = false;          // 1333
    public bool _manteTank = false;             // 2333
    public bool _spiderCapture = false;         // 3333
    public bool _coleoptereCapture = false;     // 4333

    [SerializeField] private TMP_Text _panelTuto_1;
    [SerializeField] private TMP_Text _panelTuto_2;
    [SerializeField] private TMP_Text _panelTuto_3;
    [SerializeField] private TMP_Text _panelTuto_4;

    [SerializeField] private TMP_Text[] _manteTalking;

    [SerializeField] private GameObject[] _manteDialogues;
    // Start is called before the first frame update
    void Start()
    {
        _panelTuto_1.text = "Utilisez les flèches directionnelles pour vous déplacer sur la carte.";
        _panelTuto_2.text = "Utilisez les flèches directionnelles pour vous déplacer sur la carte.";
        _panelTuto_3.text = "Utilisez les flèches directionnelles pour vous déplacer sur la carte.";
        _panelTuto_4.text = "Utilisez les flèches directionnelles pour vous déplacer sur la carte.";

        FirstsTextsMante();
    }

    // Update is called once per frame
    void Update()
    {
        ActivateDialogue();
    }
    void ActivateDialogue()
    {
        int security = 0;
        if (_cameraMouvment && _zoom && security == 0)
        {
            _manteDialogues[1].SetActive(true);
            security++;
        }
        if (_unitCreation && security == 1)
        {
            _manteDialogues[2].SetActive(true);
            security++;
        }
        if (_selectUnit && _moveUnit && security == 2)
        {
            _manteDialogues[3].SetActive(true);
            security++;
        }
        if (_recolteBuilding && security == 3)
        {
            _manteDialogues[4].SetActive(true);
            security++;
        }
        if (_equipeManteRecolte && security == 4)
        {
            _manteDialogues[5].SetActive(true);
            security++;
        }
        if (_recolterPucerons && security == 5)
        {
            _manteDialogues[6].SetActive(true);
            security++;
        }
        if (_createFiveUnit && security == 6)
        {
            _manteDialogues[7].SetActive(true);
            security++;
        }
        if (_gendarmeDiscover && security == 7)
        {
            _manteDialogues[8].SetActive(true);
            security++;
        }
        if (_gendarmeKill && security == 8)
        {
            _manteDialogues[9].SetActive(true);
            security++;
        }
        if (_gendarmeTownCapture && security == 9)
        {
            _manteDialogues[10].SetActive(true);
            security++;
        }
        if (_tankBuilding && security == 10)
        {
            _manteDialogues[11].SetActive(true);
            security++;
        }
        if (_manteTank && security == 11)
        {
            _manteDialogues[12].SetActive(true);
            security++;
        }
        if (_spiderCapture && _coleoptereCapture && security == 12)
        {
            _manteDialogues[13].SetActive(true);
            security++;
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
        string text2 = "Pour vous aider tout au long de votre aventure, des objectifs s'afficheront en haut a droite de votre écran";

        int dialogueNum = 0;
        if (dialogueNum == 1)
        {
            _manteTalking[0].text = text1;
        }
        if (dialogueNum == 2)
        {
            _manteTalking[0].text = text2;
        }
        if (dialogueNum == 3)
        {
            _manteDialogues[0].SetActive(false);

        }
        dialogueNum++;
    }

    public void ManteTalking2()
    {
        string text1 = "Passons maintenant à la création de vos unités dont vous prendrez le contrôle.";
        string text2 = "Pour cela, survolez votre campement avec le curseur et cliquer sur l'icône d'oeuf pour créer une mante.";

        int dialogueNum = 0;
        if (dialogueNum == 1)
        {
            _manteTalking[1].text = text1;
        }
        if (dialogueNum == 2)
        {
            _manteTalking[1].text = text2;
        }
        if (dialogueNum == 3)
        {
            _manteDialogues[1].SetActive(false);
        }
        dialogueNum++;
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

        int dialogueNum = 0;
        if (dialogueNum == 1)
        {
            _manteTalking[3].text = text1;
        }
        if (dialogueNum == 2)
        {
            _manteDialogues[3].SetActive(false);
        }
        dialogueNum++;
    }
    public void ManteTalking5()
    {
        _manteDialogues[4].SetActive(false);
    }
    public void ManteTalking6()
    {
        string text1 = "Cap sur l'Ouest où les éclaireurs nous ont renseigné sur la présence d'un nid de pucerons.";

        int dialogueNum = 0;
        if (dialogueNum == 1)
        {
            _manteTalking[5].text = text1;
        }
        if (dialogueNum == 2)
        {
            _manteDialogues[5].SetActive(false);
        }
        dialogueNum++;
    }
    public void ManteTalking7()
    {
        string text1 = "Minces, nos ouvriers sont vulnérables face aux ennemis. Créez de nouvelles unités pour en faire des troupes.";

        int dialogueNum = 0;
        if (dialogueNum == 1)
        {
            _manteTalking[6].text = text1;
        }
        if (dialogueNum == 2)
        {
            _manteDialogues[6].SetActive(false);
        }
        dialogueNum++;
    }
    public void ManteTalking8()
    {
        string text1 = "C'est bizarre.";
        string text2 = "J'ai cru voir du mouvement vers le sud_ouest, nous decrions sûrement envoyer nos mantes et découvrir qu'elle est l'origine de cette agitation.";

        int dialogueNum = 0;
        if (dialogueNum == 1)
        {
            _manteTalking[7].text = text1;
        }
        if (dialogueNum == 2)
        {
            _manteTalking[7].text = text2;
        }
        if (dialogueNum == 3)
        {
            _manteDialogues[7].SetActive(false);
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

        int dialogueNum = 0;
        if (dialogueNum == 1)
        {
            _manteTalking[11].text = text1;
        }
        if (dialogueNum == 2)
        {
            _manteTalking[11].text = text2;
        }
        if (dialogueNum == 3)
        {
            _manteDialogues[11].SetActive(false);
        }
    }
    public void ManteTalking13()
    {
        string text1 = "Je crois en vous, ne me décevez pas !";

        int dialogueNum = 0;
        if (dialogueNum == 1)
        {
            _manteTalking[12].text = text1;
        }
        if (dialogueNum == 2)
        {
            _manteDialogues[12].SetActive(false);
        }
        dialogueNum++;
    }
    public void ManteTalking14End()
    {
        string text1 = "Le jeu étant toujours en développement, seule la phase d'initiation peut être jouée pour le moment. " +
            "Si vous avez aimé cette phase d'introduction ou que vous voulez nous soutenir, n'hésitez pas à nous donner votre avis. ";

        int dialogueNum = 0;
        if (dialogueNum == 1)
        {
            _manteTalking[13].text = text1;
        }
        if (dialogueNum == 2)
        {
            _manteDialogues[13].SetActive(false);
        }
        dialogueNum++;
    }

}
