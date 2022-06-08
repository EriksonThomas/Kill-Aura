using UnityEngine;

public class GlobalRandomMultiplier : MonoBehaviour
{
    private float randomNumber;
    private Vector3 randomVector;
    public float randomNumberMax;
    public float GenerateRandomNumber()
    {
        randomNumber = Random.Range(1.0f, randomNumberMax);
        return randomNumber;
    }
    public Vector3 GenerateRandomVector(float outerBound, float innerBound)
    {
        randomVector = Random.insideUnitCircle.normalized * Random.Range(innerBound, outerBound);
        return randomVector;
    }
}

//var randomNumber = GameHandler.instance.GetComponent<GlobalRandomMultiplier>().GenerateRandomNumber();
//var positionOffset = GameHandler.instance.GetComponent<GlobalRandomMultiplier>().GenerateRandomVector(innerBound, outerBound);  