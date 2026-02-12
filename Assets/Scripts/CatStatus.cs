using UnityEngine;

public class CatStatus : MonoBehaviour
{
    public int tunaCount = 0;

    public void AddTuna()
    {
        tunaCount++;
        Debug.Log("TunaCount: " + tunaCount);
    }
}