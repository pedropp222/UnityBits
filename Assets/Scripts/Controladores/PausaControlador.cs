using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Outros;

/// <summary>
/// Classe controladora que permite que acontecam varias acoes quando colocamos o jogo em pausa
/// ou quando queremos continuar a jogar.
/// </summary>
namespace Controladores
{
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
            //TODO: depois encontrar uma cena melhor em vez de tar sempre a encontrar todos os objetos pausable
            paused = !paused;
            foreach (IPausable pausable in ComponentFinder.Find<IPausable>())
            {
                pausable.OnPause(paused);
            }
        }
    }
}