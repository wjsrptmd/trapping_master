using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girl : MonoBehaviour
{
    public int kickAnimeTimeLimit = 100;

    private Animator anim;
    private GameObject ball;

    private float limit_diff_x = 1;

    private const string kKick = "kick";
    private const string kRun = "run";
    private const string kIdle = "idle";

    private const string kGirlKick = "girl_kick";
    private const string kGirlIdle = "girl_idle";
    private const string kGirlRun = "girl_run";

    private int kickAnimeTime = 0;

    private float speed = 1;

    bool IsFinishKick()
    {
        if(kickAnimeTime > kickAnimeTimeLimit)
        {
            kickAnimeTime = 0;
        }

        return kickAnimeTime == 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private Vector3 GetMoveDir()
    {
        Vector3 girl_pos = transform.localPosition;
        Vector3 ball_pos = ball.transform.localPosition;

        float diff = ball_pos.x - girl_pos.x;
        return new Vector3(diff, 0, 0);
    }

    private bool IsMove()
    {
        float diff = GetMoveDir().x;
        return diff * diff > limit_diff_x * limit_diff_x;
    }

    private void Move()
    {
        Vector3 dir = GetMoveDir();
        transform.Translate(dir.normalized * speed * Time.deltaTime);

    }

    public void SetBall(GameObject obj)
    {
        ball = obj;
    }

    void DoAnimation(string anime)
    {
        if(anime == kKick)
        {
            anim.SetTrigger(anime);
        }
        else
        {
            anim.SetBool(kIdle, anime == kIdle);
            anim.SetBool(kRun, anime == kRun);
        }
    }

    // Update is called once per frame
    void Update()
    {
        string animation = kIdle;
        if (!IsFinishKick() || Input.GetKeyDown(KeyCode.Space))
        {
            animation = kKick;
            kickAnimeTime++;
        }
        else
        {
            if (IsMove())
            {
                Move();
                animation = kRun;
            }
        }

        DoAnimation(animation);
    }
}
