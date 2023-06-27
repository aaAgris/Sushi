using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class maksatLogs : MonoBehaviour
{
    public void maksaLogs()
    {
        // Update the price before transitioning to the next scene
        PriceManager.Instance.UpdatePrice();

        SceneManager.LoadScene(4);
    }
}

