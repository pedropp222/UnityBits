using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Controladores.GUI
{
    public class GUIJanelaTexto
    {
        private static bool aberto;

        private static GameObject janelaModalTexto;

        private static Text descricaoTexto;
        private static InputField inputTexto;
        private static Button confirmarBotao;

        //TODO: Estas e outras janelas modais tem que tomar conta do teclado e rato. Por isso tem que bloquear o player enquanto
        //estes tipos de janelas tiverem abertas
        public static void AbrirJanela(string descricao, EventHandler<string> confirmarAcao)
        {
            if (aberto)
            {
                Debug.LogWarning("A janela modal de texto ja ta aberta");
                return;
            }

            if (janelaModalTexto == null)
            {
                janelaModalTexto = GUIControlador.instancia.janelaModalTexto;
                if (janelaModalTexto == null)
                {
                    Debug.LogError("ERRO. Nao e possivel abrir a janela porque ela nao esta definida no GUIControlador");
                    return;
                }
                descricaoTexto = janelaModalTexto.transform.GetChild(0).GetComponent<Text>();
                inputTexto = janelaModalTexto.transform.GetChild(1).GetComponent<InputField>();
                confirmarBotao = janelaModalTexto.transform.GetChild(2).GetComponent<Button>();
            }

            janelaModalTexto.SetActive(true);
            aberto = true;
            descricaoTexto.text = descricao;
            inputTexto.text = "";
            
            confirmarBotao.onClick.AddListener(delegate
            {
                confirmarAcao.Invoke(typeof(GUIJanelaTexto), inputTexto.text);
                FecharJanela();
            });
        }

        private static void FecharJanela()
        {
            confirmarBotao.onClick.RemoveAllListeners();
            janelaModalTexto.SetActive(false);
            aberto = false;
        }
    }
}
