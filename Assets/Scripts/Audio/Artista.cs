using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using UnityEngine;
using Audio.Config;
using Controladores;

namespace Audio
{
    public class Artista : MonoBehaviour, IGravavelMusica
    {
        public string nomeArtista;

        public List<InstrumentoConfiguracao> instrumentosConfiguracoes;

        private List<Instrumento> objinstrumentos;

        private void Start()
        {
            objinstrumentos = new List<Instrumento>();
            if (instrumentosConfiguracoes == null)
            {
                instrumentosConfiguracoes = new List<InstrumentoConfiguracao>();
            }

            foreach (var instrumento in instrumentosConfiguracoes)
            {
                ProcessarConfiguracao(instrumento);
            }
        }

        public void AdicionarConfiguracao(InstrumentoConfiguracao configuracao)
        {
            instrumentosConfiguracoes.Add(configuracao);
            ProcessarConfiguracao(configuracao);
        }

        private void ProcessarConfiguracao(InstrumentoConfiguracao instrumento)
        {
            //Criacao do movimentoSom
            string parteCorpo = instrumento.parteCorpo;

            GameObject parte = UtilsController.instancia.EncontrarObjetoChild(transform, parteCorpo);

            if (parte == null)
            {
                Debug.LogError("ERRO: NAO ENCONTROU A PARTE DO CORPO " + parteCorpo + " PARA CRIAR O INSTRUMENTO");
                return;
            }

            Instrumento inst = parte.AddComponent<Instrumento>();
            MovimentoSom movimento = parte.AddComponent<MovimentoSom>();

            inst.movimento = movimento;

            objinstrumentos.Add(inst);

            //Transformacoes dos ossos do personagem
            foreach (var config in instrumento.transformacoesOssos)
            {
                GameObject osso = UtilsController.instancia.EncontrarObjetoChild(transform, config.nomeParte);

                if (osso == null)
                {
                    Debug.LogError("ERRO: NAO ENCONTROU A PARTE DO CORPO " + config.nomeParte + " PARA RODAR O OSSO");
                    continue;
                }

                osso.transform.localEulerAngles = config.rotacaoLocal;
            }

            //Instanciar objetos        

            foreach (var config in instrumento.configuracoesInstanciacao)
            {
                parte = null;
                if (config.nomeParente.Length != 0)
                {
                    parteCorpo = config.nomeParente;
                    parte = UtilsController.instancia.EncontrarObjetoChild(transform, parteCorpo);

                    if (parte == null)
                    {
                        Debug.LogError("ERRO: NAO ENCONTROU A PARTE DO CORPO " + parte + " PARA INSTANCIAR O OBJETO");
                        continue;
                    }
                }

                GameObject obj = Instantiate(config.objeto);

                if (parte == null)
                {
                    obj.transform.position = config.posicaoLocal;
                    obj.transform.eulerAngles = config.rotacaoLocal;
                }
                else
                {
                    obj.transform.SetParent(parte.transform, true);
                    obj.transform.localPosition = config.posicaoLocal;
                    obj.transform.localEulerAngles = config.rotacaoLocal;
                }
            }

            OnCarregouInstrumento?.Invoke(this, inst);
        }

        public void OnGravar(string caminho)
        {
            //TODO: implementar isto claro, usar uma cena para gravar / carregar facilmente como JSON ou assim
            Debug.Log("Implementar save");
        }

        public EventHandler<Instrumento> OnCarregouInstrumento;
    }
}