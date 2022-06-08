using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text textAmmonition;
    [SerializeField] private GameObject imageInventory;
    public void UpdateAmmonition(int ammonition)
    {
        this.textAmmonition.text = ammonition.ToString();
    }

    public void CollectedCoin()
    {
        this.imageInventory.SetActive(true);
    }

    public void RemoveCoin()
    {
        this.imageInventory.SetActive(false);
    }
}
