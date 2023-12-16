using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMenu : MonoBehaviour
{
    // ����������� ���������� ��� ������������ ��������� �����
    public static bool isPaused = false;

    // ������ �� ������ ���������� ���� �����
    public GameObject pauseMenuUI;

    // ���������� ��� ������� �����
    private void Start()
    {
        // ������������� ������ � ������ ������
        Cursor.lockState = CursorLockMode.Locked;
    }

    // ���������� ������ ����
    private void Update()
    {
        // ��������� ��������� ���������� ������� � ����������� �� ��������� �����
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // ��������� ������� ������� Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ���� ���� �� �����, ����������; ����� ��������� �� �����
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // ����� ��� ����������� ����
    public void Resume()
    {
        Debug.Log("����������");
        // ���������� ���������� �����
        pauseMenuUI.SetActive(false);
        // �������������� ������� � ����
        Time.timeScale = 1.0f;
        // ��������� ����� ����� � false
        isPaused = false;
    }

    // ����� ��� ���������� ���� �� �����
    public void Pause()
    {
        Debug.Log("�����");
        // ��������� ���������� �����
        pauseMenuUI.SetActive(true);
        // ���������� ������� � ���� �� ���� (�����)
        Time.timeScale = 0f;
        // ��������� ����� ����� � true
        isPaused = true;
    }

    // ����� ��� ��������� ������� ������ �����������
    public void ResumeButton()
    {
        // ����� ������ Resume ��� ����������� ����
        Resume();
    }

    // ����� ��� ����������� ������
    public void RestartLevel()
    {
        // ����� ����� ����� ����� ������������� �����
        isPaused = false;
        // �������� ������� ����� ��� ����������� ������
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // ����� ������ Resume ��� ����������� ���� ����� ������������ ������
        Resume();
    }

    // ����� ��� ��������� ������� ������ ������ �� ����
    public void QuitButton()
    {
        // ����� �� ����������
        Application.Quit();
    }

    // ����� ��� ��������� ������� ������ �������� � ������� ����
    public void MenuButton()
    {
        // �������� ����� "Menu"
        SceneManager.LoadScene("Menu");
    }
}