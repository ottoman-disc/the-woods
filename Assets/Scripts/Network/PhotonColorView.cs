using Photon.Pun;
using UnityEngine;

namespace OttomanDisc
{
    [RequireComponent(typeof(PhotonView))]
    public class PhotonColorView : MonoBehaviour
    {
        PhotonView pv;
        ColorSetter cs;

        private void Awake()
        {
            pv = this.GetComponent<PhotonView>();
            cs = this.GetComponent<ColorSetter>();
        }

        private void OnEnable()
        {
            cs.OnSetColor += SendColor;
        }

        private void SendColor(Color color)
        {
            float[] colorInfo = { color.r, color.g, color.b };
            pv.RPC(nameof(RecieveColor), RpcTarget.Others, colorInfo);
        }

        [PunRPC]
        private void RecieveColor(float[] colorInfo)
        {
            Color color = new Color(colorInfo[0], colorInfo[1], colorInfo[2]);
            cs.SetColor(color);
        }

        private void OnDisable()
        {
            cs.OnSetColor -= SendColor;
        }
    }
}
