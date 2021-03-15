using UnityEngine;
using UnityEngine.InputSystem;

public enum SeeColor
{
    NONE,
    BLUE,
    GREEN,
    RED,
    YELLOW
}
public class ColorManager : MonoBehaviour
{
    [SerializeField]
    private SeeColor currentSeeColor = SeeColor.NONE;

    [SerializeField]
    private InputActionReference colorChangeControl;

    private bool changingColors = false;
    public LayerMask[] colorCullMasks;
    // Start is called before the first frame update
    void Start()
    {
        colorChangeControl.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        changeColor();
    }

    private void changeColor()
    {
        if(colorChangeControl.action.ReadValue<float>() > 0)
        {
            if (currentSeeColor.Equals(SeeColor.YELLOW))
                currentSeeColor = SeeColor.NONE;
            else
                currentSeeColor++;
            changingColors = true;
        }
        else if(colorChangeControl.action.ReadValue<float>() < 0)
        {
            if (currentSeeColor.Equals(SeeColor.NONE))
                currentSeeColor = SeeColor.YELLOW;
            else
                currentSeeColor--;
            changingColors = true;
        }


        if (changingColors)
        {
            switch (currentSeeColor)
            {
                case SeeColor.BLUE:
                    Camera.main.cullingMask = colorCullMasks[1];
                    break;

                case SeeColor.GREEN:
                    Camera.main.cullingMask = colorCullMasks[2];
                    break;

                case SeeColor.RED:
                    Camera.main.cullingMask = colorCullMasks[3];
                    break;

                case SeeColor.YELLOW:
                    Camera.main.cullingMask = colorCullMasks[4];
                    break;

                default:
                    Camera.main.cullingMask = colorCullMasks[0];
                    break;
            }
            changingColors = false;
        }
    }
}
