using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GPC;

public class RunMan_CharacterController : BasePlayer2DPlatformCharacter
{


    public bool isRunning;
    public BasePlayerStatsController _playerStats;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        isRunning = false;

        allow_right = true;
        allow_left = true;


    }

    // Update is called once per frame
 //   public void Update()
 //   {
 //       if (isRunning && !_RunManAnimator.GetCurrentAnimatorStateInfo(0).IsName("RunMan_Run"))
 //       {
//            StartRunAnimation();
//        }
 //   }
    public override void LateUpdate()
    {
        if (canControl)
            base.LateUpdate();
    }


   
}
