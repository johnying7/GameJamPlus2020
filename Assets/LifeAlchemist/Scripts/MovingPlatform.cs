using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool activatePlatformWithSwitch = false;
    public bool stopAtLastPosition = false;
    public Transform platform;
    public List<Transform> platformPositions; //list of positions the platform will move to (in order)
    public List<float> platformStationaryTimeLength; //list of the amount of time the platform will stay at each platform position
    public float speed = 4.0f;

    private int currentIndex = 0;
    private bool resetPlatform = true;

    // Start is called before the first frame update
    void Start()
    {
        if (platformPositions.Count != platformStationaryTimeLength.Count)
        {
            Debug.LogError("The platform positions list count (" + platformPositions.Count + ") does not match the platform stationary time length list count (" + platformStationaryTimeLength.Count + ").");
        }

        if (activatePlatformWithSwitch)
        {
            resetPlatform = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (resetPlatform)
        {
            resetPlatform = false;
            StartCoroutine(moveToPosition(
                platform.position,
                platformPositions[currentIndex].position,
                getDuration(platform.position, platformPositions[currentIndex].position, speed
            )));
        }
    }

    public void activatePlatform()
    {
        resetPlatform = true;
    }

    private IEnumerator moveToPosition(Vector3 origin, Vector3 target, float duration)
    {
        float journey = 0f;
        while (journey <= duration)
        {
            journey = journey + Time.deltaTime;
            float percent = Mathf.Clamp01(journey / duration);
            
            platform.position = Vector3.Lerp(origin, target, percent);
            yield return null;
        }
        yield return new WaitForSeconds(platformStationaryTimeLength[currentIndex]);
        incrementCurrentgoalPosition();
        resetPlatform = true;
    }

    private void incrementCurrentgoalPosition()
    {
        if (currentIndex == platformPositions.Count - 1)
        {
            currentIndex = 0;
            if (stopAtLastPosition)
            {
                this.enabled = false;
            }
        }
        else
        {
            currentIndex++;
        }
    }

    private float getDuration(Vector3 position1, Vector3 position2, float speed)
    {
        return Vector3.Distance(position1, position2) / speed;
    }
}
