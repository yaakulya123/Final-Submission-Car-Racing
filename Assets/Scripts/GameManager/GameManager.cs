using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class GameManager : MonoBehaviour
{
    public static bool isRaceFinished;
    public Text speedValueText;

    [Header("MeshRenderers")]
    public MeshRenderer carBody;
    public MeshRenderer mudGuardLeft;
    public MeshRenderer mudGuardRight;

    [Header("Red Material")]
    public Material carBodyRed;
    public Material mudGuardRed;

    [Header("Blue Material")]
    public Material carBodyBlue;
    public Material mudGuardBlue;
    private void Start()
    {
        isRaceFinished = false;

        if(GlobalCar.CarType == 1)
        {
            carBody.material = carBodyRed;
            mudGuardLeft.material = mudGuardRed;
            mudGuardRight.material = mudGuardRed;
        }
        if(GlobalCar.CarType == 2)
        {
            carBody.material = carBodyBlue;
            mudGuardLeft.material = mudGuardBlue;
            mudGuardRight.material = mudGuardBlue;
        }
    }
    private void Update()
    {
        float speed = Mathf.Round(CarController.showSpeedValue);
        speedValueText.text = "Speed: " + speed;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
