using UnityEngine;

public class RandomDamageNumber : MonoBehaviour
{
    private float randomNumber;
    public float randomNumberMax;
    public float GenerateRandomNumber()
    {
        randomNumber = Random.Range(1.0f, randomNumberMax);
        return randomNumber;
    }
}

//var randomNumber = GameHandler.instance.GetComponent<RandomDamageNumber>().GenerateRandomNumber();