using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // ����� ��� ��������� ������� ������ ����
    public void PlayGame()
    {
        // �������� ����� "SampleScene"
        SceneManager.LoadScene("SampleScene");
    }

    // ����� ��� ��������� ������� ������ �� ����
    public void ExitGame()
    {
        // ����� ��������� � ������� � �������� ����
        Debug.Log("���� ���������");
        // ����� �� ����������
        Application.Quit();
    }
}