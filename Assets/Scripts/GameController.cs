using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI matchdata, turndata;
    [SerializeField]
    private Sprite bgImg;
    public List<Button> btns= new List<Button>();

    public Sprite[] card;
    public List<Sprite> gameCards=new List<Sprite>();

    private bool firstGuess, secondGuess;
    private int countGuesses;
    private int match;
    private int turns;
    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessCard, secondGuessCard;
    private void Awake()
    {
        card = Resources.LoadAll<Sprite>("Sprites/img");
    }
    // Start is called before the first frame update
    void Start()
    {
        GetButtons();
        AddListeners();
        AddGamecards();
        Shuffle(gameCards);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("CardBtn");
        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImg;
        }

    }
    void AddGamecards()
    {
        int looper= btns.Count;
        int index = 0;
        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 0;
               
            }
            gameCards.Add(card[index]);
            index++;
        }

    }
    void AddListeners()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => PicACard());

           
        }
    }
    public void PicACard()
    {

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
           firstGuessCard= gameCards[firstGuessIndex].name;
           // btns[firstGuessIndex].image.sprite = gameCards[firstGuessIndex];
            StartCoroutine(FlipCard(btns[firstGuessIndex], gameCards[firstGuessIndex]));

        }
        else if(!secondGuess)
        {

            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessCard= gameCards[secondGuessIndex].name;
            //btns[secondGuessIndex].image.sprite = gameCards[secondGuessIndex];
            StartCoroutine(FlipCard(btns[secondGuessIndex], gameCards[secondGuessIndex]));

            countGuesses++;
            StartCoroutine(CheckCardMatch());
        }
       

    }
    IEnumerator CheckCardMatch()
    {
        yield return new WaitForSeconds(1f);

       
            if (firstGuessCard == secondGuessCard)
            {
                yield return new WaitForSeconds(.5f);
            /* btns[firstGuessIndex].interactable = false;
             btns[secondGuessIndex].interactable = false;

             btns[firstGuessIndex].image.color=new Color(0,0,0,0);
             btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);*/
            StartCoroutine(MatchAnimation(btns[firstGuessIndex], btns[secondGuessIndex]));



            CheckGameFinished();
            
            }
            else
            {
                yield return new WaitForSeconds(.5f);
            /*btns[firstGuessIndex].image.sprite = bgImg;
            btns[secondGuessIndex].image.sprite = bgImg;*/

            StartCoroutine(FlipCard(btns[firstGuessIndex], bgImg));
            StartCoroutine(FlipCard(btns[secondGuessIndex], bgImg));

        }
        yield return new WaitForSeconds(.5f);
            firstGuess = secondGuess = false;
        turns++;
        turndata.text=turns.ToString();
        
    }
    void CheckGameFinished()
    {
        match++;
        matchdata.text=match.ToString();
        if(match == gameCards.Count / 2  )
        {
            Debug.Log("game finished");
        }
    }
    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex=Random.Range(0, list.Count);
            list[i]=list[randomIndex];
            list[randomIndex]=temp;
        }

    }

    IEnumerator FlipCard(Button cardButton, Sprite newSprite)
    {
        float time = 0.2f;
        float elapsedTime = 0f;

       
        while (elapsedTime < time)
        {
            float yRotation = Mathf.Lerp(0, 90, elapsedTime / time);
            cardButton.transform.rotation = Quaternion.Euler(0, yRotation, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cardButton.image.sprite = newSprite; 
        elapsedTime = 0f;

       
        while (elapsedTime < time)
        {
            float yRotation = Mathf.Lerp(90, 180, elapsedTime / time);
            cardButton.transform.rotation = Quaternion.Euler(0, yRotation, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cardButton.transform.rotation = Quaternion.Euler(0, 0, 0); // Reset rotation
    }


    IEnumerator MatchAnimation(Button card1, Button card2)
    {
        Vector3 originalScale = Vector3.one;
        Vector3 popScale = originalScale * 1.2f;

        float duration = 0.2f;

       
        float elapsed = 0f;
        while (elapsed < duration)
        {
            card1.transform.localScale = Vector3.Lerp(originalScale, popScale, elapsed / duration);
            card2.transform.localScale = Vector3.Lerp(originalScale, popScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        
        elapsed = 0f;
        while (elapsed < duration)
        {
            card1.transform.localScale = Vector3.Lerp(popScale, originalScale, elapsed / duration);
            card2.transform.localScale = Vector3.Lerp(popScale, originalScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

       
        card1.image.color = new Color(0, 0, 0, 0);
        card2.image.color = new Color(0, 0, 0, 0);

        card1.interactable = false;
        card2.interactable = false;
    }

}

