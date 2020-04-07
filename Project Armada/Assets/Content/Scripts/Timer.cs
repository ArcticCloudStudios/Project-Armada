using UnityEngine;

public class Timer
{
    public enum TimerDirection
    {
        Forward,
        Reverse
    };

    // Last Timer Start Time
    private float StartTime;
    // Timer Completion Time
    public float Length;

    // Timer Minimum Output Value
    private float MinValue;
    // Timer Maximum Output Value
    private float MaxValue;

    // Last Value of Timer when Running
    private float LastValue;
    // Direction that the Timer is moving
    private TimerDirection Direction = TimerDirection.Forward;
    // Whether or not the Timer is still running
    private bool Running = false;

    public Timer(float length, float start = 0.0f, float end = 1.0f)
    {
        Length = length;
        LastValue = 0.0f;
        MinValue = start;
        MaxValue = end;
    }

    public void Reset()
    {
        Running = false;
        LastValue = 0.0f;
    }

    public void Rewind(float amt)
    {
        StartTime += amt * Length;
        StartTime = Mathf.Min(Time.time, StartTime);
    }

    public void Start(TimerDirection direction = TimerDirection.Forward)
    {
        if (Running)
        {
            // No remap
            LastValue = GetValue(false);
        }
        Direction = direction;
        StartTime = Time.time;
        Running = true;
    }

    public void Stop()
    {
        LastValue = GetValue();
        Running = false;
    }

    public bool IsRunning()
    {
        return Running;
    }

    public float GetValue(bool remap = true)
    {
        if (Running)
        {
            float t = Mathf.Clamp01((Time.time - StartTime) / Length);
            float v_shift;
            if (Direction == TimerDirection.Forward)
            {
                float v_unshift = Mathf.Lerp(0.0f, 1.0f, t);
                v_shift = Mathf.Clamp01(v_unshift + LastValue);
                if (v_shift >= 1.0f)
                {
                    Running = false;
                    LastValue = v_shift;
                }
            }
            else if (Direction == TimerDirection.Reverse)
            {
                float v_unshift = Mathf.Lerp(1.0f, 0.0f, t);
                v_shift = Mathf.Clamp01(v_unshift - (1.0f - LastValue));
                if (v_shift <= 0.0f)
                {
                    Running = false;
                    LastValue = v_shift;
                }
            }
            else
            {
                v_shift = 0.0f;
            }
            if (remap)
            {
                return Remap(v_shift);
            }
            else
            {
                return v_shift;
            }
        }
        else
        {
            if (remap)
            {
                return Remap(LastValue);
            }
            else
            {
                return LastValue;
            }
        }
    }

    private float Remap(float val)
    {
        return Mathf.Lerp(MinValue, MaxValue, val);
    }
}
