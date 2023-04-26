using Assets.Scripts.Controladores.GUI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GUIPalcoPainel : MonoBehaviour
{
    private static GameObject palcoPainel;

    private static Text projetoTexto;
    private static Transform painelTransform;
    private static GameObject botaoGenerico;

    //TODO: Melhorar isto, nao abrir automaticamente talvez, o player tem que clicar no Enter ou E para abrir este painel
    // e nesse ponto o player fica parado e o rato desbloqueia para se poder interagir com o painel

    public static void Abrir()
    {
        if (palcoPainel == null)
        {
            palcoPainel = GUIControlador.instancia.palcoPainel;
            if (palcoPainel == null)
            {
                Debug.LogError("ERRO: Nao da para abrir o painel do palco, porque nao esta definido no GUIControlador");
                return;
            }
            projetoTexto = palcoPainel.transform.GetChild(1).GetComponent<Text>();
            painelTransform = palcoPainel.transform.GetChild(3);
            botaoGenerico = GUIControlador.instancia.botaoGenerico;
        }

        palcoPainel.SetActive(true);
        if (ProjetoControlador.instancia.ExisteProjeto())
        {
            projetoTexto.text = "Projeto atual: "+ProjetoControlador.instancia.GetProjetoNome();
        }
        else
        {
            projetoTexto.text = "Projeto atual: NENHUM";
        }
        InserirOpcoes();
    }

    private static void InserirOpcoes()
    {
        if (!ProjetoControlador.instancia.ExisteProjeto())
        {
            CriarBotao("Criar Projeto", delegate
            {
                GUIJanelaTexto.AbrirJanela("Nome do projeto", (obj, txt) =>
                {
                    if (txt.Trim().Length==0)
                    {
                        Debug.LogError("Nome invalido para criar um projeto");
                    }
                    ProjetoControlador.instancia.CriarProjeto(txt.Trim());
                });
            });
        }
        else
        {
            CriarBotao("Criar Novo Artista", delegate
            {
                GameObject go = Instantiate(UtilsController.instancia.artistaPrefab);
                RaycastControlador.instancia.SetColocarObjeto(go);
            });
        }
    }

    private static void CriarBotao(string texto, UnityAction acaoClick)
    {
        GameObject obj = Instantiate(botaoGenerico, painelTransform);
        obj.transform.GetChild(0).GetComponent<Text>().text = texto;
        obj.GetComponent<Button>().onClick.AddListener(acaoClick);
    }

    public static void Fechar()
    {
        for(int i = 0; i < painelTransform.transform.childCount; i++)
        {
            Destroy(painelTransform.transform.GetChild(i).gameObject);
        }
        palcoPainel.SetActive(false);
    }
}
