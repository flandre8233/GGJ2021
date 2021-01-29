using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Starter : SingletonMonoBehavior<Starter>, IExitStatus
{
    protected Status ExitStatus;
    protected abstract void Start();
    public abstract void ToNextStatus();
}

public interface IExitStatus
{
    void ToNextStatus();
}