using UnityEngine;

namespace Controladores
{
    public class ColocarObjetoControlador : MonoBehaviour 
    {
        private GameObject colocarObjeto;

        public static ColocarObjetoControlador instancia;

        private Camera camara;
        private RaycastHit hit;
        private Vector3 hitPos;

        private void Start()
        {
            instancia = this;
            camara = RaycastControlador.instancia.camara;
        }

        private void FixedUpdate()
        {
            if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, 10f))
            {
                hitPos = hit.point;
            }
        }

        private void Update()
        {
            if (colocarObjeto != null)
            {
                bool button0 = Input.GetMouseButtonDown(0);
                bool button1 = Input.GetMouseButtonDown(1);

                colocarObjeto.transform.position = Vector3.Lerp(colocarObjeto.transform.position, hitPos, 6f * Time.deltaTime);
                if (button0)
                {
                    LimparColocarObjeto();
                }
                else if (button1)
                {
                    Destroy(colocarObjeto);
                    LimparColocarObjeto();
                }
            }
        }

        public void SetColocarObjeto(GameObject go)
        {
            colocarObjeto = go;
        }

        public void LimparColocarObjeto()
        {
            colocarObjeto = null;
        }
    }
}