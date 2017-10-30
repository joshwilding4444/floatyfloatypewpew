using System;
using serverMessage.serverMessage;
namespace lobbyServer
{
    public class clientPlayer
    {
        public String playerName 
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
            }
        
        }
        public clientPlayer( serverMessage initialClientMessage )
        {
            //extract the player name
            //set the value of variable playerName
            //to the input value
        }
        public bool hasJoinedGame 
        {
            get
            {
                return hasJoinedGame;
            }
            set
            {
                hasJoinedGame = value;
            }
        }
        public bool playerHasRequestedJoin 
        {
            get 
            {
                return playerHasRequestedJoin;
            }
            set
            {
                playerHasRequestedJoin = value;
            }
        }
        public bool playerHasRequestedLeave 
        {
            get
            {
                return playerHasRequestedLeave;
            }
            set
            {
                playerHasRequestedLeave = value;
            }
        }
        public serverMessage SendIsReady() 
        {
            //create an isReady message
            //send an isReady message
        }
    }
    public class lobbyGame
    {
        public clientPlayer[] associatedPlayers;
        public bool isActive;
        public bool isOpen;
        public lobbyGame()
        {
            associatedPlayers = null;
            isActive = false;
            isOpen = true;
        }
        public void playerJoinGame( clientPlayer newPlayer ) 
        {
            foreach( clientPlayer p in associatedPlayers )
            {
                if (newPlayer == p)
                {
                    return; //player is already in game
                }
            }
            associatedPlayers.SetValue(newPlayer, associatedPlayers.GetUpperBound(1) + 1);
        }
    }
    public class lobbyServer
    {
        public clientPlayer[] totalAssociatedPlayers;
        public lobbyGame[] gamesInLobby;
        public void newLobbyPlayer(clientPlayer newPlayer)
        {
            foreach ( clientPlayer p in totalAssociatedPlayers )
            {
                if ( newPlayer == p )
                {
                    return; //The player already exists
                }
            }
            totalAssociatedPlayers.SetValue( newPlayer, totalAssociatedPlayers.GetUpperBound(1) + 1);
        }
            
        public lobbyServer()
        {
            totalAssociatedPlayers = null;
            //Create two new instances of lobbygame
            lobbyGame firstGame = new lobbyGame();
            lobbyGame secondGame = new lobbyGame());
            gamesInLobby.SetValue(firstGame, gamesInLobby.GetUpperBound(1) + 1);
            gamesInLobby.SetValue(secondGame, gamesInLobby.GetUpperBound(1) + 1);
        }
    }
}
