using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateID : MonoBehaviour
{
    [ReadOnly]
    public bool Generate = true;
    [ReadOnly]
    public int Massiv = 0;
  
    private Button button;
    private Games gm;

    private void Start()
    {
        gm = GameObject.Find("Canvas").GetComponent<Games>();
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(Starting);
    }
   
    public void Starting()
    {
        gm.Paint(button);
    }
}