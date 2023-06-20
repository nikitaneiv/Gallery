using UnityEngine;

public class OrientationSetter : MonoBehaviour
{
    public enum Orientation
    {
        Any,
        Portrait,
    }

    public Orientation ScreenOrientation;

    private void Start()
    {
        Application.targetFrameRate = 60;
        switch (ScreenOrientation)
        {
            case Orientation.Any:
                Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;
                
                Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
                break;
            
            case Orientation.Portrait:
                // Force screen to orient right, then switch to Auto
                Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
                Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;
                
                Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = false;
                break;
        }

        Destroy(gameObject);
    }
}
