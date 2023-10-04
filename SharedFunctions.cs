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
	public string name { get; }
	public string nickname { get; set; }
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
[Serializable]
public class MessageState
{
	public string name;
	public string ID;
	public string message;
	public DateTime timeSent; // This should be modified by the server when sent.

	public MessageState()
	{
		name = "";
		ID = "";
		message = "";
	}

	public MessageState(string _name, string _ID, string _message )
	{
		name = _name + Shared.BREAKMSG;
		ID = _ID + Shared.BREAKMSG;
		message = _message + Shared.ENDMSG;
	}

	// Convert a string to a message state
	public MessageState( string msg )
	{
		string temp = "";
		int i = 0;
		for ( i = 0; i < msg.Length; i++ )
		{
			temp += msg[i];
			if ( temp.Contains( Shared.BREAKMSG ) )
			{
				name = temp + Shared.BREAKMSG;
			}
		}
		temp = "";
		int j = 0;
		for ( j = i; j < msg.Length; j++ )
		{
			temp += msg[j];
			if ( temp.Contains( Shared.BREAKMSG ) )
			{
				ID = temp + Shared.BREAKMSG;
			}
		}

		temp = "";
		for ( int k = j; k < msg.Length; k++ )
		{
			temp += msg[k];
			if ( temp.Contains( Shared.ENDMSG ) ) 
			{
				message = temp + Shared.ENDMSG;
			}
		}
	}

	public override string ToString()
	{
		return name + ID + message;
	}
}

public static class Shared
{		
	public const string BREAKMSG = "|<BREAKMSG>|";
	public const string ENDMSG = "|<ENDMSG>|";
	public const string USERINFOMSG = "|<USERINFOMSG>|";
	public const string ACKMSG = "|<ACKMSG>|";

	// General functions used by both
	public static int SendMessage( ref Socket socket, MessageState msg, int buffersize )
	{
		if ( socket == null || !socket.Connected )
			return -1;

		byte[] bytes = new byte[buffersize];

		bytes = Encoding.UTF8.GetBytes( msg.ToString() );

		return socket.Send( bytes );
	}

	public static MessageState? ReceiveMessage( ref Socket socket, int buffersize )
	{
		// Receive the MessageState as a whole string
		if ( socket == null || !socket.Connected )
			return null;

		byte[] buf = new byte[ buffersize ];
		string msg = "";

		while ( socket.Receive( buf ) > 0 )
		{
			msg += Encoding.UTF8.GetString( buf );
		}

		return new MessageState( msg );
	}

	public static int SendEncryptedMessage( ref Socket socket, MessageState msg, int buffersize )
	{
		if ( socket == null || !socket.Connected )
			return -1;

		byte[] bytes = new byte[ buffersize ];

		bytes = Encoding.UTF8.GetBytes( msg.ToString() );

		var aes = Aes.Create();

		aes.KeySize = 256;
		aes.BlockSize = buffersize;
		aes.Padding = PaddingMode.Zeros;

		aes.GenerateKey();




		return socket.Send( bytes );
	}

	public static string ReceiveEncryptedMessage( ref Socket socket, MessageState msg, int buffersize )
	{
		if ( socket == null || !socket.Connected )
			return "";

		return "";
	}
}
