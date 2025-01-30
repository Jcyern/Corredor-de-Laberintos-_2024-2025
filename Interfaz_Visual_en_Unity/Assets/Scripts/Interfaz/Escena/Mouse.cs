
using Unity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class Mouse : MonoBehaviour
{
    public GameObject sound ;
    static AudioSource audio ;

    void Awake()
    {
        audio = sound.GetComponent<AudioSource>();
    }
    public static  void Audio_Click()
    {
        audio.Play();
    }
}