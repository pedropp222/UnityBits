using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface ICarregarEvent
{
    void OnCarregouAudio(AudioClip clip, string cam);
}
