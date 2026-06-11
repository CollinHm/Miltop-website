using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SBS_GuidManager : MonoBehaviour
{
    public int stepIndex = 0;
    [SerializeField] private int endGuideIndex;
    [SerializeField] private int guideEndTimer;
    [SerializeField] private GameObject mainMenuPanel;
    public TMP_Text stepGuide;
    public string stepGuideText;

    private bool[] correctItemBoolArray = new bool[6];
    private int orderTrackerInt = 0;

    [SerializeField] private GameObject pipeManager;
    private PipeManager pipeManagerScript;

    [SerializeField] private bool levelChooserBool;

    void Start()
    {
        mainMenuPanel.SetActive(false);
        StepIndexStepList();
        stepGuide.text = stepGuideText;
        pipeManagerScript = pipeManager.GetComponent<PipeManager>();
    }

    public void CompomentCorrectToStep(bool correctItem, bool correctOrder)
    {
        if (correctItem && correctOrder)
        {
            stepIndex++;
            orderTrackerInt++;
            pipeManagerScript.UpdatePipes(stepIndex);
            StepIndexStepList();
        }
        else
        {
            pipeManagerScript.UpdatePipes(stepIndex);
            StepIndexStepList();
        }
    }

    void StepIndexStepList()
    {
        switch (stepIndex)
        {
            case 0: // Step 0:
                stepGuideText = levelChooserBool ? 
                    "Stap 1: Wij gaan een waterfabriek maken! Wij hebben 1 probleem... hoe en waar halen wij ons water vandaan? Welke machine hebben wij hier voor nodig? Verschuif de benodigde machine naar de eerste plek."
                    :
                    "Stap 1: Wij hebben nu ons water gewonnen en wij gaan nu een bier fabriek maken! Voor ons bier hebben wij gemalen mout nodig, welke machine zou ons hierbij kunnen helpen?";
                break;
            case 1: // Step 1:
                stepGuideText = levelChooserBool ?
                    "Stap 2: Wij hebben nu grondwater gewonnen alleen is het water nog zuurstofarm. Wat voor machine hebben wij nodig om zuurstof te kunnen toevoegen aan ons gewonnen water? Verschuif de benodigde machine naar de tweede plek."
                    :
                    "Stap 2: Nu gaan wij ons water toevoegen aan de mout zodat zetmeel omgezet wordt naar suikers. Welke machine zou ons hierbij kunnen helpen?";
                break;
            case 2: // Step 2:
                stepGuideText = levelChooserBool ?
                    "Stap 3: Ons water is nogal hard... er zit veel calcium en magnesium in ons water. Wat voor machine hebben wij nodig om het calcium en magnesium uit ons water te verwijderen? Verschuif de benodigde machine naar de derde plek."
                    :
                    "Stap 3: Onze mout is nu omgeet naar suikers! Wij hebben een machine nodig die onze suikers zou kunnen verwaremen. Welke machine zou ons hierbij kunnen helpen?";
                break;
            case 3: // Step 3:
                stepGuideText = levelChooserBool ?
                    "Stap 4: Nu dat wij de calcium en magnesium uit ons water hebben verwijderd, kunnen wij ons water gaan filtreren. Verschuif de benodigde machine naar de vierde plek."
                    :
                    "Stap 4: Nu willen wij onze vloeistof scheiden. Welke machine zou ons hierbij kunnen helpen?";
                break;
            case 4: // Step 4:
                stepGuideText = levelChooserBool ?
                    "Stap 5: Ons water is nu goed gefiltreerd en zal klaar staan om gedronken te worden. Maar wij hebben nu zo veel water... waar moeten wij dit opslaan? Verschuif de benodigde machine naar de vijfde plek."
                    :
                    "Stap 5: Wij willen nu zo veel mogenlijk bacteriën doden voor meer smaak en bitterheid. Welke machine zou ons hierbij kunnen helpen?";
                break;
            case 5: // Step 5:
                stepGuideText = levelChooserBool ?
                    "Stap 6: nu dat ons water opgeslagen is... gaan wij het doorsturen naar andere bedrijven zoals heineken..."
                    :
                    "Stap 6: Om ons bier helrder te krijgen willen wij onze vloeistof ronddraaien zodat vaste deeltjes zakken naar het midden. Welke machine zou ons hierbij kunnen helpen?";
                break;
            case 6: // Step 7:
                stepGuideText = "Stap 7: Onze vloeistof is behoorlijk heet en moet gekoeld worden. Welke machine zou ons hierbij kunnen helpen?";
                break;
            case 7: // Step 8:
                stepGuideText = "Stap 8: Wij gaan nu de suikers van ons vloeistof omzetten tot alcohol. Welke machine zou ons hierbij kunnen helpen?";
                break;
            case 8: // Step 9:
                stepGuideText = "Stap 9: In onze bier zit nu eindelijk alcohol maar wij willen nog meer smaak gaan toevoegen, wij gaan het laten rijpen! Welke machine zou ons hierbij kunnen helpen?";
                break;
            case 9: // Step 10:
                stepGuideText = "Stap 10: Er zit nog restgist in ons bier, wij willen dit verwijderen. Welke machine zou ons hierbij kunnen helpen?";
                break;
            case 10: // Step 11:
                stepGuideText = "Stap 11: Ons bier is nu klaar om in een fles gezet te worden!";
                break;
            default:
                Debug.LogError("Invalid step index");
                break;
        }
        stepGuide.text = stepGuideText;
        if (endGuideIndex == stepIndex)
        {
            StartCoroutine(GameRestart());
        }
    }

    IEnumerator GameRestart()
    {
        yield return new WaitForSeconds(guideEndTimer);
        mainMenuPanel.SetActive(true);
    }

    public void MenuLevel1Play()
    {
        // Deactivate mainMenuPanel and relocate the draggables and undo the dropspots
        SceneManager.LoadScene(0);
    }

    public void MenuLevel2Play()
    {
        SceneManager.LoadScene(1);
        // Load Level 2 Scene
        // SceneManager.LoadScene(1);
    }
}