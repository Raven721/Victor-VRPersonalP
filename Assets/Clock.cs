using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform hourHandPivot;
    public Transform minuteHandPivot;
    public Transform secondHandPivot;

    private void Update()
    {
        DateTime currentTime = DateTime.Now;

        float hourDegrees = (currentTime.Hour % 12 + currentTime.Minute / 60f) * 30f;
        float minuteDegrees = currentTime.Minute * 6f;
        float secondDegrees = currentTime.Second * 6f;

        hourHandPivot.localRotation = Quaternion.Euler(hourDegrees,0f, 0f );
        minuteHandPivot.localRotation = Quaternion.Euler(minuteDegrees,0f, 0f );
        secondHandPivot.localRotation = Quaternion.Euler(secondDegrees,0f, 0f );
    }
}
