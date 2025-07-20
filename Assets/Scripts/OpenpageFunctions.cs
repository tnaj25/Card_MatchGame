using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenpageFunctions : MonoBehaviour
{
    public Button easy;
    public Button medium;
    public Button hard;

    public Image easyImage;
    public Image mediumImage;
    public Image hardImage;

    public GameObject openpanel;
    public GameObject gameOpen;
    public Color newColor = Color.green;
    public Color defaultColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        gameOpen.SetActive(false);//false
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
    }
}
