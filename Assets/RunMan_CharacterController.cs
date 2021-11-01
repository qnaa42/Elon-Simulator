using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GPC;

public class RunMan_CharacterController : BasePlayer2DPlatformCharacter
{
    public BaseSoundManager _soundControl;
    public Animator _RunManAnimator;
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
        allow_jump = true;
        allow_right = true;
        allow_left = true;

        _soundControl = GetComponent<BaseSoundManager>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (isOnGround && isRunning && !_RunManAnimator.GetCurrentAnimatorStateInfo(0).IsName("RunMan_Run"))
        {
            StartRunAnimation();
        }
    }
    public override void LateUpdate()
    {
        if (canControl)
            base.LateUpdate();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        _soundControl.PlaySoundByIndex(1);
        RunMan_GameManager.instance.PlayerFell();
    }
    public void StartRunAnimation()
    {
        isRunning = true;
        _RunManAnimator.SetTrigger("Run");
    }
    public override void Jump()
    {
        base.Jump();
        _soundControl.PlaySoundByIndex(0);
        _RunManAnimator.SetTrigger("Jump");
    }
}
