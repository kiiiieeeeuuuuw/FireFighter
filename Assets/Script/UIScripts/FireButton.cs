using UnityEngine;

namespace Assets.Script.UIScripts
{
    public class FireButton : MonoBehaviour
    {
        public ParticleSystem ButtonIdleFire;
        public ParticleSystem ButtonHoverFire;

        public void HoverEnterButton()
        {
            ButtonIdleFire.Stop();
            ButtonHoverFire.Play();
            Debug.Log("hover enter");
        }

        public void HoverLeaveButton()
        {
            ButtonHoverFire.Stop();
            ButtonIdleFire.Play();
            Debug.Log("hover leave");
        }
    }
}
