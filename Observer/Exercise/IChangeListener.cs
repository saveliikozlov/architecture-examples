using System;

namespace Observer.Exercise;

public interface IChangeListener
{
    public void OnProgressChanged(int percentage);
}