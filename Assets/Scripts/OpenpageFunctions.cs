using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenpageFunctions : MonoBehaviour
{
    public static OpenpageFunctions instance;
    public Button easy;
    public Button medium;
    public Button hard;

    public Image easyImage;
    public Image mediumImage;
    public Image hardImage;

    public GameObject openpanel;
    public GameObject gameOpen;
    public GameObject gameOver;
    public TextMeshProUGUI gametext;

    public Color newColor = Color.green;
    public Color defaultColor = Color.white;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOpen.SetActive(false);
        gameOver.SetActive(false);
        easy.onClick.AddListener(ChangeColorEasy);
        medium.onClick.AddListener(ChangeColorMedium);
        hard.onClick.AddListener(ChangeColorHard);
       

    }





    // Update is called once per frame
    void Update()
    {

    }
    void ChangeColorEasy()
    {
        easyImage.color = newColor;
        mediumImage.color = defaultColor;
        hardImage.color = defaultColor;
    }
    void ChangeColorMedium()
    {
        easyImage.color = defaultColor;
        mediumImage.color = newColor;
        hardImage.color = defaultColor;
    }
    void ChangeColorHard()
    {
        easyImage.color = defaultColor;
        mediumImage.color = defaultColor;
        hardImage.color = newColor;
    }
    public void GameStart()
    {
        openpanel.SetActive(false);
        gameOpen.SetActive(true); 
        gameOver.SetActive(false);
    }
    public void GameOver()
    {
        openpanel.SetActive(false);
        gameOpen.SetActive(false);
        gameOver.SetActive(true);
    }
    public void Replay()
    {
        openpanel.SetActive(false);
        gameOpen.SetActive(false);
        gameOver.SetActive(true);
        gametext.text = "You Win";
    }
}
