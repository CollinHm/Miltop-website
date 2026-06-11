using UnityEngine;

public class PipeManager : MonoBehaviour
{
    [SerializeField] private GameObject[] pipes = new GameObject[4];

    public void UpdatePipes(int index)
    {
        for (int i = 0; i < index; i++)
        {
            if (i >= 1) pipes[0].SetActive(true);
            if (i >= 2) pipes[1].SetActive(true);
            if (i >= 3) pipes[2].SetActive(true);
            if (i >= 4) pipes[3].SetActive(true);
        }
    }
}
