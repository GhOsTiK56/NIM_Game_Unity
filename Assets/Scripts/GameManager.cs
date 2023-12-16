using TMPro;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    // ������ �� TextMeshProUGUI ��� ����������� ��������� � ������
    public TextMeshProUGUI victoryText;

    // ����� ��� ���������� ���������� ����
    private bool playerTurn = true;
    private bool gameOver = false;
    private bool computerIsPlaying = false;
    private bool playerMadeMove = false;

    // ���������� ��� ������� �������
    private void Start()
    {
        // ������ �������� �������� �����
        StartCoroutine(GameLoop());
    }

    // �������� �������� �� ���� �� �����
    private bool AreCubesRemaining()
    {
        return GameObject.FindWithTag("Cube") != null;
    }

    // ������� ���� � ���� ��������
    private System.Collections.IEnumerator GameLoop()
    {
        while (true)
        {
            yield return null;

            // �������� ���������� ���� ��� ���������� �����
            if (!AreCubesRemaining() && !gameOver)
            {
                HandleGameEnd();
            }

            // ��� ������
            if (playerTurn)
            {
                yield return StartCoroutine(PlayerTurn());
            }
            // ��� ���������� ����� ����, ��� ����� ������ ���
            else if (playerMadeMove)
            {
                yield return StartCoroutine(ComputerTurn());
                playerMadeMove = false;
            }

            // ����� ���� ����� ������� � �����������
            playerTurn = !playerTurn;
        }
    }

    // ��� ������ � ���� ��������
    private System.Collections.IEnumerator PlayerTurn()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        // �������� ������� ����� ������ ����, ���� ��������� �� ������ ���� ���
        while (!(Input.GetMouseButtonDown(0) && !computerIsPlaying))
            yield return null;

        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        // ��������� ����� �� ��� � ��� �����������
        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Cube"))
        {
            Destroy(hit.collider.gameObject);
            playerMadeMove = true;
        }
    }

    // ��� ���������� � ���� ��������
    private System.Collections.IEnumerator ComputerTurn()
    {
        computerIsPlaying = true;

        // �������� ���������� ������� ����� ����� ����������
        yield return new WaitForSeconds(2f);

        // ��������� ������ ���� ����� �� �����
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

        if (cubes.Length > 0)
        {
            // ����� ���������� ���� ��� �����������
            GameObject randomCube = cubes[Random.Range(0, cubes.Length)];
            Debug.Log($"��������� ������ ��� ��� �����������: {randomCube.name}");
            Destroy(randomCube);
        }

        computerIsPlaying = false;
    }

    // ����������� ��������� � ������
    private void DisplayVictoryMessage()
    {
        victoryText.gameObject.SetActive(true);
        victoryText.text = playerTurn ? "��������� �������!" : "����� �������!";
        StartCoroutine(HideVictoryMessageAfterDelay());
    }

    // �������� ����� �������� ��������� � ������
    private System.Collections.IEnumerator HideVictoryMessageAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        victoryText.gameObject.SetActive(false);
    }

    // ��������� ���������� ����
    private void HandleGameEnd()
    {
        Debug.Log(playerTurn ? "��������� �������!" : "����� �������!");
        DisplayVictoryMessage();
        gameOver = true;
    }

    // ����������� ����� � ������ ������
    private void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 6, Screen.height / 2 - 6, 12, 12), "*");
    }
}