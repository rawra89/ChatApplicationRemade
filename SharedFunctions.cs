using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SharedFunctions;
public class User
{
	public string Name { get; }
	public string Nickname { get; set; }
	public string ID { get; }
	public DateTime timeJoined { get; }

	public TimeSpan UpdateTime()
	{
		return DateTime.Now - timeJoined;
	}
}


// Object to hold important server info
public class ServerInfo
{
	public string name { get; }
	public int maxUsers { get; }
	List<User> users;
	DateTime timeCreated;

	public ServerInfo( string _name, int _maxUsers, List<User> _users, DateTime _timeCreated )
	{
		name = _name;
		maxUsers = _maxUsers;
		users = _users;
		timeCreated = _timeCreated;
	}
}

// Keep track of who is sending what.
// Name, ID, then message.
public class MessageState
{
	public string owner;	// Who made this message?
	public string ID;		// What ID is it from? Send as string, will be parsed as uint64 later
	public string message;	// Message.
	public DateTime timeSent; // This should be modified by the server when sent.

	public MessageState()
	{
        owner = "";
		ID = "";
		message = "";
	}

	public MessageState( string _owner, string _ID, string _message )
	{
		owner = _owner + Shared.BREAKMSG;
		ID = _ID + Shared.BREAKMSG;
		message = _message + Shared.ENDMSG;
	}

	// Convert a string to a message state
	public MessageState( string msg )
	{
		string temp = "";
		UInt64 tmpID = 0;

		int i = 0;
		for ( i = 0; i < msg.Length; i++ )
		{
			temp += msg[i];
			if ( temp.Contains( Shared.BREAKMSG ) )
			{
				owner = temp;
			}
		}

		int j = 0;
		for ( j = i; j < msg.Length; j++ )
		{
			temp += msg[j];
			if ( temp.Contains( Shared.BREAKMSG ) )
			{
				ID = temp;
			}
		}

		temp = "";
		int k = 0;
		for ( k = j; k < msg.Length; k++ )
		{
			temp += msg[k];
			if ( temp.Contains( Shared.ENDMSG ) ) 
			{
				message = temp;
			}
		}
	}

	public override string ToString()
	{
		return owner + ID + message;
	}
}


// General functions used by both client and server.
public static class Shared
{		
	public const string BREAKMSG = "|<BREAKMSG>|"; // Put this at the end of a message "segment", for parsing reasons.
	public const string ENDMSG = "|<ENDMSG>|"; // Put at the end of the message.
	public const string USERINFOMSG = "|<USERINFOMSG>|"; // Put at the beginning of the message.
	public const string ACKMSG = "|<ACKMSG>|"; // Generic ack message.

	// General functions used by both
	public static async Task<int> SendMessage( Socket socket, MessageState msg, int buffersize, byte[]? AESKey = null )
	{
		// Not connected, get out.
		if ( socket == null || !socket.Connected )
			throw new SocketException();

		// Make a buffer to receive data.
		byte[] bytes = new byte[buffersize];

		bytes = Encoding.UTF8.GetBytes( msg.ToString() );

		// Encrypt if an AES key was provided.
		//if ( AESKey != null )
		//{
  //          var aes = Aes.Create();
  //          aes.KeySize = 256;
  //          aes.BlockSize = 128;
  //          aes.Padding = PaddingMode.Zeros;
  //          aes.GenerateIV();
		//	aes.Key = AESKey;

  //          aes.EncryptCbc( bytes, aes.IV );
  //      }

		return await socket.SendAsync( bytes );
	}

	public static async Task<MessageState?> ReceiveMessage( Socket socket, int buffersize )
	{
		// Not connected, get out
		if ( socket == null || !socket.Connected )
            throw new SocketException();

        // Receive the MessageState as a whole string
        byte[] buf = new byte[ buffersize ];
		string msg = "";

		await socket.ReceiveAsync(buf);

		while ( true )
		{
			msg += Encoding.UTF8.GetString( buf );

			if ( msg.Contains( ENDMSG ) )
				break;
		}

		return new MessageState( msg );
	}
}
