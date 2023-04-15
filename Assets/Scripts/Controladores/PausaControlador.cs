using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe controladora que permite que acontecam varias acoes quando colocamos o jogo em pausa
/// ou quando queremos continuar a jogar.
/// </summary>
public class PausaControlador : MonoBehaviour
{
    private bool paused = false;
    private void Update()
    {
        //Tecla para colocar o jogo em pausa / continuar.
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        //Encontrar todos os componentes do tipo IPausable e chamalos.
        paused = !paused;
        foreach(IPausable pausable in ComponentFinder.Find<IPausable>())
        {
            pausable.OnPause(paused);
        }
    }
}
