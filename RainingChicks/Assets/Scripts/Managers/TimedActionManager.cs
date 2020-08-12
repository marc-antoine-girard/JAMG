﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedAction
{
    public delegate void ActionDelegate();

    private readonly TimedActionManager timeManager;

    private float timeLeft;
    private readonly ActionDelegate function;


    public TimedAction(ActionDelegate function, float timer)
    {
        timeManager = TimedActionManager.Instance;

        this.function = function;
        this.timeLeft = timer;
    }

    public void Refresh(float deltatime)
    {
        //Reduce timer
        DecreaseTimer(deltatime);
        //Check if function should be called
        if (timeLeft <= 0)
        {
            function.Invoke();
            timeManager?.RemoveTimedAction(this);
        }
    }

    private void DecreaseTimer(float deltatime)
    {
        timeLeft -= deltatime;
    }
}

public class TimedActionManager
{
    #region Singleton

    private TimedActionManager()
    {
    }

    private static TimedActionManager instance;

    public static TimedActionManager Instance
    {
        get { return instance ?? (instance = new TimedActionManager()); }
    }

    #endregion

    private HashSet<TimedAction> actions;
    private HashSet<TimedAction> toAddActions;
    private HashSet<TimedAction> toRemoveActions;

    public void PreInitialize()
    {
        actions = new HashSet<TimedAction>();
        toAddActions = new HashSet<TimedAction>();
        toRemoveActions = new HashSet<TimedAction>();
    }

    public void Refresh()
    {
        float deltaTime = Time.deltaTime;

        //Update all actions
        foreach (TimedAction action in actions)
        {
            action.Refresh(deltaTime);
        }    

        //Removed used actions
        CleanActionLists();
        AddActions();
    }

    public void AddTimedAction(TimedAction action)
    {
        toAddActions.Add(action);
    }

    public void RemoveTimedAction(TimedAction action)
    {
        toRemoveActions.Add(action);
    }

    private void AddActions()
    {
        foreach (TimedAction action in toAddActions)
        {
            actions.Add(action);
        }

        toAddActions.Clear();
    }

    private void CleanActionLists()
    {
        foreach (TimedAction action in toRemoveActions)
        {
            actions.Remove(action);
        }

        toRemoveActions.Clear();
    }
}