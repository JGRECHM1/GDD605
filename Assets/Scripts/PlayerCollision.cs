using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCollision : MonoBehaviour
{


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Terrain"))
        {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("MilitaryAsset"))
        {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("CivilianBuilding"))
        {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
        }
    }





}
