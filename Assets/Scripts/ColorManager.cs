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
    public bool[] unlockedColors = {true, false, false, false, false};

    [SerializeField]
    private InputActionReference colorChangeControl;

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

    public void unlockColor(SeeColor colorToUnlock)
    {
        unlockedColors[(int)colorToUnlock] = true;
    }

    public void lockColor(SeeColor colorToLock)
    {
        unlockedColors[(int)colorToLock] = false;
    }

    private void changeColor()
    {
        int colorChangeValue;

        if(colorChangeControl.action.ReadValue<float>() > 0)
            colorChangeValue = 1;

        else if(colorChangeControl.action.ReadValue<float>() < 0)
            colorChangeValue = -1;

        else
            colorChangeValue = 0;

        if (colorChangeValue != 0)
        {
            bool valid = false;
            do
            {
                currentSeeColor += colorChangeValue;

                if ((int)currentSeeColor > (int)SeeColor.YELLOW)
                    currentSeeColor = SeeColor.NONE;

                else if ((int)currentSeeColor < (int)SeeColor.NONE)
                    currentSeeColor = SeeColor.YELLOW;

                if (unlockedColors[(int)currentSeeColor])
                {
                    valid = true;
                }
            } while (!valid);
            GetComponent<PlayerController>().numColorSwaps++;
            Camera.main.cullingMask = colorCullMasks[(int)currentSeeColor];
        }
    }
}
