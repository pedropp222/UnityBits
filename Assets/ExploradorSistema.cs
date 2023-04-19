using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ExploradorSistema : MonoBehaviour
{
    private string lastPath;

    public Sprite iconePasta;
    public Sprite iconeFicheiro;

    public GameObject elementoBotao;

    public GameObject selecionarBotao;

    public InputField caminhoTexto;

    public GameObject conteudoExplorador;

    public Text selecionadoText;

    private string caminhoSelecionado = "";

    private Jogador player;

    private TocadorAudio referencia;

    public void Mostrar(TocadorAudio referencia)
    {
        if (lastPath == null)
        {
            lastPath = "C:\\";
        }

        this.referencia = referencia;

        if (player == null)
        {
            player = FindAnyObjectByType<Jogador>();
        }
        
        player.SetMover(false);

        ApresentarListaElementos(lastPath);
    }

    public void Cancelar()
    {
        player.SetMover(true);
        gameObject.SetActive(false);
    }

    public void Selecionar()
    {
        Debug.Log("Musica selecionada: "+caminhoSelecionado);
        referencia?.AdicionarMusica(caminhoSelecionado);
        Cancelar();
    }

    private void ApresentarListaElementos(string caminho)
    {
        lastPath = caminho;

        while(conteudoExplorador.transform.childCount > 0)
        {
            DestroyImmediate(conteudoExplorador.transform.GetChild(0).gameObject);
        }

        string[] pastas = Directory.GetDirectories(lastPath);
        string[] ficheiros = Directory.GetFiles(lastPath);

        caminhoTexto.text = lastPath;

        if (lastPath.Length > 3)
        {
            CriarBotao(true, lastPath,true);
        }

        for(int i = 0; i < pastas.Length; i++)
        {
            CriarBotao(true, pastas[i]);
        }

        for (int i = 0; i < ficheiros.Length; i++)
        {
            if (ficheiros[i].EndsWith(".mp3") || ficheiros[i].EndsWith(".wav") || ficheiros[i].EndsWith(".ogg"))
            {
                CriarBotao(false, ficheiros[i]);
            }
        }
    }

    private void CriarBotao(bool pasta, string caminho, bool tras = false)
    {
        GameObject botao = Instantiate(elementoBotao, conteudoExplorador.transform);

        botao.transform.GetChild(0).GetComponent<Text>().text = tras?"../":caminho.Replace(lastPath,"").Replace("\\","");
        botao.transform.GetChild(1).GetComponent<Image>().sprite = pasta?iconePasta:iconeFicheiro;

        botao.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -10f - (conteudoExplorador.transform.childCount - 1) * 85f);
        conteudoExplorador.GetComponent<RectTransform>().sizeDelta = new Vector2(conteudoExplorador.GetComponent<RectTransform>().sizeDelta.x, (10f + (conteudoExplorador.transform.childCount  * 85f) + 10f));

        botao.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (pasta)
            {
                if (tras)
                {
                    ApresentarListaElementos(caminho.Substring(0,caminho.LastIndexOf('\\')));
                }
                else
                {
                    ApresentarListaElementos(caminho);
                }
            }
            else
            {
                caminhoSelecionado = caminho;
                selecionadoText.text = caminhoSelecionado;
                selecionarBotao.GetComponent<Button>().interactable = true;
            }
        });
    }

}