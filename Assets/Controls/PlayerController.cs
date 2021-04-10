using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    static PlayerController instance;

    [SerializeField]
    private InputActionReference movementControl;

    [SerializeField]
    private InputActionReference jumpControl;

    [SerializeField]
    private InputActionReference respawnControls;

    [SerializeField]
    private InputActionReference pauseControls;

    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private Vector3 playerVelocity;

    [SerializeField]
    private Vector3 prevPlayerVelocity;

    [SerializeField]
    private bool groundedPlayer;

    [SerializeField]
    private float playerSpeed = 2.0f;

    [SerializeField]
    private float jumpHeight = 1.0f;

    [SerializeField]
    private float gravityValue = -9.81f;

    [SerializeField]
    private float rotationSpeed = 4.0f;

    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private float bounceVelocityY = 0.0f;

    [SerializeField]
    private int score = 0;

    [SerializeField]
    private TMPro.TextMeshProUGUI scoreText;

    [SerializeField]
    private bool respawning = false;

    [SerializeField]
    private Vector3 respawnPoint;

    [SerializeField]
    private ParticleSystem particleSystem;

    private bool gameIsPaused = false;
    [SerializeField]
    private GameObject gamePausedUI;

    public int numJumps = 0;
    public float distanceTraveled = 0.0f;
    public int numColorSwaps = 0;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
            respawn(respawnPoint);
            particleSystem = GetComponent<ParticleSystem>();
            scoreText.text = score.ToString();
        }
        else
            Destroy(gameObject);

    }

    private void OnEnable()
    {
        if (instance == null)
        {
            movementControl.action.Enable();
            jumpControl.action.Enable();
            respawnControls.action.Enable();
            pauseControls.action.Enable();
        }
    }
    private void OnDisable()
    {
        if (instance == null)
        {
            movementControl.action.Disable();
            jumpControl.action.Disable();
            respawnControls.action.Disable();
            pauseControls.action.Disable();
        }
    }

    void Update()
    {
        if(pauseControls.action.triggered)
        {
            pauseGame();
        }

        if(respawnControls.action.triggered)
        {
            respawn(new Vector3(-12.0f, 5.0f, 0.0f));
        }

        if (respawning)
        {
            transform.position = respawnPoint;
            StartCoroutine(resetIsSpawning(0.5f));
        }
        else
        {
            playerVelocity.y += gravityValue * Time.deltaTime;

            if (groundedPlayer && !(playerVelocity.y > 1.0f))
                playerVelocity.y = -1.0f;
            else
                bounceVelocityY = playerVelocity.y;

            Vector2 movement = movementControl.action.ReadValue<Vector2>();
            Vector3 move = new Vector3(movement.x, 0, movement.y);
            move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
            move.y = 0.0f;

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            // Changes the height position of the player..
            if (jumpControl.action.triggered && groundedPlayer)
            {
                numJumps++;
                playerVelocity.y += getJumpPower();
            }

            controller.Move((move * playerSpeed + playerVelocity) * Time.deltaTime);

            groundedPlayer = controller.isGrounded;
            if (movement != Vector2.zero)
            {
                float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg * cameraTransform.eulerAngles.y;
                Quaternion rotation = Quaternion.Euler(0.0f, targetAngle, 0.0f);

                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            }
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        respawn(respawnPoint);
    }

    public void saveGame()
    {
        PlayerPrefs.SetFloat("PlayerXPos", transform.position.x);
        PlayerPrefs.SetFloat("PlayerYPos", transform.position.y);
        PlayerPrefs.SetFloat("PlayerZPos", transform.position.z);
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().ToString());

        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.SetInt("PlayerNumJumps", numJumps);
        PlayerPrefs.SetFloat("PlayerDistanceTraveled", distanceTraveled);
        PlayerPrefs.SetInt("PlayerNumColorSwaps", numColorSwaps);

        ColorManager cm = GetComponent<ColorManager>();
        PlayerPrefs.SetInt("UnlockedBlueColor", (cm.unlockedColors[1] ? 1 : 0));
        PlayerPrefs.SetInt("UnlockedRedColor", (cm.unlockedColors[2] ? 1 : 0));
        PlayerPrefs.SetInt("UnlockedGreenColor", (cm.unlockedColors[3] ? 1 : 0));
        PlayerPrefs.SetInt("UnlockedYellowColor", (cm.unlockedColors[4] ? 1 : 0));
    }

    public void loadGame()
    {
        if (PlayerPrefs.HasKey("PlayerNumJumps"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("CurrentLevel"));

            pauseGame();
            respawn(new Vector3(PlayerPrefs.GetFloat("PlayerXPos"), PlayerPrefs.GetFloat("PlayerYPos"), PlayerPrefs.GetFloat("PlayerZPos")));

            score = PlayerPrefs.GetInt("PlayerScore");
            numJumps = PlayerPrefs.GetInt("PlayerNumJumps");
            distanceTraveled = PlayerPrefs.GetFloat("PlayerDistanceTraveled");
            numColorSwaps = PlayerPrefs.GetInt("PlayerNumColorSwaps");

            ColorManager cm = GetComponent<ColorManager>();
            cm.unlockedColors[1] = PlayerPrefs.GetInt("UnlockedBlueColor") == 1 ? true : false; 
            cm.unlockedColors[2] = PlayerPrefs.GetInt("UnlockedRedColor") == 1 ? true : false;
            cm.unlockedColors[3] = PlayerPrefs.GetInt("UnlockedGreenColor") == 1 ? true : false;
            cm.unlockedColors[4] = PlayerPrefs.GetInt("UnlockedYellowColor") == 1 ? true : false;
        }
        // else no save file
    }

    public void pauseGame()
    {
        if(gameIsPaused)
        {
            gamePausedUI.SetActive(false);
            gameIsPaused = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            gamePausedUI.SetActive(true);
            gameIsPaused = true;
            Time.timeScale = 0.0f;
        }
    }

    public void increaseScore(int scoreToAdd)
    {
        particleSystem.Play();
        
        score += scoreToAdd;
        scoreText.text = score.ToString();

        if(score >= 1500)
        {
            SceneManager.LoadScene("GameWinScene");
        }
    }

    public void respawn(Vector3 respawnPoint)
    {
        respawning = true;
        this.respawnPoint = respawnPoint;
    }

    private IEnumerator resetIsSpawning(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        respawning = false;
    }
    // Returns the bounce Velocity to use for bouncing, isn't affected by the constant gravity when colliding, won't get set to -1 if colliding with something
    public float getBounceVelocityY()
    {
        return bounceVelocityY;
    }

    // Sets the Velocity, and moves the controller with it
    public void setVelocity(Vector3 newVelocity)
    {
        playerVelocity = newVelocity;
        groundedPlayer = false;
    }

    public Vector3 getPreviousPlayerVelocity()
    {
        return prevPlayerVelocity;
    }

    public Vector3 getVelocity()
    {
        return playerVelocity;
    }

    public float getJumpPower()
    {
        return Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    }

    public void setJumpHeight(float newJumpHeight)
    {
        jumpHeight = newJumpHeight;
    }

    public float getJumpHeight()
    {
        return jumpHeight;
    }
    public void setPlayerSpeed(float newPlayerSpeed)
    {
        playerSpeed = newPlayerSpeed;
    }

    public float getPlayerSpeed()
    {
        return playerSpeed;
    }

    public IEnumerator resetPlayerSpeed(float previousPlayerSpeed)
    {
        bool reset = false;
        while(!reset)
        {
            if (groundedPlayer)
            {
                playerSpeed = previousPlayerSpeed;
                reset = true;
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public void resetJumpHeight(float previousJumpHeight)
    {
        jumpHeight = previousJumpHeight;
    }
}
