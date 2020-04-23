using UnityEngine;
using Mirror;

[AddComponentMenu("")]
public class NetworkManagerLBS : NetworkManager
{
    public Transform spawnPlayerOne;
    public Transform spawnPlayerTwo;
    public Sprite spritePlayerOne;
    public Sprite spritePlayerTwo;

    private GameObject ball;
    private GameObject playerOne;
    private GameObject playerTwo;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        // add player at correct spawn position
        if (numPlayers == 0)
        {
            playerOne = Instantiate(playerPrefab, spawnPlayerOne.position, spawnPlayerOne.rotation);
            playerOne.GetComponent<SpriteRenderer>().sprite = spritePlayerOne;
            NetworkServer.AddPlayerForConnection(conn, playerOne);
        }
        else if (numPlayers == 1)
        {
            playerTwo = Instantiate(playerPrefab, spawnPlayerTwo.position, spawnPlayerTwo.rotation);
            playerTwo.GetComponent<SpriteRenderer>().sprite = spritePlayerTwo;
            NetworkServer.AddPlayerForConnection(conn, playerTwo);
        }

        // spawn ball if two players
        if (numPlayers == 2)
        {
            ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ball"));
            NetworkServer.Spawn(ball);
        }
    }


    public override void OnServerDisconnect(NetworkConnection conn)
    {
        // destroy ball
        if (ball != null)
            NetworkServer.Destroy(ball);

        // call base functionality (actually destroys the player)
        base.OnServerDisconnect(conn);
    }
}
