using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GPC;

[RequireComponent(typeof(BaseProfileManager))]

public class RunMan_GameManager : BaseGameManager
{
    public RunMan_UIManager _uiManager;
    public float runSpeed = 1f;
    public float distanceToSpawnPlatform = 20f;
    public bool isRunning;

    public Transform _platformPrefab;
    public RunMan_CharacterController _RunManCharacter;

    private float distanceCounter;


    public float playAreaTopY = -500f;
    public float playAreaBottomY = 500;
    public float platformStartX = 1000f;

    public static RunMan_GameManager instance { get; private set; }

    BaseUserManager _baseUserManager;

    public RunMan_GameManager()
    {
        instance = this;
    }
    private void Awake()
    {
        // ------------------------------------------------------
        // this code section isn't in the book, but it's provided to make
        // the game run without having to start it via the menu. It
        // is purely for test reasons. Basically, the game adds a player
        // to the BaseUserManager component in the menu. If you try to
        // run this scene from the core scene, that player hasn't been
        // added so the game would throw an error. We check here that
        // a player has been added and, if not, add one as needed
        if (_baseUserManager == null)
            _baseUserManager = GetComponent<BaseUserManager>();

        if (_baseUserManager.GetPlayerList().Count < 1) // get the player list from baseusermanager component and check players are in it
        {
            // reset baseusermanager
            _baseUserManager.ResetUsers();

            // add a new player to the game
            _baseUserManager.AddNewPlayer();
        }
        // ------------------------------------------------------
    }

    public void Start()
    {
        Debug.Log("SetTargetGameState=" + targetGameState);

        SetTargetState(Game.State.loaded);
    }
    public override void UpdateTargetState()
    {
        Debug.Log("TargetGameState=" + targetGameState);
        if (targetGameState == currentGameState)
            return;

        switch (targetGameState)
        {
            case Game.State.loaded:
                Loaded();
                break;

            case Game.State.gameStarting:
                GameStarting();
                StartGame();
                break;

            case Game.State.gameStarted:
                GameStarted();
                SetTargetState(Game.State.gamePlaying);
                break;

            case Game.State.gamePlaying:
                break;

            case Game.State.gameEnding:
                GameEnding();
                EndGame();
                break;

            case Game.State.gameEnded:
                GameEnded();
                break;        
        }
        currentGameState = targetGameState;
    }
    public override void Loaded()
    {
        base.Loaded();

             
 //       _uiManager.SetHighScore(GetComponent<BaseProfileManager>().GetHighScore());
//        _RunManCharacter._playerStats.SetScore(0);

        SetTargetState(Game.State.gameStarting);

    }
    void StartGame()
    {

        runSpeed = 0;
        Invoke("StartRunning", 2f);

    }
    void StartRunning()
    {

        isRunning = true;

        runSpeed = 1f;
        distanceCounter = 1f;
        SetTargetState(Game.State.gameStarted);

   //     _RunManCharacter.StartRunAnimation();

  //      InvokeRepeating("AddScore", 0.5f, 0.5f);
       

    }
    void EndGame()
    {

        isRunning = false;
        runSpeed = 0f;


        Invoke("ReturnToMenu", 4f);
        CancelInvoke("AddScore");

        SetTargetState(Game.State.gameEnded);
    //    if (GetComponent<BaseProfileManager>().SetHighScore(_RunManCharacter._playerStats.GetScore()) == true)
    //    {
    //        _uiManager.ShowGotHighScore();
    //    }

        //update final score UI
     //   _uiManager.SetFinalScore(_RunManCharacter._playerStats.GetScore());

    }

    void AddScore()
    {
    //    _RunManCharacter._playerStats.AddScore(1);
    }

    void ReturnToMenu()
    {
      //  SceneManager.LoadScene("runMan_menu");
    }

 //   public void PlayerFell()
 //   {
 //       SetTargetState(Game.State.gameEnding);
  //  }
    void SpawnPlatform()
    {
        runSpeed += 0.02f;
        distanceCounter = 0;
        float randomY = Random.Range(playAreaTopY, playAreaBottomY);
        Vector2 startPos = new Vector2(randomY, platformStartX);

        Instantiate(_platformPrefab, startPos, Quaternion.identity);
        distanceCounter = Random.Range(-0.5f, 0.25f);
    }
    void Update()
    {
        if (isRunning)
        {
            distanceCounter += (runSpeed * Time.deltaTime);
            if ((distanceCounter >= distanceToSpawnPlatform))
                SpawnPlatform();
            
        //    _uiManager.SetScore(_RunManCharacter._playerStats.GetScore());
        }
    }
    //set instance in this script's constructor
   

   
}
