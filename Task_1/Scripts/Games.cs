using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Games : MonoBehaviour
{
    [Header("Текстуры")]
    public Sprite[] texture;

    [Header("Наши клетки")]
    public Button[] img;

    private bool isCheck = false;
    private string[] final= { "0", "1", "2", "3", "4", "5", "6", "7" };
    private int course=0;

    private void Start()
    {
        for (int i=0; i<img.Length;i++)
        {
          
            img[i].transform.GetComponent<Image>().sprite = texture[2];
            img[i].transform.GetComponent<GenerateID>().Generate = true;
            img[i].transform.GetComponent<GenerateID>().Massiv = 0;
        }
        for (int i = 0; i < 8; i++)
        {
            final[i] = "null";
        }

        isCheck = false;
        course = 0;
    }

    private void Update()
    {
        Winner();
    }
  
    public void Paint(Button buttonClicked)
    {

            if (isCheck == true && buttonClicked.GetComponent<GenerateID>().Generate == true)
            {
                buttonClicked.transform.GetComponent<Image>().sprite = texture[1];
                isCheck = false;
                buttonClicked.GetComponent<GenerateID>().Generate = false;
                buttonClicked.GetComponent<GenerateID>().Massiv = 2;
                course += 1;
            }
            if (isCheck == false && buttonClicked.GetComponent<GenerateID>().Generate == true)
            {
                buttonClicked.transform.GetComponent<Image>().sprite = texture[0];
                isCheck = true;
                buttonClicked.GetComponent<GenerateID>().Generate = false;
                //если=1,то крестик, и наоборот
                buttonClicked.GetComponent<GenerateID>().Massiv = 1;
                course += 1;
            }      
    }   
    public void Winner()
    {
        final[0] = "" + img[0].gameObject.GetComponent<GenerateID>().Massiv + "" + img[1].gameObject.GetComponent<GenerateID>().Massiv + "" + img[2].gameObject.GetComponent<GenerateID>().Massiv;
        final[1] = "" + img[3].gameObject.GetComponent<GenerateID>().Massiv + "" + img[4].gameObject.GetComponent<GenerateID>().Massiv + "" + img[5].gameObject.GetComponent<GenerateID>().Massiv;
        final[2] = "" + img[6].gameObject.GetComponent<GenerateID>().Massiv + "" + img[7].gameObject.GetComponent<GenerateID>().Massiv + "" + img[8].gameObject.GetComponent<GenerateID>().Massiv;

        final[3] = "" + img[0].gameObject.GetComponent<GenerateID>().Massiv + "" + img[3].gameObject.GetComponent<GenerateID>().Massiv + "" + img[6].gameObject.GetComponent<GenerateID>().Massiv;
        final[4] = "" + img[1].gameObject.GetComponent<GenerateID>().Massiv + "" + img[4].gameObject.GetComponent<GenerateID>().Massiv + "" + img[7].gameObject.GetComponent<GenerateID>().Massiv;
        final[5] = "" + img[2].gameObject.GetComponent<GenerateID>().Massiv + "" + img[5].gameObject.GetComponent<GenerateID>().Massiv + "" + img[8].gameObject.GetComponent<GenerateID>().Massiv;

        final[6] = "" + img[0].gameObject.GetComponent<GenerateID>().Massiv + "" + img[4].gameObject.GetComponent<GenerateID>().Massiv + "" + img[8].gameObject.GetComponent<GenerateID>().Massiv;
        final[7] = "" + img[2].gameObject.GetComponent<GenerateID>().Massiv + "" + img[4].gameObject.GetComponent<GenerateID>().Massiv + "" + img[6].gameObject.GetComponent<GenerateID>().Massiv;

        if (course!=9) {
            if (final[0] == "111" | final[1] == "111" | final[2] == "111" | final[3] == "111" | final[4] == "111" | final[5] == "111" | final[6] == "111" | final[7] == "111")
            {
                print("Победил крестик!");
                Start();
            }
            if (final[0] == "222" | final[1] == "222" | final[2] == "222" | final[3] == "222" | final[4] == "222" | final[5] == "222" | final[6] == "222" | final[7] == "222")
            {
                print("Победил нолик!");
                Start();
            }
        }
        else
        {
            if ((final[0] == "111" | final[1] == "111" | final[2] == "111" | final[3] == "111" | final[4] == "111" | final[5] == "111" | final[6] == "111" | final[7] == "111")|| (final[0] == "222" | final[1] == "222" | final[2] == "222" | final[3] == "222" | final[4] == "222" | final[5] == "222" | final[6] == "222" | final[7] == "222"))
            {
                if (final[0] == "111" | final[1] == "111" | final[2] == "111" | final[3] == "111" | final[4] == "111" | final[5] == "111" | final[6] == "111" | final[7] == "111")
                {
                    print("Победил крестик!");
                    Start();
                }
                if (final[0] == "222" | final[1] == "222" | final[2] == "222" | final[3] == "222" | final[4] == "222" | final[5] == "222" | final[6] == "222" | final[7] == "222")
                {
                    print("Победил нолик!");
                    Start();
                }

            }
            else if((final[0] != "111" | final[1] != "111" | final[2] != "111" | final[3] != "111" | final[4] != "111" | final[5] != "111" | final[6] != "111" | final[7] != "111") && (final[0] != "222" | final[1] != "222" | final[2] != "222" | final[3] != "222" | final[4] != "222" | final[5] != "222" | final[6] != "222" | final[7] != "222"))
            {
                print("Ничья");
                Start();

            }
           
        }
    }
    public void GameWisBot(Button buttonClicked)
    {
        if (isCheck == true && buttonClicked.GetComponent<GenerateID>().Generate == true)
        {
            //Бот
            buttonClicked.transform.GetComponent<Image>().sprite = texture[1];
            isCheck = false;
            buttonClicked.GetComponent<GenerateID>().Generate = false;
            buttonClicked.GetComponent<GenerateID>().Massiv = 2;
            course += 1;
        }
        if (isCheck == false && buttonClicked.GetComponent<GenerateID>().Generate == true)
        {
            //Игрок

            buttonClicked.transform.GetComponent<Image>().sprite = texture[0];
            isCheck = true;
            buttonClicked.GetComponent<GenerateID>().Generate = false;
            //если=1,то крестик, и наоборот
            buttonClicked.GetComponent<GenerateID>().Massiv = 1;
            course += 1;
        }
    }
}
