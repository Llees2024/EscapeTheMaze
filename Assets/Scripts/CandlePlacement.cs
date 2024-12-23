using UnityEngine;

public class CandlePlacement : MonoBehaviour
{
    public GameObject candlePrefab;
    public int maxCandles = 5;
    private int currentCandles = 0;
    public float placementDistance = 2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && currentCandles < maxCandles)
        {
            PlaceCandle();
        }
    }

    void PlaceCandle()
    {

        Vector3 playerPosition = transform.position;
        Vector3 playerForward = transform.forward;


        Vector3 placePosition = playerPosition + playerForward * placementDistance;


        Instantiate(candlePrefab, placePosition, Quaternion.identity);


        currentCandles++;


        Debug.Log("Candles placed: " + currentCandles + "/" + maxCandles);
    }
}
